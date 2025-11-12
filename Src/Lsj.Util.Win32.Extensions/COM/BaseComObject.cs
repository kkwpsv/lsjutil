using Lsj.Util.Reflection;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Extensions.Memory;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Extensions.COM
{
    /// <summary>
    /// Base COM Object
    /// </summary>
    /// <typeparam name="TInterface">
    /// the com interface
    /// </typeparam>
    public class BaseComObject<TInterface> where TInterface : struct
    {
        P<NativeComObject<TInterface>> _nativeObject;
        int _refCount = 1;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        public BaseComObject()
        {
            _nativeObject = HeapHelper.AllocMemoryForUnmanagedStruct(new NativeComObject<TInterface>(GetVTable(), this));
        }

        /// <summary>
        /// See <see cref="IUnknown.QueryInterface"/>
        /// </summary>
        /// <param name="riid"></param>
        /// <param name="ppvObject"></param>
        /// <returns></returns>
        public virtual HRESULT QueryInterface(in IID riid, out IntPtr ppvObject)
        {
            if (riid == IIDs.IID_IUnknown)
            {
                AddRef();
                ppvObject = GetNativePointer();
                return HRESULT.S_OK;
            }
            ppvObject = NULL;
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// See <see cref="IUnknown.AddRef"/>
        /// </summary>
        /// <returns></returns>
        public virtual ULONG AddRef()
        {
            return (uint)Interlocked.Increment(ref _refCount);
        }

        /// <summary>
        /// See <see cref="IUnknown.Release"/>
        /// </summary>
        /// <returns></returns>
        public virtual ULONG Release()
        {
            var value = Interlocked.Decrement(ref _refCount);
            if (value == 0)
            {
                _nativeObject.Value.Free();
                HeapHelper.FreeMemory(_nativeObject);
            }
            return (uint)value;
        }

        /// <summary>
        /// Get native pointer of interface
        /// </summary>
        /// <returns></returns>
        public P<TInterface> GetNativePointer()
        {
            return _nativeObject.AsP<TInterface>();
        }

        static object _vTableLock = new object();
        static VTable<TInterface>? _vTable;
        static Delegate[]? _delegates;

        /// <summary>
        /// VTable item count
        /// </summary>
        protected virtual int VTableItemCount => 3;

        private VTable<TInterface> GetVTable()
        {
            lock (_vTableLock)
            {
                if (_vTable == null)
                {
                    var count = VTableItemCount;
                    var vTable = new VTable<TInterface>(count);
                    _delegates = new Delegate[count];
                    _delegates[0] = vTable.SetMethod(0, GetMethodInfo(nameof(QueryInterface)));
                    _delegates[1] = vTable.SetMethod(1, GetMethodInfo(nameof(AddRef)));
                    _delegates[2] = vTable.SetMethod(2, GetMethodInfo(nameof(Release)));
                    InitVTable(new VTableInitHelper<TInterface>(vTable, _delegates));
                    _vTable = vTable;
                }
                return _vTable.Value;
            }
        }

        /// <summary>
        /// Init VTable methods
        /// </summary>
        /// <param name="vTable"></param>
        protected virtual void InitVTable(VTableInitHelper<TInterface> vTable)
        {

        }

        /// <summary>
        /// Free VTable
        /// </summary>
        public static void FreeVTable()
        {
            lock (_vTableLock)
            {
                _vTable = null;
                _delegates = null;
            }
        }

        /// <summary>
        /// Get MethodInfo from method name
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        protected MethodInfo GetMethodInfo(string method)
        {
            return GetType().GetMethod(method)!;
        }
    }

    internal struct NativeComObject<TInterface> where TInterface : struct
    {
        VTable<TInterface> _vtable;
        GCHandle _objHandle;

        public NativeComObject(VTable<TInterface> vTable, BaseComObject<TInterface> obj)
        {
            _vtable = vTable;
            _objHandle = GCHandle.Alloc(obj, GCHandleType.Normal);
        }

        public void Free()
        {
            _objHandle.Free();
            _vtable.Free();
        }

        public static BaseComObject<TInterface> GetObj(P<NativeComObject<TInterface>> nativeComObject)
        {
            return (BaseComObject<TInterface>)nativeComObject.Value._objHandle.Target!;
        }
    }

    /// <summary>
    /// VTable
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public unsafe struct VTable<TInterface> where TInterface : struct
    {
        nint* _vTable;
        internal VTable(int count)
        {
            _vTable = (nint*)HeapHelper.AllocMemory(count * UnsafePInvokeExtensions.SizeOf<nint>());
        }

        static MethodInfo _getObjectMethod;
        static VTable()
        {
            _getObjectMethod = typeof(NativeComObject<TInterface>).GetMethod(nameof(NativeComObject<TInterface>.GetObj))!;
        }

        internal void Free()
        {
            HeapHelper.FreeMemory((nint)_vTable);
        }

        /// <summary>
        /// Set method for vTable
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public Delegate SetMethod(int offset, MethodInfo method)
        {
            var retType = method.ReturnType;
            var originalParameters = method.GetParameters();

            var parameters = new ParameterExpression[originalParameters.Length + 1];
            parameters[0] = Expression.Parameter(typeof(P<NativeComObject<TInterface>>), "obj");
            for (int i = 0; i < originalParameters.Length; i++)
            {
                parameters[i + 1] = Expression.Parameter(originalParameters[i].ParameterType, originalParameters[i].Name);
            }

            var instance = Expression.Call(_getObjectMethod, parameters[0]);
            var call = Expression.Call(Expression.Convert(instance, method.DeclaringType!), method, parameters.Skip(1));

            // 需要手动创建委托类型，否则可能是 System.Func 或 System.Action，Marshal.GetFunctionPointerForDelegate 会炸掉。
            var lambda = Expression.Lambda(CreateDelegateType($"{method.DeclaringType!.Name}_{method.Name}_thunk_{Guid.NewGuid()}", retType, parameters), call, parameters);
            var @delegate = lambda.Compile();
            _vTable[offset] = Marshal.GetFunctionPointerForDelegate(@delegate);
            return @delegate;
        }

        private Type CreateDelegateType(string name, Type retType, ParameterExpression[] parameters)
        {
            Type[] parameterTypes = parameters.Select(x =>
            {
                return x.IsByRef ? x.Type.MakeByRefType() : x.Type;
            }).ToArray();

            return DynamicAssemblyHelper.DefineDelegate(name, retType, parameterTypes).CreateTypeInfo()!;
        }
    }

    /// <summary>
    /// VTable init helper
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public class VTableInitHelper<TInterface> where TInterface : struct
    {
        private VTable<TInterface> _vTable;
        private Delegate[] _delegates;

        internal VTableInitHelper(VTable<TInterface> vTable, Delegate[] delegates)
        {
            _vTable = vTable;
            _delegates = delegates;
        }

        /// <summary>
        /// Set method for vtable
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="method"></param>
        public void SetMethod(int offset, MethodInfo method)
        {
            _delegates[offset] = _vTable.SetMethod(offset, method);
        }
    }
}

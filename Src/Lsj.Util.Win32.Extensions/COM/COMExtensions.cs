using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Enums.CLSCTX;

namespace Lsj.Util.Win32.Extensions.COM
{
    /// <summary>
    /// COM Extensions
    /// </summary>
    public static class COMExtensions
    {
        /// <summary>
        /// <para>
        /// Get com interface struct from pointer
        /// </para>
        /// <para>
        /// ONLY use return value directly.
        /// DON'T copy return value (like assign it to local variables), which will crash.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pointer"></param>
        /// <returns></returns>
        public static unsafe ref T InterfaceFromPointer<T>(IntPtr pointer) where T : struct
        {
            return ref pointer.AsStructRef<T>();
        }

        /// <summary>
        ///  Create COM object instance with <see cref="CLSCTX_ALL"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clsid"></param>
        /// <param name="iid"></param>
        /// <returns></returns>
        public static P<T> CreateInstance<T>(CLSID clsid, IID iid) where T : struct => CreateInstance<T>(clsid, iid, CLSCTX.CLSCTX_ALL);

        /// <summary>
        /// Create COM object instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clsid"></param>
        /// <param name="iid"></param>
        /// <param name="clsctx"></param>
        /// <returns></returns>
        public static P<T> CreateInstance<T>(CLSID clsid, IID iid, CLSCTX clsctx) where T : struct
        {
            var result = Ole32.CoCreateInstance(clsid, NullRef<IUnknown>(), clsctx, iid, out var obj);
            if (result)
            {
                return (P<T>)obj.ToIntPtr();
            }
            else
            {
                throw Marshal.GetExceptionForHR(result)!;
            }
        }

        /// <summary>
        /// As <see cref="Lsj.Util.Win32.ComInterfaces.IUnknown.QueryInterface"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static P<IUnknown> AsIUnknown<T>(this P<T> from) where T : struct => from.AsP<IUnknown>();

        /// <summary>
        /// To Interface with <see cref="Lsj.Util.Win32.ComInterfaces.IUnknown.QueryInterface"/>
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="iUnknown"></param>
        /// <param name="toIID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static P<TTo> ToInterface<TTo>(this P<IUnknown> iUnknown, IID toIID) where TTo : struct
        {
            if (iUnknown.Value.QueryInterface(toIID, out var ppvObject))
            {
                return (P<TTo>)ppvObject;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}

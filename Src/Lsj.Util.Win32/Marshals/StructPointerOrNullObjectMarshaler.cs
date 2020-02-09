using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    internal class StructPointerOrNullObjectMarshaler<T> : ICustomMarshaler where T : struct
    {
        static StructPointerOrNullObjectMarshaler<T> instance = new StructPointerOrNullObjectMarshaler<T>();

        public static ICustomMarshaler GetInstance(string cookie) => instance;

        [ThreadStatic] IntPtr? marshaledIntPtr;

        public void CleanUpManagedData(object ManagedObj)
        {
            if (marshaledIntPtr != null)
            {
                Marshal.FreeHGlobal(marshaledIntPtr.Value);
            }
        }

        public void CleanUpNativeData(IntPtr pNativeData) => throw new NotImplementedException();

        public int GetNativeDataSize() => IntPtr.Size;

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            if (ManagedObj is StructPointerOrNullObject<T> obj)
            {
                if (obj.Value.HasValue)
                {
                    marshaledIntPtr = MarshalExtensions.StructureToPtr(obj.Value.Value);
                    return marshaledIntPtr.Value;
                }
                else
                {
                    return IntPtr.Zero;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public object MarshalNativeToManaged(IntPtr pNativeData) => throw new NotImplementedException();
    }
}

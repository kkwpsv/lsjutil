using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    internal class StringOrIntPtrObjectMarshaler : ICustomMarshaler
    {
        static StringOrIntPtrObjectMarshaler instance = new StringOrIntPtrObjectMarshaler();

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
            if (ManagedObj is StringOrIntPtrObject obj)
            {
                if (obj.IsString)
                {
                    marshaledIntPtr = Marshal.StringToHGlobalUni(obj.StringVal);
                    return marshaledIntPtr.Value;
                }
                else
                {
                    return obj.IntPtrVal;
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

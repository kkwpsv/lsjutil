using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    internal class MarshalStringMarshaler : ICustomMarshaler
    {
        static MarshalStringMarshaler _instance = new MarshalStringMarshaler();

        public static ICustomMarshaler GetInstance(string cookie) => _instance;

        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {

        }

        public int GetNativeDataSize() => IntPtr.Size;

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            if (ManagedObj is MarshalString obj)
            {
                return Marshal.StringToHGlobalUni(obj.Value);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public object MarshalNativeToManaged(IntPtr pNativeData) => new MarshalString(Marshal.PtrToStringUni(pNativeData));

    }
}

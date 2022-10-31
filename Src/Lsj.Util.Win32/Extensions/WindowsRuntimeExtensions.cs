using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Combase;

namespace Lsj.Util.Win32.Extensions
{
    /// <summary>
    /// WindowsRuntime Extensions
    /// </summary>
    public static class WindowsRuntimeExtensions
    {
        /// <summary>
        /// Create <see cref="HSTRING"/> from <see cref="string"/>
        /// The <see cref="HSTRING"/> should be deleted by <see cref="WindowsDeleteString"/> 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static HSTRING CreateHString(string str)
        {
            var result = WindowsCreateString(str, (uint)str.Length, out var hstr);
            if (!result.Succeed)
            {
                throw Marshal.GetExceptionForHR(result);
            }
            else
            {
                return hstr;
            }
        }

        /// <summary>
        /// GetActivationFactory
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="iid"></param>
        /// <returns></returns>
        public static IntPtr GetActivationFactory(string typeName, IID iid)
        {
            var hstr = CreateHString(typeName);
            try
            {
                var result = RoGetActivationFactory(hstr, iid, out var factory);
                if (!result.Succeed)
                {
                    throw Marshal.GetExceptionForHR(result);
                }
                else
                {
                    return factory;
                }
            }
            finally
            {
                var result = WindowsDeleteString(hstr);
                if (!result.Succeed)
                {
                    throw Marshal.GetExceptionForHR(result);
                }
            }
        }
    }
}

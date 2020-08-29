using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A data type used for specifying the security access attributes in the registry.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/shell/regsam
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct REGSAM
    {
        [FieldOffset(0)]
        private RegistryKeyAccessRights _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator REGSAM(RegistryKeyAccessRights val) => new REGSAM { _value = val };
    }
}

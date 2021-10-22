using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DOT11_MAC_ADDRESS"/> types are used to define an IEEE media access control (MAC) address.
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/nativewifi/dot11-mac-address-type"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 6 * sizeof(char))]
    public struct DOT11_MAC_ADDRESS
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public unsafe UCHAR this[int index]
        {
            get
            {
                return *((UCHAR*)AsPointer(ref this) + index);
            }
            set
            {
                *((UCHAR*)AsPointer(ref this) + index) = value;
            }
        }
    }
}

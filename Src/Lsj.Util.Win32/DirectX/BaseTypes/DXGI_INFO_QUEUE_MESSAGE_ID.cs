using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.BaseTypes
{
    /// <summary>
    /// DXGI_INFO_QUEUE_MESSAGE_ID
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct DXGI_INFO_QUEUE_MESSAGE_ID
    {
        [FieldOffset(0)]
        private int _value;
    }
}

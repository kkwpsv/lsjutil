using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DSURFACE_DESC
    {
        public D3DFORMAT Format;
        public D3DRESOURCETYPE Type;
        public DWORD Usage;
        public D3DPOOL Pool;
        public D3DMULTISAMPLE_TYPE MultiSampleType;
        public DWORD MultiSampleQuality;
        public UINT Width;
        public UINT Height;
    }
}

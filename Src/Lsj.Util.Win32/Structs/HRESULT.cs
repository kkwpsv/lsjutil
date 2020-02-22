using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// HRESULT
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct HRESULT
    {
        /// <summary>
        /// S_OK
        /// </summary>
        public static HRESULT S_OK = new HRESULT();

        [FieldOffset(0)]
        private int value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(HRESULT val) => val.value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HRESULT(int val) => new HRESULT { value = val };
    }
}

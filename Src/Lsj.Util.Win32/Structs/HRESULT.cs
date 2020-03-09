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
        /// E_OUTOFMEMORY
        /// </summary>
        public static readonly HRESULT E_OUTOFMEMORY = new HRESULT { value = unchecked((int)0x8007000E) };

        /// <summary>
        /// E_INVALIDARG
        /// </summary>
        public static readonly HRESULT E_INVALIDARG = new HRESULT { value = unchecked((int)0x80070057) };

        /// <summary>
        /// S_OK
        /// </summary>
        public static readonly HRESULT S_OK = new HRESULT();

        [FieldOffset(0)]
        private int value;

        public override string ToString() => value.ToString("X");

        public bool Succeed => value >= 0;

        public static implicit operator bool(HRESULT val) => val.Succeed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(HRESULT val) => unchecked((uint)val.value);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HRESULT(uint val) => new HRESULT { value = unchecked((int)val) };
    }
}

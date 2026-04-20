using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// Macros
    /// </summary>
    public static class Macros
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Src0"></param>
        /// <param name="Src1"></param>
        /// <param name="Src2"></param>
        /// <param name="Src3"></param>
        /// <returns></returns>
        public static uint D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING(byte Src0, byte Src1, byte Src2, byte Src3) =>
            (uint)((Src0 & D3D12_SHADER_COMPONENT_MAPPING_MASK) |
            ((Src1 & D3D12_SHADER_COMPONENT_MAPPING_MASK) << D3D12_SHADER_COMPONENT_MAPPING_SHIFT) |
            ((Src2 & D3D12_SHADER_COMPONENT_MAPPING_MASK) << (D3D12_SHADER_COMPONENT_MAPPING_SHIFT * 2)) |
            ((Src3 & D3D12_SHADER_COMPONENT_MAPPING_MASK) << (D3D12_SHADER_COMPONENT_MAPPING_SHIFT * 3)) |
            D3D12_SHADER_COMPONENT_MAPPING_ALWAYS_SET_BIT_AVOIDING_ZEROMEM_MISTAKES);
    }
}

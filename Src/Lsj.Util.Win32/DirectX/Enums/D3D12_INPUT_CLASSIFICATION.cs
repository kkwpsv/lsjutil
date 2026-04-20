using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the type of data contained in an input slot.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_input_classification"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Specify one of these values in the member of a <see cref="D3D12_INPUT_ELEMENT_DESC"/> structure
    /// to specify the type of data for the input element of a pipeline state object.
    /// </remarks>
    public enum D3D12_INPUT_CLASSIFICATION
    {
        /// <summary>
        /// Input data is per-vertex data.
        /// </summary>
        D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA = 0,

        /// <summary>
        /// Input data is per-instance data.
        /// </summary>
        D3D12_INPUT_CLASSIFICATION_PER_INSTANCE_DATA = 1
    }
}

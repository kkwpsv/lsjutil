using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Type of data contained in an input slot.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_input_classification"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use these values to specify the type of data for a particular input element (see <see cref="D3D11_INPUT_ELEMENT_DESC"/>) of an input-layout object.
    /// </remarks>
    public enum D3D11_INPUT_CLASSIFICATION
    {
        /// <summary>
        /// Input data is per-vertex data.
        /// </summary>
        D3D11_INPUT_PER_VERTEX_DATA = 0,

        /// <summary>
        /// Input data is per-instance data.
        /// </summary>
        D3D11_INPUT_PER_INSTANCE_DATA = 1,
    }
}

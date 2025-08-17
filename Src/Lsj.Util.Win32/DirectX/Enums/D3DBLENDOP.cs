using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the supported blend operations.
    /// See Remarks for definitions of terms.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dblendop"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Source, Destination, and Result are defined as:
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Term
    /// </term>
    /// <term>
    /// Type
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// Source
    /// </term>
    /// <term>
    /// Input
    /// </term>
    /// <term>
    /// Color of the source pixel before the operation.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Destination
    /// </term>
    /// <term>
    /// Input
    /// </term>
    /// <term>
    /// Color of the pixel in the destination buffer before the operation.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Result
    /// </term>
    /// <term>
    /// Output
    /// </term>
    /// <term>
    /// Returned value that is the blended color resulting from the operation.
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// This enumerated type defines values used by the following render states:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3DRS_BLENDOP"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3DRS_BLENDOPALPHA"/>
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public enum D3DBLENDOP
    {
        /// <summary>
        /// The result is the destination added to the source.
        /// Result = Source + Destination
        /// </summary>
        D3DBLENDOP_ADD = 1,

        /// <summary>
        /// The result is the destination subtracted from to the source.
        /// Result = Source - Destination
        /// </summary>
        D3DBLENDOP_SUBTRACT = 2,

        /// <summary>
        /// The result is the source subtracted from the destination.
        /// Result = Destination - Source
        /// </summary>
        D3DBLENDOP_REVSUBTRACT = 3,

        /// <summary>
        /// The result is the minimum of the source and destination.
        /// Result = MIN(Source, Destination)
        /// </summary>
        D3DBLENDOP_MIN = 4,

        /// <summary>
        /// The result is the maximum of the source and destination.
        /// Result = MAX(Source, Destination)
        /// </summary>
        D3DBLENDOP_MAX = 5,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DBLENDOP_FORCE_DWORD = 0x7fffffff
    }
}

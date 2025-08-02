using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Defines the dimensions of a viewport.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_viewport"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// In all cases, <see cref="Width"/> and <see cref="Height"/> must be &gt;= 0 and
    /// <see cref="TopLeftX"/> + <see cref="Width"/> and <see cref="TopLeftY"/> + <see cref="Height"/> must be &lt;= <see cref="D3D11_VIEWPORT_BOUNDS_MAX"/>.
    /// </para>
    /// <para>
    /// Viewport Sizes and Feature Level Support Differences between Direct3D 11 and Direct3D 10:
    /// </para>
    /// <para>
    /// The range for the minimum and maximum viewport size is dependent on the feature level defined by <see cref="D3D_FEATURE_LEVEL"/>.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Direct3D 11 supports fractional viewports; the parameter types are floating-point numbers.
    /// The feature level, <see cref="D3D_FEATURE_LEVEL_11_0"/>,
    /// supports (<see cref="D3D11_VIEWPORT_BOUNDS_MIN"/>, <see cref="D3D11_VIEWPORT_BOUNDS_MAX"/>) values between (-32768, 32,767).
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Direct3D 10 does not support fractional viewports.
    /// The feature levels, <see cref="D3D_FEATURE_LEVEL_10_1"/> (or below),
    /// supports (<see cref="D3D10_VIEWPORT_BOUNDS_MIN"/>, <see cref="D3D10_VIEWPORT_BOUNDS_MAX"/>) values between (-16384, 16383).
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// Even though you specify float values to the members of the <see cref="D3D11_VIEWPORT"/> structure
    /// for the pViewports array in a call to <see cref="ID3D11DeviceContext.RSSetViewports"/> for feature levels 9_x,
    /// <see cref="ID3D11DeviceContext.RSSetViewports"/> uses DWORDs internally.
    /// Because of this behavior, when you use a negative top left corner for the viewport,
    /// the call to <see cref="ID3D11DeviceContext.RSSetViewports"/> for feature levels 9_x fails.
    /// This failure occurs because <see cref="ID3D11DeviceContext.RSSetViewports"/> for 9_x casts the floating point values
    /// into unsigned integers without validation, which results in integer overflow.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIEWPORT
    {
        /// <summary>
        /// X position of the left hand side of the viewport.
        /// Ranges between <see cref="D3D11_VIEWPORT_BOUNDS_MIN"/> and <see cref="D3D11_VIEWPORT_BOUNDS_MAX"/>.
        /// </summary>
        public FLOAT TopLeftX;

        /// <summary>
        /// Y position of the top of the viewport.
        /// Ranges between <see cref="D3D11_VIEWPORT_BOUNDS_MIN"/> and <see cref="D3D11_VIEWPORT_BOUNDS_MAX"/>.
        /// </summary>
        public FLOAT TopLeftY;

        /// <summary>
        /// Width of the viewport.
        /// </summary>
        public FLOAT Width;

        /// <summary>
        /// Height of the viewport.
        /// </summary>
        public FLOAT Height;

        /// <summary>
        /// Minimum depth of the viewport. Ranges between 0 and 1.
        /// </summary>
        public FLOAT MinDepth;

        /// <summary>
        /// Maximum depth of the viewport. Ranges between 0 and 1.
        /// </summary>
        public FLOAT MaxDepth;
    }
}

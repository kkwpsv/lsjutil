using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DXGI_GAMMA_CONTROL_CAPABILITIES"/> structure describes gamma capabilities.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/dxgitype/ns-dxgitype-dxgi_gamma_control_capabilities"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_GAMMA_CONTROL_CAPABILITIES
    {
        /// <summary>
        /// A <see cref="BOOL"/> value that indicates whether the device supports scale and offset.
        /// <see cref="TRUE"/> indicates that the device supports scale and offset;
        /// <see cref="FALSE"/> indicates that the device does not support scale and offset.
        /// </summary>
        public BOOL ScaleAndOffsetSupported;

        /// <summary>
        /// A single-precision float vector for the maximum converted value for the gamma control.
        /// </summary>
        public float MaxConvertedValue;

        /// <summary>
        /// A single-precision float vector for the minimum converted value for the gamma control.
        /// </summary>
        public float MinConvertedValue;

        /// <summary>
        /// The number of elements in the array that the <see cref="ControlPointPositions"/> member specifies.
        /// </summary>
        public UINT NumGammaControlPoints;

        /// <summary>
        /// An array of single-precision float vectors that describe the gamma control point positions.
        /// </summary>
        public ByValFloatArrayStructForSize1025 ControlPointPositions;
    }
}

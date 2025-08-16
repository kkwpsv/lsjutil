namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes the set of features targeted by a Direct3D device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_feature_level"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// For an overview of the capabilities of each feature level, see Direct3D feature levels.
    /// </para>
    /// <para>
    /// For information about limitations creating non-hardware-type devices on certain feature levels,
    /// see Limitations creating WARP and reference devices.
    /// </para>
    /// </remarks>
    public enum D3D_FEATURE_LEVEL
    {
        /// <summary>
        /// Allows Microsoft Compute Driver Model (MCDM) devices to be used,
        /// or more feature-rich devices (such as traditional GPUs) that support a superset of the functionality.
        /// MCDM is the overall driver model for compute-only; it's a scaled-down peer of the larger scoped Windows Device Driver Model (WDDM).
        /// </summary>
        D3D_FEATURE_LEVEL_1_0_CORE = 0x1000,

        /// <summary>
        /// Targets features supported by feature level 9.1, including shader model 2.
        /// </summary>
        D3D_FEATURE_LEVEL_9_1 = 0x9100,

        /// <summary>
        /// Targets features supported by feature level 9.2, including shader model 2.
        /// </summary>
        D3D_FEATURE_LEVEL_9_2 = 0x9200,

        /// <summary>
        /// Targets features supported by feature level 9.3, including shader model 2.0b.
        /// </summary>
        D3D_FEATURE_LEVEL_9_3 = 0x9300,

        /// <summary>
        /// Targets features supported by Direct3D 10.0, including shader model 4.
        /// </summary>
        D3D_FEATURE_LEVEL_10_0 = 0xa000,

        /// <summary>
        /// Targets features supported by Direct3D 10.1, including shader model 4.
        /// </summary>
        D3D_FEATURE_LEVEL_10_1 = 0xa100,

        /// <summary>
        /// Targets features supported by Direct3D 11.0, including shader model 5.
        /// </summary>
        D3D_FEATURE_LEVEL_11_0 = 0xb000,

        /// <summary>
        /// Targets features supported by Direct3D 11.1, including shader model 5 and logical blend operations.
        /// This feature level requires a display driver that is at least implemented to WDDM for Windows 8 (WDDM 1.2).
        /// </summary>
        D3D_FEATURE_LEVEL_11_1 = 0xb100,

        /// <summary>
        /// Targets features supported by Direct3D 12.0, including shader model 5.
        /// </summary>
        D3D_FEATURE_LEVEL_12_0 = 0xc000,

        /// <summary>
        /// Targets features supported by Direct3D 12.1, including shader model 5.
        /// </summary>
        D3D_FEATURE_LEVEL_12_1 = 0xc100,

        /// <summary>
        /// Targets features supported by Direct3D 12.2, including shader model 6.5.
        /// For more information about feature level 12_2, see its specification page.
        /// Feature level 12_2 is available in Windows SDK builds 20170 and later.
        /// </summary>
        D3D_FEATURE_LEVEL_12_2 = 0xc200,
    }
}

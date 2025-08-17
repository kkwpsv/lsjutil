using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DSWAPEFFECT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the levels of full-scene multisampling that the device can apply.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dmultisample-type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// In addition to enabling full-scene multisampling at <see cref="IDirect3DDevice9.Reset"/> time,
    /// there will be render states that turn various aspects on and off at fine-grained levels.
    /// </para>
    /// <para>
    /// Multisampling is valid only on a swap chain that is being created or reset with the <see cref="D3DSWAPEFFECT_DISCARD"/> swap effect.
    /// </para>
    /// <para>
    /// The multisample antialiasing value can be set with the parameters (or sub-parameters) in the following methods.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Method
    /// </term>
    /// <term>
    /// Parameters
    /// </term>
    /// <term>
    /// Sub-parameters
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="IDirect3D9.CheckDeviceMultiSampleType"/>
    /// </term>
    /// <term>
    /// MultiSampleType and pQualityLevels
    /// </term>
    /// <term>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="IDirect3D9.CreateDevice"/>
    /// </term>
    /// <term>
    /// pPresentationParameters
    /// </term>
    /// <term>
    /// MultiSampleType and pQualityLevels
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="IDirect3DDevice9.CreateAdditionalSwapChain"/>
    /// </term>
    /// <term>
    /// pPresentationParameters
    /// </term>
    /// <term>
    /// MultiSampleType and pQualityLevels
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="IDirect3DDevice9.CreateDepthStencilSurface"/>
    /// </term>
    /// <term>
    /// MultiSampleType and pQualityLevels
    /// </term>
    /// <term>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="IDirect3DDevice9.CreateRenderTarget"/>
    /// </term>
    /// <term>
    /// MultiSampleType and pQualityLevels
    /// </term>
    /// <term>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="IDirect3DDevice9.Reset"/>
    /// </term>
    /// <term>
    /// pPresentationParameters
    /// </term>
    /// <term>
    /// MultiSampleType and pQualityLevels
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// It is not good practice to switch from one multisample type to another to raise the quality of the antialiasing.
    /// </para>
    /// <para>
    /// D3DMULTISAMPLE_NONE enables swap effects other than discarding, locking, and so on.
    /// </para>
    /// <para>
    /// Whether the display device supports maskable multisampling
    /// (more than one sample for a multiple-sample render-target format plus antialias support)
    /// or just non-maskable multisampling (only antialias support),
    /// the driver for the device provides the number of quality levels for the <see cref="D3DMULTISAMPLE_NONMASKABLE"/> multiple-sample type.
    /// Applications that just use multisampling for antialiasing purposes only need to query for
    /// the number of non-maskable multiple-sample quality levels that the driver supports.
    /// </para>
    /// <para>
    /// The quality levels supported by the device can be obtained 
    /// with the pQualityLevels parameter of <see cref="IDirect3D9.CheckDeviceMultiSampleType"/>.
    /// Quality levels used by the application are set with the MultiSampleQuality parameter
    /// of <see cref="IDirect3DDevice9.CreateDepthStencilSurface"/> and <see cref="IDirect3DDevice9.CreateRenderTarget"/>.
    /// </para>
    /// <para>
    /// See <see cref="D3DRS_MULTISAMPLEMASK"/> for discussion of maskable multisampling.
    /// </para>
    /// </remarks>
    public enum D3DMULTISAMPLE_TYPE
    {
        /// <summary>
        /// No level of full-scene multisampling is available.
        /// </summary>
        D3DMULTISAMPLE_NONE = 0,

        /// <summary>
        /// Enables the multisample quality value. See Remarks.
        /// </summary>
        D3DMULTISAMPLE_NONMASKABLE = 1,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_2_SAMPLES = 2,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_3_SAMPLES = 3,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_4_SAMPLES = 4,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_5_SAMPLES = 5,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_6_SAMPLES = 6,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_7_SAMPLES = 7,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_8_SAMPLES = 8,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_9_SAMPLES = 9,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_10_SAMPLES = 10,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_11_SAMPLES = 11,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_12_SAMPLES = 12,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_13_SAMPLES = 13,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_14_SAMPLES = 14,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_15_SAMPLES = 15,

        /// <summary>
        /// Level of full-scene multisampling available.
        /// </summary>
        D3DMULTISAMPLE_16_SAMPLES = 16,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DMULTISAMPLE_FORCE_DWORD = unchecked((int)0xffffffff),
    }
}

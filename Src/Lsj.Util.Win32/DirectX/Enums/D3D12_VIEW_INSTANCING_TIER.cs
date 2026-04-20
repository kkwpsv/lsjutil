namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the tier level at which view instancing is supported.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_view_instancing_tier"/>
    /// </para>
    /// </summary>
    public enum D3D12_VIEW_INSTANCING_TIER
    {
        /// <summary>
        /// View instancing is not supported.
        /// </summary>
        D3D12_VIEW_INSTANCING_TIER_NOT_SUPPORTED = 0,

        /// <summary>
        /// View instancing is supported by draw-call level looping only.
        /// </summary>
        D3D12_VIEW_INSTANCING_TIER_1 = 1,

        /// <summary>
        /// View instancing is supported by draw-call level looping at worst,
        /// but the GPU can perform view instancing more efficiently in certain circumstances which are architecture-dependent.
        /// </summary>
        D3D12_VIEW_INSTANCING_TIER_2 = 2,

        /// <summary>
        /// <para>
        /// View instancing is supported and instancing begins with the first shader stage
        /// that references <c>SV_ViewID</c> or with rasterization if no shader stage references <c>SV_ViewID</c>.
        /// This means that redundant work is eliminated across view instances when it's not dependent on <c>SV_ViewID</c>.
        /// Before rasterization, work that doesn't directly depend on <c>SV_ViewID</c> is shared across all views;
        /// only work that depends on SV_ViewID is repeated for each view.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If a hull shader produces tessellation factors that are dependent on <c>SV_ViewID</c>,
        /// then tessellation and all subsequent work must be repeated per-view.
        /// Similarly, if the amount of geometry produced by the geometry shader depends on <c>SV_ViewID</c>,
        /// then the geometry shader must be repeated per-view before proceeding to rasterization.
        /// </para>
        /// <para>
        /// View instance masking only effects whether work that directly depends on <c>SV_ViewID</c> is performed,
        /// not the entire loop iteration (per-view).
        /// If the view instance mask is non-0, some work that depends on <c>SV_ViewID</c>
        /// might still be performed on masked-off pixels but will have no externally-visible effect;
        /// for example, no UAV writes are performed and clipping/rasterization is not invoked.
        /// If the view instance mask is 0 no work is performed, including work that's not dependent on <c>SV_ViewID</c>.
        /// </para>
        /// </summary>
        D3D12_VIEW_INSTANCING_TIER_3 = 3
    }
}

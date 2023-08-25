using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies result flags for the <see cref="IDXGIDevice4.ReclaimResources1"/> method.
    /// </para>
    /// </summary>
    public enum DXGI_RECLAIM_RESOURCE_RESULTS
    {
        /// <summary>
        /// The surface was successfully reclaimed and has valid content.
        /// This result is identical to the false value returned by the older <see cref="IDXGIDevice2.ReclaimResources"/> API.
        /// </summary>
        DXGI_RECLAIM_RESOURCE_RESULT_OK = 0,

        /// <summary>
        /// The surface was reclaimed, but the old content was lost and must be regenerated.
        /// This result is identical to the true value returned by the older <see cref="IDXGIDevice2.ReclaimResources"/> API.
        /// </summary>
        DXGI_RECLAIM_RESOURCE_RESULT_DISCARDED = 1,

        /// <summary>
        /// Both the surface and its contents are lost and invalid.
        /// The surface must be recreated and the content regenerated in order to be used.
        /// All future use of that resource is invalid.
        /// Attempts to bind it to the pipeline or map a resource which returns this value will never succeed, and the resource cannot be reclaimed again.
        /// </summary>
        DXGI_RECLAIM_RESOURCE_RESULT_NOT_COMMITTED = 2
    }
}

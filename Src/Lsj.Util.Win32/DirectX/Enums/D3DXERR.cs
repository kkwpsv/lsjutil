namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Errors are represented by negative values and cannot be combined.
    /// The following is a list of values that can be returned by methods included with the D3DX utility library.
    /// See the individual method descriptions for lists of the values that each can return.
    /// These lists are not necessarily comprehensive.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dxerr"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The facility code _FACDD is used to generate error codes, as in the following macros.
    /// </para>
    /// <code>
    /// #define _FACDD                  0x876
    /// #define MAKE_DDHRESULT( code )  MAKE_HRESULT( 1, _FACDD, code )
    /// enum _D3DXERR {
    ///     D3DXERR_CANNOTMODIFYINDEXBUFFER = MAKE_DDHRESULT(2900),
    ///     D3DXERR_INVALIDMESH             = MAKE_DDHRESULT(2901),
    ///     ...
    ///     };
    /// </code>
    /// </remarks>
    public enum D3DXERR : uint
    {
        /// <summary>
        /// The index buffer cannot be modified.
        /// </summary>
        D3DXERR_CANNOTMODIFYINDEXBUFFER = 0x88760b54,

        /// <summary>
        /// The mesh is invalid.
        /// </summary>
        D3DXERR_INVALIDMESH,

        /// <summary>
        /// Attribute sort (<see cref="D3DXMESHOPT_ATTRSORT"/>) is not supported as an optimization technique.
        /// </summary>
        D3DXERR_CANNOTATTRSORT,

        /// <summary>
        /// Skinning is not supported.
        /// </summary>
        D3DXERR_SKINNINGNOTSUPPORTED,

        /// <summary>
        /// Too many influences specified.
        /// </summary>
        D3DXERR_TOOMANYINFLUENCES,

        /// <summary>
        /// The data is invalid.
        /// </summary>
        D3DXERR_INVALIDDATA,

        /// <summary>
        /// The mesh has no data.
        /// </summary>
        D3DXERR_LOADEDMESHASNODATA,

        /// <summary>
        /// A fragment with that name already exists.
        /// </summary>
        D3DXERR_DUPLICATENAMEDFRAGMENT,

        /// <summary>
        /// The last item cannot be deleted.
        /// </summary>
        D3DXERR_CANNOTREMOVELASTITEM,
    }
}

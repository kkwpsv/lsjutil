namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Controls aspects of the behavior of the <see cref="IOleObject.GetMoniker"/> and <see cref="IOleClientSite.GetMoniker"/> methods.
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the <see cref="OLEGETMONIKER_FORCEASSIGN"/> flag causes a container to create a moniker for the object,
    /// the container should notify the object by calling the <see cref="IOleObject.GetMoniker"/> method.
    /// </remarks>
    public enum OLEGETMONIKER
    {
        /// <summary>
        /// If a moniker for the object or container does not exist,
        /// <see cref="IOleClientSite.GetMoniker"/> should return <see cref="E_FAIL"/> and not assign a moniker.
        /// </summary>
        OLEGETMONIKER_ONLYIFTHERE = 1,

        /// <summary>
        /// If a moniker for the object or container does not exist, <see cref="IOleClientSite.GetMoniker"/> should create one.
        /// </summary>
        OLEGETMONIKER_FORCEASSIGN = 2,

        /// <summary>
        /// <see cref="IOleClientSite.GetMoniker"/> can release the object's moniker (although it is not required to do so).
        /// This constant is not valid in <see cref="IOleObject.GetMoniker"/>.
        /// </summary>
        OLEGETMONIKER_UNASSIGN = 3,

        /// <summary>
        /// If a moniker for the object does not exist, <see cref="IOleObject.GetMoniker"/> can create a temporary moniker
        /// that can be used for display purposes (<see cref="IMoniker.GetDisplayName"/>) but not for binding.
        /// This enables the object server to return a descriptive name for the object without incurring
        /// the overhead of creating and maintaining a moniker until a link is actually created.
        /// </summary>
        OLEGETMONIKER_TEMPFORUSER = 4
    }
}

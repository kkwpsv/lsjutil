namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Acl Revisions
    /// </summary>
    public enum AclRevisions : byte
    {
        /// <summary>
        /// ACL_REVISION
        /// </summary>
        ACL_REVISION = 2,

        /// <summary>
        /// ACL_REVISION_DS
        /// </summary>
        ACL_REVISION_DS = 4,

        /// <summary>
        /// ACL_REVISION1
        /// </summary>
        ACL_REVISION1 = 1,

        /// <summary>
        /// MIN_ACL_REVISION
        /// </summary>
        MIN_ACL_REVISION = ACL_REVISION2,

        /// <summary>
        /// ACL_REVISION2
        /// </summary>
        ACL_REVISION2 = 2,

        /// <summary>
        /// ACL_REVISION3
        /// </summary>
        ACL_REVISION3 = 3,

        /// <summary>
        /// ACL_REVISION4
        /// </summary>
        ACL_REVISION4 = 4,

        /// <summary>
        /// MAX_ACL_REVISION
        /// </summary>
        MAX_ACL_REVISION = ACL_REVISION4,
    }
}

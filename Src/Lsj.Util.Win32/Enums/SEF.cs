namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// SEF
    /// </summary>
    public enum SEF : uint
    {
        /// <summary>
        /// SEF_DACL_AUTO_INHERIT
        /// </summary>
        SEF_DACL_AUTO_INHERIT = 0x01,

        /// <summary>
        /// SEF_SACL_AUTO_INHERIT
        /// </summary>
        SEF_SACL_AUTO_INHERIT = 0x02,

        /// <summary>
        /// SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT
        /// </summary>
        SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT = 0x04,

        /// <summary>
        /// SEF_AVOID_PRIVILEGE_CHECK
        /// </summary>
        SEF_AVOID_PRIVILEGE_CHECK = 0x08,

        /// <summary>
        /// SEF_AVOID_OWNER_CHECK
        /// </summary>
        SEF_AVOID_OWNER_CHECK = 0x10,

        /// <summary>
        /// SEF_DEFAULT_OWNER_FROM_PARENT
        /// </summary>
        SEF_DEFAULT_OWNER_FROM_PARENT = 0x20,

        /// <summary>
        /// SEF_DEFAULT_GROUP_FROM_PARENT
        /// </summary>
        SEF_DEFAULT_GROUP_FROM_PARENT = 0x40,

        /// <summary>
        /// SEF_MACL_NO_WRITE_UP
        /// </summary>
        SEF_MACL_NO_WRITE_UP = 0x100,

        /// <summary>
        /// SEF_MACL_NO_READ_UP
        /// </summary>
        SEF_MACL_NO_READ_UP = 0x200,

        /// <summary>
        /// SEF_MACL_NO_EXECUTE_UP
        /// </summary>
        SEF_MACL_NO_EXECUTE_UP = 0x400,

        /// <summary>
        /// SEF_AI_USE_EXTRA_PARAMS
        /// </summary>
        SEF_AI_USE_EXTRA_PARAMS = 0x800,

        /// <summary>
        /// SEF_AVOID_OWNER_RESTRICTION
        /// </summary>
        SEF_AVOID_OWNER_RESTRICTION = 0x1000,

        /// <summary>
        /// SEF_FORCE_USER_MODE
        /// </summary>
        SEF_FORCE_USER_MODE = 0x2000,
    }
}

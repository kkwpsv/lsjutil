namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// CopyProgressRoutine callback reasons
    /// </summary>
    public enum CopyProgressRoutineCallbackReasons : uint
    {
        /// <summary>
        /// CALLBACK_CHUNK_FINISHED
        /// </summary>
        CALLBACK_CHUNK_FINISHED = 0x00000000,

        /// <summary>
        /// CALLBACK_STREAM_SWITCH
        /// </summary>
        CALLBACK_STREAM_SWITCH = 0x00000001,
    }
}

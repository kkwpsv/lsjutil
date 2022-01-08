using Lsj.Util.Win32.Callbacks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="LPPROGRESS_ROUTINE"/> Callback Reasons
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nc-winbase-lpprogress_routine"/>
    /// </para>
    /// </summary>
    public enum LPPROGRESS_ROUTINECallbackReasons : uint
    {
        /// <summary>
        /// Another part of the data file was copied.
        /// </summary>
        CALLBACK_CHUNK_FINISHED = 0x00000000,

        /// <summary>
        /// Another stream was created and is about to be copied.
        /// This is the callback reason given when the callback routine is first invoked.
        /// </summary>
        CALLBACK_STREAM_SWITCH = 0x00000001,
    }
}

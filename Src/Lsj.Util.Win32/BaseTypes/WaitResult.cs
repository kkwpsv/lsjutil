using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// Wait Result
    /// </summary>
    public struct WaitResult
    {
        /// <summary>
        /// MAXIMUM_WAIT_OBJECTS
        /// </summary>
        public const int MAXIMUM_WAIT_OBJECTS = 64;

        /// <summary>
        /// WAIT_ABANDONED
        /// </summary>
        public static readonly WaitResult WAIT_ABANDONED = new WaitResult { _value = (uint)NTSTATUS.STATUS_WAIT_0 };

        /// <summary>
        /// WAIT_ABANDONED_0
        /// </summary>
        public static readonly WaitResult WAIT_ABANDONED_0 = new WaitResult { _value = (uint)NTSTATUS.STATUS_ABANDONED_WAIT_0 };

        /// <summary>
        /// WAIT_IO_COMPLETION
        /// </summary>
        public static readonly WaitResult WAIT_IO_COMPLETION = new WaitResult { _value = (uint)NTSTATUS.STATUS_USER_APC };

        /// <summary>
        /// WAIT_OBJECT_0
        /// </summary>
        public static readonly WaitResult WAIT_OBJECT_0 = new WaitResult();

        /// <summary>
        /// WAIT_TIMEOUT
        /// </summary>
        public static readonly WaitResult WAIT_TIMEOUT = new WaitResult { _value = (uint)NTSTATUS.STATUS_TIMEOUT };

        /// <summary>
        /// WAIT_FAILED
        /// </summary>
        public static readonly WaitResult WAIT_FAILED = new WaitResult { _value = 0xFFFFFFFF };

        private uint _value;

        /// <summary>
        /// Is Abandoned
        /// </summary>
        public bool IsAbandoned => _value >= (uint)NTSTATUS.STATUS_ABANDONED_WAIT_0 && _value <= (uint)NTSTATUS.STATUS_ABANDONED_WAIT_63;

        /// <summary>
        /// IsTimeout
        /// </summary>
        public bool IsTimeout => _value == (uint)NTSTATUS.STATUS_TIMEOUT;

        /// <summary>
        /// Is Failed
        /// </summary>
        public bool IsFailed => _value == 0xFFFFFFFF;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(WaitResult val) => val._value;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WaitResult(uint val) => new WaitResult { _value = val };
    }
}

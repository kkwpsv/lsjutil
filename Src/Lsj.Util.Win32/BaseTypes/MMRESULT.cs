using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// MMRESULT
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct MMRESULT
    {
        /// <summary>
        /// MMSYSERR_NOERROR
        /// </summary>
        public static readonly MMRESULT MMSYSERR_NOERROR = new MMRESULT();

        /// <summary>
        /// MMSYSERR_BASE
        /// </summary>
        public static readonly MMRESULT MMSYSERR_BASE = new MMRESULT { _value = 0 };

        /// <summary>
        /// MMSYSERR_ERROR
        /// </summary>
        public static readonly MMRESULT MMSYSERR_ERROR = new MMRESULT { _value = MMSYSERR_BASE + 1 };

        /// <summary>
        /// MMSYSERR_BADDEVICEID
        /// </summary>
        public static readonly MMRESULT MMSYSERR_BADDEVICEID = new MMRESULT { _value = MMSYSERR_BASE + 2 };

        /// <summary>
        /// MMSYSERR_NOTENABLED
        /// </summary>
        public static readonly MMRESULT MMSYSERR_NOTENABLED = new MMRESULT { _value = MMSYSERR_BASE + 3 };

        /// <summary>
        /// MMSYSERR_ALLOCATED
        /// </summary>
        public static readonly MMRESULT MMSYSERR_ALLOCATED = new MMRESULT { _value = MMSYSERR_BASE + 4 };

        /// <summary>
        /// MMSYSERR_INVALHANDLE
        /// </summary>
        public static readonly MMRESULT MMSYSERR_INVALHANDLE = new MMRESULT { _value = MMSYSERR_BASE + 5 };

        /// <summary>
        /// MMSYSERR_NODRIVER
        /// </summary>
        public static readonly MMRESULT MMSYSERR_NODRIVER = new MMRESULT { _value = MMSYSERR_BASE + 6 };

        /// <summary>
        /// MMSYSERR_NOMEM
        /// </summary>
        public static readonly MMRESULT MMSYSERR_NOMEM = new MMRESULT { _value = MMSYSERR_NOMEM + 7 };

        /// <summary>
        /// MMSYSERR_NOTSUPPORTED
        /// </summary>
        public static readonly MMRESULT MMSYSERR_NOTSUPPORTED = new MMRESULT { _value = MMSYSERR_BASE + 8 };

        /// <summary>
        /// MMSYSERR_BADERRNUM
        /// </summary>
        public static readonly MMRESULT MMSYSERR_BADERRNUM = new MMRESULT { _value = MMSYSERR_BADERRNUM + 9 };

        /// <summary>
        /// MMSYSERR_INVALFLAG
        /// </summary>
        public static readonly MMRESULT MMSYSERR_INVALFLAG = new MMRESULT { _value = MMSYSERR_INVALFLAG + 10 };

        /// <summary>
        /// MMSYSERR_INVALPARAM
        /// </summary>
        public static readonly MMRESULT MMSYSERR_INVALPARAM = new MMRESULT { _value = MMSYSERR_INVALPARAM + 11 };

        /// <summary>
        /// MMSYSERR_HANDLEBUSY
        /// </summary>
        public static readonly MMRESULT MMSYSERR_HANDLEBUSY = new MMRESULT { _value = MMSYSERR_HANDLEBUSY + 12 };

        /// <summary>
        /// MMSYSERR_INVALIDALIAS
        /// </summary>
        public static readonly MMRESULT MMSYSERR_INVALIDALIAS = new MMRESULT { _value = MMSYSERR_INVALIDALIAS + 13 };

        /// <summary>
        /// MMSYSERR_BADDB
        /// </summary>
        public static readonly MMRESULT MMSYSERR_BADDB = new MMRESULT { _value = MMSYSERR_BADDB + 14 };

        /// <summary>
        /// MMSYSERR_KEYNOTFOUND
        /// </summary>
        public static readonly MMRESULT MMSYSERR_KEYNOTFOUND = new MMRESULT { _value = MMSYSERR_KEYNOTFOUND + 15 };

        /// <summary>
        /// MMSYSERR_READERROR
        /// </summary>
        public static readonly MMRESULT MMSYSERR_READERROR = new MMRESULT { _value = MMSYSERR_READERROR + 16 };

        /// <summary>
        /// MMSYSERR_WRITEERROR
        /// </summary>
        public static readonly MMRESULT MMSYSERR_WRITEERROR = new MMRESULT { _value = MMSYSERR_WRITEERROR + 17 };

        /// <summary>
        /// MMSYSERR_DELETEERROR
        /// </summary>
        public static readonly MMRESULT MMSYSERR_DELETEERROR = new MMRESULT { _value = MMSYSERR_DELETEERROR + 18 };

        /// <summary>
        /// MMSYSERR_VALNOTFOUND
        /// </summary>
        public static readonly MMRESULT MMSYSERR_VALNOTFOUND = new MMRESULT { _value = MMSYSERR_BASE + 19 };

        /// <summary>
        /// MMSYSERR_NODRIVERCB
        /// </summary>
        public static readonly MMRESULT MMSYSERR_NODRIVERCB = new MMRESULT { _value = MMSYSERR_BASE + 20 };

        /// <summary>
        /// MMSYSERR_MOREDATA
        /// </summary>
        public static readonly MMRESULT MMSYSERR_MOREDATA = new MMRESULT { _value = MMSYSERR_BASE + 21 };

        /// <summary>
        /// MMSYSERR_LASTERROR
        /// </summary>
        public static readonly MMRESULT MMSYSERR_LASTERROR = new MMRESULT { _value = MMSYSERR_BASE + 21 };

        /// <summary>
        /// TIMERR_BASE
        /// </summary>
        public static readonly MMRESULT TIMERR_BASE = new MMRESULT { _value = 96 };

        /// <summary>
        /// TIMERR_NOCANDO
        /// </summary>
        public static readonly MMRESULT TIMERR_NOCANDO = new MMRESULT { _value = TIMERR_BASE + 1 };

        /// <summary>
        /// TIMERR_NOERROR
        /// </summary>
        public static readonly MMRESULT TIMERR_NOERROR = new MMRESULT();

        /// <summary>
        /// WAVERR_BADFORMAT
        /// </summary>
        public static readonly MMRESULT WAVERR_BADFORMAT = new MMRESULT { _value = MMSYSERR_BASE + 0 };

        /// <summary>
        /// WAVERR_STILLPLAYING
        /// </summary>
        public static readonly MMRESULT WAVERR_STILLPLAYING = new MMRESULT { _value = MMSYSERR_BASE + 1 };

        /// <summary>
        /// WAVERR_UNPREPARED
        /// </summary>
        public static readonly MMRESULT WAVERR_UNPREPARED = new MMRESULT { _value = MMSYSERR_BASE + 2 };

        /// <summary>
        /// WAVERR_SYNC
        /// </summary>
        public static readonly MMRESULT WAVERR_SYNC = new MMRESULT { _value = MMSYSERR_BASE + 3 };

        /// <summary>
        /// WAVERR_LASTERROR
        /// </summary>
        public static readonly MMRESULT WAVERR_LASTERROR = new MMRESULT { _value = MMSYSERR_BASE + 3 };

        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(MMRESULT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator MMRESULT(uint val) => new MMRESULT { _value = val };
    }
}

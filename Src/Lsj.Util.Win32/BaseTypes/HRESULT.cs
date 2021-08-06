using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// An <see cref="HRESULT"/> is a 32-bit value that is used to describe an error or warning and contains the following fields:
    /// A 1-bit code that indicates severity, where 0 represents success and 1 represents failure.
    /// A 4-bit reserved value.
    /// An 11-bit code, also known as a facility code, that indicates responsibility for the error or warning.
    /// A 16-bit code that describes the error or warning.
    /// For details on <see cref="HRESULT"/> values, see [MS-ERREF].
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/a9046ed2-bfb2-4d56-a719-2824afce59ac"/>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/learnwin32/error-handling-in-com"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct HRESULT
    {
        /// <summary>
        /// CACHE_E_NOCACHE_UPDATED
        /// </summary>
        public static readonly HRESULT CACHE_E_NOCACHE_UPDATED = new HRESULT { _value = unchecked((int)0x80040170) };

        /// <summary>
        /// CACHE_S_FORMATETC_NOTSUPPORTED
        /// </summary>
        public static readonly HRESULT CACHE_S_FORMATETC_NOTSUPPORTED = new HRESULT { _value = 0x00040170 };

        /// <summary>
        /// CACHE_S_SAMECACHE
        /// </summary>
        public static readonly HRESULT CACHE_S_SAMECACHE = new HRESULT { _value = 0x00040171 };

        /// <summary>
        /// CACHE_S_SOMECACHES_NOTUPDATED
        /// </summary>
        public static readonly HRESULT CACHE_S_SOMECACHES_NOTUPDATED = new HRESULT { _value = 0x00040172 };

        /// <summary>
        /// CLASS_E_NOAGGREGATION
        /// </summary>
        public static readonly HRESULT CLASS_E_NOAGGREGATION = new HRESULT { _value = unchecked((int)0x80040110) };

        /// <summary>
        /// CO_E_ALREADYINITIALIZED
        /// </summary>
        public static readonly HRESULT CO_E_ALREADYINITIALIZED = new HRESULT { _value = unchecked((int)0x800401F1) };

        /// <summary>
        /// CO_E_APPDIDNTREG
        /// </summary>
        public static readonly HRESULT CO_E_APPDIDNTREG = new HRESULT { _value = unchecked((int)0x800401FE) };

        /// <summary>
        /// CO_E_APPNOTFOUND
        /// </summary>
        public static readonly HRESULT CO_E_APPNOTFOUND = new HRESULT { _value = unchecked((int)0x800401F5) };

        /// <summary>
        /// CO_E_CLASSSTRING
        /// </summary>
        public static readonly HRESULT CO_E_CLASSSTRING = new HRESULT { _value = unchecked((int)0x800401F3) };

        /// <summary>
        /// CO_E_DLLNOTFOUND
        /// </summary>
        public static readonly HRESULT CO_E_DLLNOTFOUND = new HRESULT { _value = unchecked((int)0x800401F8) };

        /// <summary>
        /// CO_E_ERRORINDLL
        /// </summary>
        public static readonly HRESULT CO_E_ERRORINDLL = new HRESULT { _value = unchecked((int)0x800401F9) };

        /// <summary>
        /// CO_E_NOTINITIALIZED
        /// </summary>
        public static readonly HRESULT CO_E_NOTINITIALIZED = new HRESULT { _value = unchecked((int)0x800401F0) };

        /// <summary>
        /// CO_E_OBJNOTCONNECTED
        /// </summary>
        public static readonly HRESULT CO_E_OBJNOTCONNECTED = new HRESULT { _value = unchecked((int)0x800401FD) };

        /// <summary>
        /// CO_S_NOTALLINTERFACES
        /// </summary>
        public static readonly HRESULT CO_S_NOTALLINTERFACES = new HRESULT { _value = 0x00080012 };

        /// <summary>
        /// DATA_S_SAMEFORMATETC
        /// </summary>
        public static readonly HRESULT DATA_S_SAMEFORMATETC = new HRESULT { _value = 0x00040130 };

        /// <summary>
        /// DV_E_CLIPFORMAT
        /// </summary>
        public static readonly HRESULT DV_E_CLIPFORMAT = new HRESULT { _value = unchecked((int)0x8004006A) };

        /// <summary>
        /// DV_E_DVASPECT
        /// </summary>
        public static readonly HRESULT DV_E_DVASPECT = new HRESULT { _value = unchecked((int)0x8004006B) };

        /// <summary>
        /// DV_E_DVTARGETDEVICE
        /// </summary>
        public static readonly HRESULT DV_E_DVTARGETDEVICE = new HRESULT { _value = unchecked((int)0x80040065) };

        /// <summary>
        /// DV_E_FORMATETC
        /// </summary>
        public static readonly HRESULT DV_E_FORMATETC = new HRESULT { _value = unchecked((int)0x80040064) };

        /// <summary>
        /// DV_E_LINDEX
        /// </summary>
        public static readonly HRESULT DV_E_LINDEX = new HRESULT { _value = unchecked((int)0x80040068) };

        /// <summary>
        /// DV_E_TYMED
        /// </summary>
        public static readonly HRESULT DV_E_TYMED = new HRESULT { _value = unchecked((int)0x80040069) };

        /// <summary>
        /// DWM_E_COMPOSITIONDISABLED
        /// </summary>
        public static readonly HRESULT DWM_E_COMPOSITIONDISABLED = new HRESULT { _value = unchecked((int)0x80263001) };

        /// <summary>
        /// Access denied.
        /// </summary>
        public static readonly HRESULT E_ACCESSDENIED = new HRESULT { _value = unchecked((int)0x80070005) };

        /// <summary>
        /// Unspecified error.
        /// </summary>
        public static readonly HRESULT E_FAIL = new HRESULT { _value = unchecked((int)0x80004005) };

        /// <summary>
        /// E_HANDLE
        /// </summary>
        public static readonly HRESULT E_HANDLE = new HRESULT { _value = unchecked((int)0x80070006) };

        /// <summary>
        /// Invalid parameter value.
        /// </summary>
        public static readonly HRESULT E_INVALIDARG = new HRESULT { _value = unchecked((int)0x80070057) };

        /// <summary>
        /// E_NOINTERFACE
        /// </summary>
        public static readonly HRESULT E_NOINTERFACE = new HRESULT { _value = unchecked((int)0x80004002) };

        /// <summary>
        /// E_NOTIMPL
        /// </summary>
        public static readonly HRESULT E_NOTIMPL = new HRESULT { _value = unchecked((int)0x80004001) };

        /// <summary>
        /// Out of memory.
        /// </summary>
        public static readonly HRESULT E_OUTOFMEMORY = new HRESULT { _value = unchecked((int)0x8007000E) };

        /// <summary>
        /// E_PENDING
        /// </summary>
        public static readonly HRESULT E_PENDING = new HRESULT { _value = unchecked((int)0x8000000A) };

        /// <summary>
        /// <see cref="NULL"/> was passed incorrectly for a pointer value.
        /// </summary>
        public static readonly HRESULT E_POINTER = new HRESULT { _value = unchecked((int)0x80004003) };

        /// <summary>
        /// Unexpected condition.
        /// </summary>
        public static readonly HRESULT E_UNEXPECTED = new HRESULT { _value = unchecked((int)0x8000FFFF) };

        /// <summary>
        /// E_UNSPEC
        /// </summary>
        public static readonly HRESULT E_UNSPEC = E_FAIL;

        /// <summary>
        /// MK_E_NOOBJECT
        /// </summary>
        public static readonly HRESULT MK_E_NOOBJECT = new HRESULT { _value = unchecked((int)0x800401E5) };

        /// <summary>
        /// MK_E_CONNECTMANUALLY
        /// </summary>
        public static readonly HRESULT MK_E_CONNECTMANUALLY = new HRESULT { _value = unchecked((int)0x800401E0) };

        /// <summary>
        /// MK_E_EXCEEDEDDEADLINE
        /// </summary>
        public static readonly HRESULT MK_E_EXCEEDEDDEADLINE = new HRESULT { _value = unchecked((int)0x800401E1) };

        /// <summary>
        /// MK_E_INTERMEDIATEINTERFACENOTSUPPORTED
        /// </summary>
        public static readonly HRESULT MK_E_INTERMEDIATEINTERFACENOTSUPPORTED = new HRESULT { _value = unchecked((int)0x800401E7) };

        /// <summary>
        /// MK_E_NEEDGENERIC
        /// </summary>
        public static readonly HRESULT MK_E_NEEDGENERIC = new HRESULT { _value = unchecked((int)0x800401E2) };

        /// <summary>
        /// MK_E_NOTBINDABLE
        /// </summary>
        public static readonly HRESULT MK_E_NOTBINDABLE = new HRESULT { _value = unchecked((int)0x800401E8) };

        /// <summary>
        /// MK_E_NOTBOUND
        /// </summary>
        public static readonly HRESULT MK_E_NOTBOUND = new HRESULT { _value = unchecked((int)0x800401E9) };

        /// <summary>
        /// MK_E_NOINVERSE
        /// </summary>
        public static readonly HRESULT MK_E_NOINVERSE = new HRESULT { _value = unchecked((int)0x800401EC) };

        /// <summary>
        /// MK_E_NOPREFIX
        /// </summary>
        public static readonly HRESULT MK_E_NOPREFIX = new HRESULT { _value = unchecked((int)0x800401EE) };

        /// <summary>
        /// MK_E_MUSTBOTHERUSER
        /// </summary>
        public static readonly HRESULT MK_E_MUSTBOTHERUSER = new HRESULT { _value = unchecked((int)0x800401EB) };

        /// <summary>
        /// MK_E_NOSTORAGE
        /// </summary>
        public static readonly HRESULT MK_E_NOSTORAGE = new HRESULT { _value = unchecked((int)0x800401ED) };

        /// <summary>
        /// MK_E_SYNTAX
        /// </summary>
        public static readonly HRESULT MK_E_SYNTAX = new HRESULT { _value = unchecked((int)0x800401E4) };

        /// <summary>
        /// MK_E_UNAVAILABLE
        /// </summary>
        public static readonly HRESULT MK_E_UNAVAILABLE = new HRESULT { _value = unchecked((int)0x800401E3) };

        /// <summary>
        /// MK_S_HIM
        /// </summary>
        public static readonly HRESULT MK_S_HIM = new HRESULT { _value = 0x000401E5 };

        /// <summary>
        /// MK_S_ME
        /// </summary>
        public static readonly HRESULT MK_S_ME = new HRESULT { _value = 0x000401E4 };

        /// <summary>
        /// MK_S_REDUCED_TO_SELF
        /// </summary>
        public static readonly HRESULT MK_S_REDUCED_TO_SELF = new HRESULT { _value = 0x000401E2 };

        /// <summary>
        /// MK_S_US
        /// </summary>
        public static readonly HRESULT MK_S_US = new HRESULT { _value = 0x000401E6 };

        /// <summary>
        /// OLEOBJ_E_NOVERBS
        /// </summary>
        public static readonly HRESULT OLEOBJ_E_NOVERBS = new HRESULT { _value = unchecked((int)0x80040180) };

        /// <summary>
        /// OLEOBJ_S_CANNOT_DOVERB_NOW
        /// </summary>
        public static readonly HRESULT OLEOBJ_S_CANNOT_DOVERB_NOW = new HRESULT { _value = unchecked((int)0x80040181) };

        /// <summary>
        /// OLEOBJ_S_INVALIDHWND
        /// </summary>
        public static readonly HRESULT OLEOBJ_S_INVALIDHWND = new HRESULT { _value = unchecked((int)0x80040182) };

        /// <summary>
        /// OLEOBJ_S_INVALIDVERB
        /// </summary>
        public static readonly HRESULT OLEOBJ_S_INVALIDVERB = new HRESULT { _value = unchecked((int)0x80040180) };

        /// <summary>
        /// OLE_E_ADVISENOTSUPPORTED
        /// </summary>
        public static readonly HRESULT OLE_E_ADVISENOTSUPPORTED = new HRESULT { _value = unchecked((int)0x80040003) };

        /// <summary>
        /// OLE_E_BLANK
        /// </summary>
        public static readonly HRESULT OLE_E_BLANK = new HRESULT { _value = unchecked((int)0x80040007) };

        /// <summary>
        /// OLE_E_CANT_BINDTOSOURCE
        /// </summary>
        public static readonly HRESULT OLE_E_CANT_BINDTOSOURCE = new HRESULT { _value = unchecked((int)0x8004000A) };

        /// <summary>
        /// OLE_E_CLASSDIFF
        /// </summary>
        public static readonly HRESULT OLE_E_CLASSDIFF = new HRESULT { _value = unchecked((int)0x80040008) };

        /// <summary>
        /// OLE_E_INVALIDRECT
        /// </summary>
        public static readonly HRESULT OLE_E_INVALIDRECT = new HRESULT { _value = unchecked((int)0x8004000D) };

        /// <summary>
        /// OLE_E_NOCONNECTION
        /// </summary>
        public static readonly HRESULT OLE_E_NOCONNECTION = new HRESULT { _value = unchecked((int)0x80040004) };

        /// <summary>
        /// OLE_E_NOTRUNNING
        /// </summary>
        public static readonly HRESULT OLE_E_NOTRUNNING = new HRESULT { _value = unchecked((int)0x80040005) };

        /// <summary>
        /// OLE_E_NOT_INPLACEACTIVE
        /// </summary>
        public static readonly HRESULT OLE_E_NOT_INPLACEACTIVE = new HRESULT { _value = unchecked((int)0x80040010) };

        /// <summary>
        /// OLE_E_PROMPTSAVECANCELLED
        /// </summary>
        public static readonly HRESULT OLE_E_PROMPTSAVECANCELLED = new HRESULT { _value = unchecked((int)0x8004000C) };

        /// <summary>
        /// OLE_E_STATIC
        /// </summary>
        public static readonly HRESULT OLE_E_STATIC = new HRESULT { _value = unchecked((int)0x8004000B) };

        /// <summary>
        /// OLE_E_WRONGCOMPOBJ
        /// </summary>
        public static readonly HRESULT OLE_E_WRONGCOMPOBJ = new HRESULT { _value = unchecked((int)0x8004000E) };

        /// <summary>
        /// OLE_S_USEREG
        /// </summary>
        public static readonly HRESULT OLE_S_USEREG = new HRESULT { _value = 0x00040000 };

        /// <summary>
        /// REGDB_E_CLASSNOTREG
        /// </summary>
        public static readonly HRESULT REGDB_E_CLASSNOTREG = new HRESULT { _value = unchecked((int)0x80040154) };

        /// <summary>
        /// REGDB_E_READREGDB
        /// </summary>
        public static readonly HRESULT REGDB_E_READREGDB = new HRESULT { _value = unchecked((int)0x80040150) };

        /// <summary>
        /// REGDB_E_WRITEREGDB
        /// </summary>
        public static readonly HRESULT REGDB_E_WRITEREGDB = new HRESULT { _value = unchecked((int)0x80040151) };

        /// <summary>
        /// RPC_E_CHANGED_MODE
        /// </summary>
        public static readonly HRESULT RPC_E_CHANGED_MODE = new HRESULT { _value = unchecked((int)0x80010106) };

        /// <summary>
        /// RPC_E_DISCONNECTED
        /// </summary>
        public static readonly HRESULT RPC_E_DISCONNECTED = new HRESULT { _value = unchecked((int)0x80010108) };

        /// <summary>
        /// RPC_E_NO_GOOD_SECURITY_PACKAGES
        /// </summary>
        public static readonly HRESULT RPC_E_NO_GOOD_SECURITY_PACKAGES = new HRESULT { _value = unchecked((int)0x8001011A) };

        /// <summary>
        /// RPC_E_TOO_LATE
        /// </summary>
        public static readonly HRESULT RPC_E_TOO_LATE = new HRESULT { _value = unchecked((int)0x80010119) };

        /// <summary>
        /// STG_E_ACCESSDENIED
        /// </summary>
        public static readonly HRESULT STG_E_ACCESSDENIED = new HRESULT { _value = unchecked((int)0x80030005) };

        /// <summary>
        /// STG_E_CANTSAVE
        /// </summary>
        public static readonly HRESULT STG_E_CANTSAVE = new HRESULT { _value = unchecked((int)0x80030103) };

        /// <summary>
        /// STG_E_FILEALREADYEXISTS
        /// </summary>
        public static readonly HRESULT STG_E_FILEALREADYEXISTS = new HRESULT { _value = unchecked((int)0x80030050) };

        /// <summary>
        /// STG_E_FILENOTFOUND
        /// </summary>
        public static readonly HRESULT STG_E_FILENOTFOUND = new HRESULT { _value = unchecked((int)0x80030002) };

        /// <summary>
        /// STG_E_INVALIDFLAG
        /// </summary>
        public static readonly HRESULT STG_E_INVALIDFLAG = new HRESULT { _value = unchecked((int)0x800300FF) };

        /// <summary>
        /// STG_E_INVALIDFUNCTION
        /// </summary>
        public static readonly HRESULT STG_E_INVALIDFUNCTION = new HRESULT { _value = unchecked((int)0x80030001) };

        /// <summary>
        /// STG_E_INVALIDPARAMETER
        /// </summary>
        public static readonly HRESULT STG_E_INVALIDPARAMETER = new HRESULT { _value = unchecked((int)0x80030057) };

        /// <summary>
        /// STG_E_INVALIDPOINTER
        /// </summary>
        public static readonly HRESULT STG_E_INVALIDPOINTER = new HRESULT { _value = unchecked((int)0x80030009) };

        /// <summary>
        /// STG_E_MEDIUMFULL
        /// </summary>
        public static readonly HRESULT STG_E_MEDIUMFULL = new HRESULT { _value = unchecked((int)0x80030070) };

        /// <summary>
        /// STG_E_NOTCURRENT
        /// </summary>
        public static readonly HRESULT STG_E_NOTCURRENT = new HRESULT { _value = unchecked((int)0x80030101) };

        /// <summary>
        /// STG_E_REVERTED
        /// </summary>
        public static readonly HRESULT STG_E_REVERTED = new HRESULT { _value = unchecked((int)0x80030102) };

        /// <summary>
        /// Success.
        /// </summary>
        public static readonly HRESULT S_OK = new HRESULT();

        /// <summary>
        /// Success.
        /// </summary>
        public static readonly HRESULT S_FALSE = new HRESULT { _value = 0x1 };

        /// <summary>
        /// TYPE_E_ELEMENTNOTFOUND
        /// </summary>
        public static readonly HRESULT TYPE_E_ELEMENTNOTFOUND = new HRESULT { _value = unchecked((int)0x8002802B) };

        /// <summary>
        /// VIEW_E_DRAW
        /// </summary>
        public static readonly HRESULT VIEW_E_DRAW = new HRESULT { _value = unchecked((int)0x80040140) };

        /// <summary>
        /// VIEW_S_ALREADY_FROZEN
        /// </summary>
        public static readonly HRESULT VIEW_S_ALREADY_FROZEN = new HRESULT { _value = 0x00040140 };

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// Is Succeed
        /// </summary>
        public bool Succeed => _value >= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator bool(HRESULT val) => val.Succeed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(HRESULT val) => unchecked((uint)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(HRESULT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HRESULT(int val) => new HRESULT { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HRESULT(uint val) => new HRESULT { _value = unchecked((int)val) };

        /// <summary>
        /// <para>
        /// Extracts the code portion of the specified <see cref="HRESULT"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winerror/nf-winerror-hresult_code"/>
        /// </para>
        /// </summary>
        /// <param name="hr">
        /// The <see cref="HRESULT"/> value.
        /// </param>
        /// <returns></returns>
        public static int HRESULT_CODE(HRESULT hr) => hr._value & 0xff;
    }
}

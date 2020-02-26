using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Facility Codes
    /// </summary>
    public enum FacilityCodes
    {
        /// <summary>
        /// FACILITY_NULL
        /// </summary>
        FACILITY_NULL = 0,

        /// <summary>
        /// FACILITY_RPC
        /// </summary>
        FACILITY_RPC = 1,

        /// <summary>
        /// FACILITY_DISPATCH
        /// </summary>
        FACILITY_DISPATCH = 2,

        /// <summary>
        /// FACILITY_STORAGE
        /// </summary>
        FACILITY_STORAGE = 3,

        /// <summary>
        /// FACILITY_ITF
        /// </summary>
        FACILITY_ITF = 4,

        /// <summary>
        /// FACILITY_WIN32
        /// </summary>
        FACILITY_WIN32 = 7,

        /// <summary>
        /// FACILITY_WINDOWS
        /// </summary>
        FACILITY_WINDOWS = 8,

        /// <summary>
        /// FACILITY_SSPI
        /// </summary>
        FACILITY_SSPI = 9,

        /// <summary>
        ///FACILITY_SECURITY
        /// </summary>
        FACILITY_SECURITY = 9,

        /// <summary>
        /// FACILITY_CONTROL
        /// </summary>
        FACILITY_CONTROL = 10,

        /// <summary>
        ///FACILITY_CERT
        /// </summary>
        FACILITY_CERT = 11,

        /// <summary>
        /// FACILITY_INTERNET
        /// </summary>
        FACILITY_INTERNET = 12,

        /// <summary>
        /// FACILITY_MEDIASERVER
        /// </summary>
        FACILITY_MEDIASERVER = 13,

        /// <summary>
        /// FACILITY_MSMQ
        /// </summary>
        FACILITY_MSMQ = 14,

        /// <summary>
        /// FACILITY_SETUPAPI
        /// </summary>
        FACILITY_SETUPAPI = 15,

        /// <summary>
        /// FACILITY_SCARD
        /// </summary>
        FACILITY_SCARD = 16,

        /// <summary>
        /// FACILITY_COMPLUS
        /// </summary>
        FACILITY_COMPLUS = 17,

        /// <summary>
        /// FACILITY_AAF
        /// </summary>
        FACILITY_AAF = 18,

        /// <summary>
        /// FACILITY_URT
        /// </summary>
        FACILITY_URT = 19,

        /// <summary>
        /// FACILITY_ACS
        /// </summary>
        FACILITY_ACS = 20,

        /// <summary>
        /// FACILITY_DPLAY
        /// </summary>
        FACILITY_DPLAY = 21,

        /// <summary>
        /// FACILITY_UMI
        /// </summary>
        FACILITY_UMI = 22,

        /// <summary>
        /// FACILITY_SXS
        /// </summary>
        FACILITY_SXS = 23,

        /// <summary>
        /// FACILITY_WINDOWS_CE
        /// </summary>
        FACILITY_WINDOWS_CE = 24,

        /// <summary>
        /// FACILITY_HTTP
        /// </summary>
        FACILITY_HTTP = 25,

        /// <summary>
        /// FACILITY_USERMODE_COMMONLOG
        /// </summary>
        FACILITY_USERMODE_COMMONLOG = 26,

        /// <summary>
        /// FACILITY_WER
        /// </summary>
        FACILITY_WER = 27,

        /// <summary>
        /// FACILITY_USERMODE_FILTER_MANAGER
        /// </summary>
        FACILITY_USERMODE_FILTER_MANAGER = 31,

        /// <summary>
        /// FACILITY_BACKGROUNDCOPY
        /// </summary>
        FACILITY_BACKGROUNDCOPY = 32,

        /// <summary>
        /// FACILITY_CONFIGURATION
        /// </summary>
        FACILITY_CONFIGURATION = 33,

        /// <summary>
        /// FACILITY_WIA
        /// </summary>
        FACILITY_WIA = 33,

        /// <summary>
        /// FACILITY_STATE_MANAGEMENT
        /// </summary>
        FACILITY_STATE_MANAGEMENT = 34,

        /// <summary>
        /// FACILITY_METADIRECTORY
        /// </summary>
        FACILITY_METADIRECTORY = 35,

        /// <summary>
        /// FACILITY_WINDOWSUPDATE
        /// </summary>
        FACILITY_WINDOWSUPDATE = 36,

        /// <summary>
        /// FACILITY_DIRECTORYSERVICE
        /// </summary>
        FACILITY_DIRECTORYSERVICE = 37,

        /// <summary>
        /// FACILITY_GRAPHICS
        /// </summary>
        FACILITY_GRAPHICS = 38,

        /// <summary>
        /// FACILITY_SHELL
        /// </summary>
        FACILITY_SHELL = 39,

        /// <summary>
        /// FACILITY_NAP
        /// </summary>
        FACILITY_NAP = 39,

        /// <summary>
        /// FACILITY_TPM_SERVICES
        /// </summary>
        FACILITY_TPM_SERVICES = 40,

        /// <summary>
        /// FACILITY_TPM_SOFTWARE
        /// </summary>
        FACILITY_TPM_SOFTWARE = 41,

        /// <summary>
        /// FACILITY_UI
        /// </summary>
        FACILITY_UI = 42,

        /// <summary>
        /// FACILITY_XAML
        /// </summary>
        FACILITY_XAML = 43,

        /// <summary>
        /// FACILITY_ACTION_QUEUE
        /// </summary>
        FACILITY_ACTION_QUEUE = 44,

        /// <summary>
        /// FACILITY_PLA
        /// </summary>
        FACILITY_PLA = 48,

        /// <summary>
        /// FACILITY_WINDOWS_SETUP
        /// </summary>
        FACILITY_WINDOWS_SETUP = 48,

        /// <summary>
        /// FACILITY_FVE
        /// </summary>
        FACILITY_FVE = 49,

        /// <summary>
        /// FACILITY_FWP
        /// </summary>
        FACILITY_FWP = 50,

        /// <summary>
        /// FACILITY_WINRM
        /// </summary>
        FACILITY_WINRM = 51,

        /// <summary>
        /// FACILITY_NDIS
        /// </summary>
        FACILITY_NDIS = 52,

        /// <summary>
        /// FACILITY_USERMODE_HYPERVISOR
        /// </summary>
        FACILITY_USERMODE_HYPERVISOR = 53,

        /// <summary>
        /// FACILITY_CMI
        /// </summary>
        FACILITY_CMI = 54,

        /// <summary>
        /// FACILITY_USERMODE_VIRTUALIZATION
        /// </summary>
        FACILITY_USERMODE_VIRTUALIZATION = 55,

        /// <summary>
        /// FACILITY_USERMODE_VOLMGR
        /// </summary>
        FACILITY_USERMODE_VOLMGR = 56,

        /// <summary>
        /// FACILITY_BCD
        /// </summary>
        FACILITY_BCD = 57,

        /// <summary>
        /// FACILITY_USERMODE_VHD
        /// </summary>
        FACILITY_USERMODE_VHD = 58,

        /// <summary>
        /// FACILITY_USERMODE_HNS
        /// </summary>
        FACILITY_USERMODE_HNS = 59,

        /// <summary>
        /// FACILITY_SDIAG
        /// </summary>
        FACILITY_SDIAG = 60,

        /// <summary>
        /// FACILITY_WEBSERVICES
        /// </summary>
        FACILITY_WEBSERVICES = 61,

        /// <summary>
        /// FACILITY_WINPE
        /// </summary>
        FACILITY_WINPE = 61,

        /// <summary>
        /// FACILITY_WPN
        /// </summary>
        FACILITY_WPN = 62,

        /// <summary>
        /// FACILITY_WINDOWS_STORE
        /// </summary>
        FACILITY_WINDOWS_STORE = 63,

        /// <summary>
        /// FACILITY_INPUT
        /// </summary>
        FACILITY_INPUT = 64,

        /// <summary>
        /// FACILITY_EAP
        /// </summary>
        FACILITY_EAP = 66,

        /// <summary>
        /// FACILITY_WINDOWS_DEFENDER
        /// </summary>
        FACILITY_WINDOWS_DEFENDER = 80,

        /// <summary>
        /// FACILITY_OPC
        /// </summary>
        FACILITY_OPC = 81,

        /// <summary>
        /// FACILITY_XPS
        /// </summary>
        FACILITY_XPS = 82,

        /// <summary>
        /// FACILITY_MBN
        /// </summary>
        FACILITY_MBN = 84,

        /// <summary>
        /// FACILITY_POWERSHELL
        /// </summary>
        FACILITY_POWERSHELL = 84,

        /// <summary>
        /// FACILITY_RAS
        /// </summary>
        FACILITY_RAS = 83,

        /// <summary>
        /// FACILITY_P2P_INT
        /// </summary>
        FACILITY_P2P_INT = 98,

        /// <summary>
        /// FACILITY_P2P
        /// </summary>
        FACILITY_P2P = 99,

        /// <summary>
        /// FACILITY_DAF
        /// </summary>
        FACILITY_DAF = 100,

        /// <summary>
        /// FACILITY_BLUETOOTH_ATT
        /// </summary>
        FACILITY_BLUETOOTH_ATT = 101,

        /// <summary>
        /// FACILITY_AUDIO
        /// </summary>
        FACILITY_AUDIO = 102,

        /// <summary>
        /// FACILITY_STATEREPOSITORY
        /// </summary>
        FACILITY_STATEREPOSITORY = 103,

        /// <summary>
        /// FACILITY_VISUALCPP
        /// </summary>
        FACILITY_VISUALCPP = 109,

        /// <summary>
        /// FACILITY_SCRIPT
        /// </summary>
        FACILITY_SCRIPT = 112,

        /// <summary>
        /// FACILITY_PARSE
        /// </summary>
        FACILITY_PARSE = 113,

        /// <summary>
        /// FACILITY_BLB
        /// </summary>
        FACILITY_BLB = 120,

        /// <summary>
        /// FACILITY_BLB_CLI
        /// </summary>
        FACILITY_BLB_CLI = 121,

        /// <summary>
        /// FACILITY_WSBAPP
        /// </summary>
        FACILITY_WSBAPP = 122,

        /// <summary>
        /// FACILITY_BLBUI
        /// </summary>
        FACILITY_BLBUI = 128,

        /// <summary>
        /// FACILITY_USN
        /// </summary>
        FACILITY_USN = 129,

        /// <summary>
        /// FACILITY_USERMODE_VOLSNAP
        /// </summary>
        FACILITY_USERMODE_VOLSNAP = 130,

        /// <summary>
        /// FACILITY_TIERING
        /// </summary>
        FACILITY_TIERING = 131,

        /// <summary>
        /// FACILITY_WSB_ONLINE
        /// </summary>
        FACILITY_WSB_ONLINE = 133,

        /// <summary>
        /// FACILITY_ONLINE_ID
        /// </summary>
        FACILITY_ONLINE_ID = 134,

        /// <summary>
        /// FACILITY_DEVICE_UPDATE_AGENT
        /// </summary>
        FACILITY_DEVICE_UPDATE_AGENT = 135,

        /// <summary>
        /// FACILITY_DRVSERVICING
        /// </summary>
        FACILITY_DRVSERVICING = 136,

        /// <summary>
        /// FACILITY_DLS
        /// </summary>
        FACILITY_DLS = 153,

        /// <summary>
        /// FACILITY_DELIVERY_OPTIMIZATION
        /// </summary>
        FACILITY_DELIVERY_OPTIMIZATION = 208,

        /// <summary>
        /// FACILITY_USERMODE_SPACES
        /// </summary>
        FACILITY_USERMODE_SPACES = 231,

        /// <summary>
        /// FACILITY_USER_MODE_SECURITY_CORE
        /// </summary>
        FACILITY_USER_MODE_SECURITY_CORE = 232,

        /// <summary>
        /// FACILITY_USERMODE_LICENSING
        /// </summary>
        FACILITY_USERMODE_LICENSING = 234,

        /// <summary>
        /// FACILITY_SOS
        /// </summary>
        FACILITY_SOS = 160,

        /// <summary>
        /// FACILITY_DEBUGGERS
        /// </summary>
        FACILITY_DEBUGGERS = 176,

        /// <summary>
        /// FACILITY_SPP
        /// </summary>
        FACILITY_SPP = 256,

        /// <summary>
        /// FACILITY_RESTORE
        /// </summary>
        FACILITY_RESTORE = 256,

        /// <summary>
        /// FACILITY_DMSERVER
        /// </summary>
        FACILITY_DMSERVER = 256,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_SERVER
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_SERVER = 257,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_IMAGING
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_IMAGING = 258,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_MANAGEMENT
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_MANAGEMENT = 259,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_UTIL
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_UTIL = 260,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_BINLSVC
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_BINLSVC = 261,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_PXE
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_PXE = 263,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_TFTP
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_TFTP = 264,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_TRANSPORT_MANAGEMENT
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_TRANSPORT_MANAGEMENT = 272,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_DRIVER_PROVISIONING
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_DRIVER_PROVISIONING = 278,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_MULTICAST_SERVER
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_MULTICAST_SERVER = 289,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_MULTICAST_CLIENT
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_MULTICAST_CLIENT = 290,

        /// <summary>
        /// FACILITY_DEPLOYMENT_SERVICES_CONTENT_PROVIDER
        /// </summary>
        FACILITY_DEPLOYMENT_SERVICES_CONTENT_PROVIDER = 293,

        /// <summary>
        /// FACILITY_LINGUISTIC_SERVICES
        /// </summary>
        FACILITY_LINGUISTIC_SERVICES = 305,

        /// <summary>
        /// FACILITY_AUDIOSTREAMING
        /// </summary>
        FACILITY_AUDIOSTREAMING = 1094,

        /// <summary>
        /// FACILITY_ACCELERATOR
        /// </summary>
        FACILITY_ACCELERATOR = 1536,

        /// <summary>
        /// FACILITY_WMAAECMA
        /// </summary>
        FACILITY_WMAAECMA = 1996,

        /// <summary>
        /// FACILITY_DIRECTMUSIC
        /// </summary>
        FACILITY_DIRECTMUSIC = 2168,

        /// <summary>
        /// FACILITY_DIRECT3D10
        /// </summary>
        FACILITY_DIRECT3D10 = 2169,

        /// <summary>
        /// FACILITY_DXGI
        /// </summary>
        FACILITY_DXGI = 2170,

        /// <summary>
        /// FACILITY_DXGI_DDI
        /// </summary>
        FACILITY_DXGI_DDI = 2171,

        /// <summary>
        /// FACILITY_DIRECT3D11
        /// </summary>
        FACILITY_DIRECT3D11 = 2172,

        /// <summary>
        /// FACILITY_DIRECT3D11_DEBUG
        /// </summary>
        FACILITY_DIRECT3D11_DEBUG = 2173,

        /// <summary>
        /// FACILITY_DIRECT3D12
        /// </summary>
        FACILITY_DIRECT3D12 = 2174,

        /// <summary>
        /// FACILITY_DIRECT3D12_DEBUG
        /// </summary>
        FACILITY_DIRECT3D12_DEBUG = 2175,

        /// <summary>
        /// FACILITY_LEAP
        /// </summary>
        FACILITY_LEAP = 2184,

        /// <summary>
        /// FACILITY_AUDCLNT
        /// </summary>
        FACILITY_AUDCLNT = 2185,

        /// <summary>
        /// FACILITY_WINCODEC_DWRITE_DWM
        /// </summary>
        FACILITY_WINCODEC_DWRITE_DWM = 2200,

        /// <summary>
        /// FACILITY_WINML
        /// </summary>
        FACILITY_WINML = 2192,

        /// <summary>
        /// FACILITY_DIRECT2D
        /// </summary>
        FACILITY_DIRECT2D = 2201,

        /// <summary>
        /// FACILITY_DEFRAG
        /// </summary>
        FACILITY_DEFRAG = 2304,

        /// <summary>
        /// FACILITY_USERMODE_SDBUS
        /// </summary>
        FACILITY_USERMODE_SDBUS = 2305,

        /// <summary>
        /// FACILITY_JSCRIPT
        /// </summary>
        FACILITY_JSCRIPT = 2306,

        /// <summary>
        /// FACILITY_PIDGENX
        /// </summary>
        FACILITY_PIDGENX = 2561,

        /// <summary>
        /// FACILITY_EAS
        /// </summary>
        FACILITY_EAS = 85,

        /// <summary>
        /// FACILITY_WEB
        /// </summary>
        FACILITY_WEB = 885,

        /// <summary>
        /// FACILITY_WEB_SOCKET
        /// </summary>
        FACILITY_WEB_SOCKET = 886,

        /// <summary>
        /// FACILITY_MOBILE
        /// </summary>
        FACILITY_MOBILE = 1793,

        /// <summary>
        /// FACILITY_SQLITE
        /// </summary>
        FACILITY_SQLITE = 1967,

        /// <summary>
        /// FACILITY_UTC
        /// </summary>
        FACILITY_UTC = 1989,

        /// <summary>
        /// FACILITY_WEP
        /// </summary>
        FACILITY_WEP = 2049,

        /// <summary>
        /// FACILITY_SYNCENGINE
        /// </summary>
        FACILITY_SYNCENGINE = 2050,

        /// <summary>
        /// FACILITY_XBOX
        /// </summary>
        FACILITY_XBOX = 2339,

        /// <summary>
        /// FACILITY_GAME
        /// </summary>
        FACILITY_GAME = 2340,

        /// <summary>
        /// FACILITY_PIX
        /// </summary>
        FACILITY_PIX = 2748,
    }
}
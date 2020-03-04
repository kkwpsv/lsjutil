namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Product Types
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getproductinfo
    /// </para>
    /// </summary>
    public enum ProductTypes : uint
    {
        /// <summary>
        /// An unknown product
        /// </summary>
        PRODUCT_UNDEFINED = 0x00000000,

        /// <summary>
        /// Ultimate
        /// </summary>
        PRODUCT_ULTIMATE = 0x00000001,

        /// <summary>
        /// Home Basic
        /// </summary>
        PRODUCT_HOME_BASIC = 0x00000002,

        /// <summary>
        /// Home Premium
        /// </summary>
        PRODUCT_HOME_PREMIUM = 0x00000003,

        /// <summary>
        /// Windows 10 Enterprise
        /// </summary>
        PRODUCT_ENTERPRISE = 0x00000004,

        /// <summary>
        /// Home Basic N
        /// </summary>
        PRODUCT_HOME_BASIC_N = 0x00000005,

        /// <summary>
        /// Business
        /// </summary>
        PRODUCT_BUSINESS = 0x00000006,

        /// <summary>
        /// Server Standard
        /// (full installation. For Server Core installations of Windows Server 2012 and later,
        /// use the method, Determining whether Server Core is running.)
        /// </summary>
        PRODUCT_STANDARD_SERVER = 0x00000007,

        /// <summary>
        /// Server Datacenter
        /// (full installation. For Server Core installations of Windows Server 2012 and later, use the method,
        /// Determining whether Server Core is running.)
        /// </summary>
        PRODUCT_DATACENTER_SERVER = 0x00000008,

        /// <summary>
        /// Windows Small Business Server
        /// </summary>
        PRODUCT_SMALLBUSINESS_SERVER = 0x00000009,

        /// <summary>
        /// Server Enterprise (full installation)
        /// </summary>
        PRODUCT_ENTERPRISE_SERVER = 0x0000000A,

        /// <summary>
        /// Starter
        /// </summary>
        PRODUCT_STARTER = 0x0000000B,

        /// <summary>
        /// Server Datacenter (core installation, Windows Server 2008 R2 and earlier)
        /// </summary>
        PRODUCT_DATACENTER_SERVER_CORE = 0x0000000C,

        /// <summary>
        /// Server Standard (core installation, Windows Server 2008 R2 and earlier)
        /// </summary>
        PRODUCT_STANDARD_SERVER_CORE = 0x0000000D,

        /// <summary>
        /// Server Enterprise (core installation)
        /// </summary>
        PRODUCT_ENTERPRISE_SERVER_CORE = 0x0000000E,

        /// <summary>
        /// Server Enterprise for Itanium-based Systems
        /// </summary>
        PRODUCT_ENTERPRISE_SERVER_IA64 = 0x0000000F,

        /// <summary>
        /// Business N
        /// </summary>
        PRODUCT_BUSINESS_N = 0x00000010,

        /// <summary>
        /// Web Server (full installation)
        /// </summary>
        PRODUCT_WEB_SERVER = 0x00000011,

        /// <summary>
        /// HPC Edition
        /// </summary>
        PRODUCT_CLUSTER_SERVER = 0x00000012,

        /// <summary>
        /// Windows Storage Server 2008 R2 Essentials
        /// </summary>
        PRODUCT_HOME_SERVER = 0x00000013,

        /// <summary>
        /// Storage Server Express
        /// </summary>
        PRODUCT_STORAGE_EXPRESS_SERVER = 0x00000014,

        /// <summary>
        /// Storage Server Standard
        /// </summary>
        PRODUCT_STORAGE_STANDARD_SERVER = 0x00000015,

        /// <summary>
        /// Storage Server Workgroup
        /// </summary>
        PRODUCT_STORAGE_WORKGROUP_SERVER = 0x00000016,

        /// <summary>
        /// Storage Server Enterprise
        /// </summary>
        PRODUCT_STORAGE_ENTERPRISE_SERVER = 0x00000017,

        /// <summary>
        /// Windows Server 2008 for Windows Essential Server Solutions
        /// </summary>
        PRODUCT_SERVER_FOR_SMALLBUSINESS = 0x00000018,

        /// <summary>
        /// Small Business Server Premium
        /// </summary>
        PRODUCT_SMALLBUSINESS_SERVER_PREMIUM = 0x00000019,

        /// <summary>
        /// Home Premium N
        /// </summary>
        PRODUCT_HOME_PREMIUM_N = 0x0000001A,

        /// <summary>
        /// Windows 10 Enterprise N
        /// </summary>
        PRODUCT_ENTERPRISE_N = 0x0000001B,

        /// <summary>
        /// Ultimate N
        /// </summary>
        PRODUCT_ULTIMATE_N = 0x0000001C,

        /// <summary>
        /// Web Server (core installation)
        /// </summary>
        PRODUCT_WEB_SERVER_CORE = 0x0000001D,

        /// <summary>
        /// Windows Essential Business Server Management Server
        /// </summary>
        PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT = 0x0000001E,

        /// <summary>
        /// Windows Essential Business Server Security Server
        /// </summary>
        PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY = 0x0000001F,

        /// <summary>
        /// Windows Essential Business Server Messaging Server
        /// </summary>
        PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING = 0x00000020,

        /// <summary>
        /// Server Foundation
        /// </summary>
        PRODUCT_SERVER_FOUNDATION = 0x00000021,

        /// <summary>
        /// Windows Home Server 2011
        /// </summary>
        PRODUCT_HOME_PREMIUM_SERVER = 0x00000022,

        /// <summary>
        /// Windows Server 2008 without Hyper-V for Windows Essential Server Solutions
        /// </summary>
        PRODUCT_SERVER_FOR_SMALLBUSINESS_V = 0x00000023,

        /// <summary>
        /// Server Standard without Hyper-V
        /// </summary>
        PRODUCT_STANDARD_SERVER_V = 0x00000024,

        /// <summary>
        /// /Server Datacenter without Hyper-V (full installation)
        /// </summary>
        PRODUCT_DATACENTER_SERVER_V = 0x00000025,

        /// <summary>
        /// Server Enterprise without Hyper-V (full installation)
        /// </summary>
        PRODUCT_ENTERPRISE_SERVER_V = 0x00000026,

        /// <summary>
        /// Server Datacenter without Hyper-V (core installation)
        /// </summary>
        PRODUCT_DATACENTER_SERVER_CORE_V = 0x00000027,

        /// <summary>
        /// Server Standard without Hyper-V (core installation)
        /// </summary>
        PRODUCT_STANDARD_SERVER_CORE_V = 0x00000028,

        /// <summary>
        /// Server Enterprise without Hyper-V (core installation)
        /// </summary>
        PRODUCT_ENTERPRISE_SERVER_CORE_V = 0x00000029,

        /// <summary>
        /// Microsoft Hyper-V Server
        /// </summary>
        PRODUCT_HYPERV = 0x0000002A,

        /// <summary>
        /// Storage Server Express (core installation)
        /// </summary>
        PRODUCT_STORAGE_EXPRESS_SERVER_CORE = 0x0000002B,

        /// <summary>
        /// Storage Server Standard (core installation)
        /// </summary>
        PRODUCT_STORAGE_STANDARD_SERVER_CORE = 0x0000002C,

        /// <summary>
        /// Storage Server Workgroup (core installation)
        /// </summary>
        PRODUCT_STORAGE_WORKGROUP_SERVER_CORE = 0x0000002D,

        /// <summary>
        /// Storage Server Enterprise (core installation)
        /// </summary>
        PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE = 0x0000002E,

        /// <summary>
        /// Starter N
        /// </summary>
        PRODUCT_STARTER_N = 0x0000002F,

        /// <summary>
        /// Windows 10 Pro
        /// </summary>
        PRODUCT_PROFESSIONAL = 0x00000030,

        /// <summary>
        /// Windows 10 Pro N
        /// </summary>
        PRODUCT_PROFESSIONAL_N = 0x00000031,

        /// <summary>
        /// Windows Small Business Server 2011 Essentials
        /// </summary>
        PRODUCT_SB_SOLUTION_SERVER = 0x00000032,

        /// <summary>
        /// Server For SB Solutions
        /// </summary>
        PRODUCT_SERVER_FOR_SB_SOLUTIONS = 0x00000033,

        /// <summary>
        /// Server Solutions Premium
        /// </summary>
        PRODUCT_STANDARD_SERVER_SOLUTIONS = 0x00000034,

        /// <summary>
        /// Server Solutions Premium (core installation)
        /// </summary>
        PRODUCT_STANDARD_SERVER_SOLUTIONS_CORE = 0x00000035,

        /// <summary>
        /// Server For SB Solutions EM
        /// </summary>
        PRODUCT_SB_SOLUTION_SERVER_EM = 0x00000036,

        /// <summary>
        /// Server For SB Solutions EM
        /// </summary>
        PRODUCT_SERVER_FOR_SB_SOLUTIONS_EM = 0x00000037,

        /// <summary>
        /// Windows MultiPoint Server
        /// </summary>
        PRODUCT_SOLUTION_EMBEDDEDSERVER = 0x00000038,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_SOLUTION_EMBEDDEDSERVER_CORE = 0x00000039,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PROFESSIONAL_EMBEDDED = 0x0000003A,

        /// <summary>
        /// Windows Essential Server Solution Management
        /// </summary>
        PRODUCT_ESSENTIALBUSINESS_SERVER_MGMT = 0x0000003B,

        /// <summary>
        /// Windows Essential Server Solution Additional
        /// </summary>
        PRODUCT_ESSENTIALBUSINESS_SERVER_ADDL = 0x0000003C,

        /// <summary>
        /// Windows Essential Server Solution Management SVC
        /// </summary>
        PRODUCT_ESSENTIALBUSINESS_SERVER_MGMTSVC = 0x0000003D,

        /// <summary>
        /// Windows Essential Server Solution Additional SVC
        /// </summary>
        PRODUCT_ESSENTIALBUSINESS_SERVER_ADDLSVC = 0x0000003E,

        /// <summary>
        /// Small Business Server Premium (core installation)
        /// </summary>
        PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE = 0x0000003F,

        /// <summary>
        /// Server Hyper Core V
        /// </summary>
        PRODUCT_CLUSTER_SERVER_V = 0x00000040,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED = 0x00000041,

        /// <summary>
        /// Not supported
        /// </summary>
        PRODUCT_STARTER_E = 0x00000042,

        /// <summary>
        /// Not supported
        /// </summary>
        PRODUCT_HOME_BASIC_E = 0x00000043,

        /// <summary>
        /// Not supported
        /// </summary>
        PRODUCT_HOME_PREMIUM_E = 0x00000044,

        /// <summary>
        /// Not supported
        /// </summary>
        PRODUCT_PROFESSIONAL_E = 0x00000045,

        /// <summary>
        /// Windows 10 Enterprise E
        /// </summary>
        PRODUCT_ENTERPRISE_E = 0x00000046,

        /// <summary>
        /// Not supported
        /// </summary>
        PRODUCT_ULTIMATE_E = 0x00000047,

        /// <summary>
        /// Windows 10 Enterprise Evaluation
        /// </summary>
        PRODUCT_ENTERPRISE_EVALUATION = 0x00000048,

        /// <summary>
        /// Windows MultiPoint Server Standard (full installation)
        /// </summary>
        PRODUCT_MULTIPOINT_STANDARD_SERVER = 0x0000004C,

        /// <summary>
        /// Windows MultiPoint Server Premium (full installation)
        /// </summary>
        PRODUCT_MULTIPOINT_PREMIUM_SERVER = 0x0000004D,

        /// <summary>
        /// Server Standard (evaluation installation)
        /// </summary>
        PRODUCT_STANDARD_EVALUATION_SERVER = 0x0000004F,

        /// <summary>
        /// Server Datacenter (evaluation installation)
        /// </summary>
        PRODUCT_DATACENTER_EVALUATION_SERVER = 0x00000050,

        /// <summary>
        /// Windows 10 Enterprise N Evaluation
        /// </summary>
        PRODUCT_ENTERPRISE_N_EVALUATION = 0x00000054,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_AUTOMOTIVE = 0x00000055,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_INDUSTRY_A = 0x00000056,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_THINPC = 0x00000057,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_A = 0x00000058,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_INDUSTRY = 0x00000059,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_E = 0x0000005A,

        /// <summary>
        /// /
        /// </summary>
        PRODUCT_EMBEDDED_INDUSTRY_E = 0x0000005B,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_INDUSTRY_A_E = 0x0000005C,

        /// <summary>
        /// Storage Server Workgroup (evaluation installation)
        /// </summary>
        PRODUCT_STORAGE_WORKGROUP_EVALUATION_SERVER = 0x0000005F,

        /// <summary>
        /// Storage Server Standard (evaluation installation)
        /// </summary>
        PRODUCT_STORAGE_STANDARD_EVALUATION_SERVER = 0x00000060,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CORE_ARM = 0x00000061,

        /// <summary>
        /// Windows 10 Home N
        /// </summary>
        PRODUCT_CORE_N = 0x00000062,

        /// <summary>
        /// Windows 10 Home China
        /// </summary>
        PRODUCT_CORE_COUNTRYSPECIFIC = 0x00000063,

        /// <summary>
        /// Windows 10 Home Single Language
        /// </summary>
        PRODUCT_CORE_SINGLELANGUAGE = 0x00000064,

        /// <summary>
        /// Windows 10 Home
        /// </summary>
        PRODUCT_CORE = 0x00000065,

        /// <summary>
        /// Professional with Media Center
        /// </summary>
        PRODUCT_PROFESSIONAL_WMC = 0x00000067,

        /// <summary>
        /// Windows 10 Mobile
        /// </summary>
        PRODUCT_MOBILE_CORE = 0x00000068,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_INDUSTRY_EVAL = 0x00000069,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_INDUSTRY_E_EVAL = 0x0000006A,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_EVAL = 0x0000006B,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_EMBEDDED_E_EVAL = 0x0000006C,

        /// <summary>
        /// /
        /// </summary>
        PRODUCT_NANO_SERVER = 0x0000006D,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CLOUD_STORAGE_SERVER = 0x0000006E,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CORE_CONNECTED = 0x0000006F,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PROFESSIONAL_STUDENT = 0x00000070,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CORE_CONNECTED_N = 0x00000071,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PROFESSIONAL_STUDENT_N = 0x00000072,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CORE_CONNECTED_SINGLELANGUAGE = 0x00000073,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CORE_CONNECTED_COUNTRYSPECIFIC = 0x00000074,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CONNECTED_CAR = 0x00000075,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_INDUSTRY_HANDHELD = 0x00000076,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PPI_PRO = 0x00000077,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_ARM64_SERVER = 0x00000078,

        /// <summary>
        /// Windows 10 Education
        /// </summary>
        PRODUCT_EDUCATION = 0x00000079,

        /// <summary>
        /// Windows 10 Education N
        /// </summary>
        PRODUCT_EDUCATION_N = 0x0000007A,

        /// <summary>
        /// Windows 10 IoT Core
        /// </summary>
        PRODUCT_IOTUAP = 0x0000007B,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CLOUD_HOST_INFRASTRUCTURE_SERVER = 0x0000007C,

        /// <summary>
        /// Windows 10 Enterprise 2015 LTSB
        /// </summary>
        PRODUCT_ENTERPRISE_S = 0x0000007D,

        /// <summary>
        /// Windows 10 Enterprise 2015 LTSB N
        /// </summary>
        PRODUCT_ENTERPRISE_S_N = 0x0000007E,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PROFESSIONAL_S = 0x0000007F,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PROFESSIONAL_S_N = 0x00000080,

        /// <summary>
        /// Windows 10 Enterprise 2015 LTSB Evaluation
        /// </summary>
        PRODUCT_ENTERPRISE_S_EVALUATION = 0x00000081,

        /// <summary>
        /// Windows 10 Enterprise 2015 LTSB N Evaluation
        /// </summary>
        PRODUCT_ENTERPRISE_S_N_EVALUATION = 0x00000082,

        /// <summary>
        /// Windows 10 IoT Core Commercial
        /// </summary>
        PRODUCT_IOTUAPCOMMERCIAL = 0x00000083,

        /// <summary>
        /// Windows 10 Mobile Enterprise
        /// </summary>
        PRODUCT_MOBILE_ENTERPRISE = 0x00000085,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_HOLOGRAPHIC = 0x00000087,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_HOLOGRAPHIC_BUSINESS = 0x00000088,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PRO_SINGLE_LANGUAGE = 0x0000008A,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PRO_CHINA = 0x0000008B,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_ENTERPRISE_SUBSCRIPTION = 0x0000008C,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_ENTERPRISE_SUBSCRIPTION_N = 0x0000008D,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_DATACENTER_NANO_SERVER = 0x0000008F,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_STANDARD_NANO_SERVER = 0x00000090,

        /// <summary>
        /// Server Datacenter, Semi-Annual Channel (core installation)
        /// </summary>
        PRODUCT_DATACENTER_A_SERVER_CORE = 0x00000091,

        /// <summary>
        /// Server Standard, Semi-Annual Channel (core installation)
        /// </summary>
        PRODUCT_STANDARD_A_SERVER_CORE = 0x00000092,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_DATACENTER_WS_SERVER_CORE = 0x00000093,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_STANDARD_WS_SERVER_CORE = 0x00000094,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_UTILITY_VM = 0x00000095,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_DATACENTER_EVALUATION_SERVER_CORE = 0x0000009F,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_STANDARD_EVALUATION_SERVER_CORE = 0x000000A0,

        /// <summary>
        /// Windows 10 Pro for Workstations
        /// </summary>
        PRODUCT_PRO_WORKSTATION = 0x000000A1,

        /// <summary>
        /// Windows 10 Pro for Workstations N
        /// </summary>
        PRODUCT_PRO_WORKSTATION_N = 0x000000A2,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PRO_FOR_EDUCATION = 0x000000A4,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_PRO_FOR_EDUCATION_N = 0x000000A5,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_AZURE_SERVER_CORE = 0x000000A8,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_AZURE_NANO_SERVER = 0x000000A9,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_ENTERPRISEG = 0x000000AB,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_ENTERPRISEGN = 0x000000AC,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_SERVERRDSH = 0x000000AF,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CLOUD = 0x000000B2,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CLOUDN = 0x000000B3,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_HUBOS = 0x000000B4,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_ONECOREUPDATEOS = 0x000000B6,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CLOUDE = 0x000000B7,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_ANDROMEDA = 0x000000B8,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_IOTOS = 0x000000B9,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_CLOUDEN = 0x000000BA,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_IOTEDGEOS = 0x000000BB,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_IOTENTERPRISE = 0x000000BC,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_LITE = 0x000000BD,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_IOTENTERPRISES = 0x000000BF,

        /// <summary>
        /// 
        /// </summary>
        PRODUCT_UNLICENSED = 0xABCDABCD,
    }
}

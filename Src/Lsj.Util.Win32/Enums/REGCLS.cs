using System;
using System.Collections.Generic;
using System.Text;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.Enums.CLSCTX;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Controls the type of connections to a class object.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/combaseapi/ne-combaseapi-regcls
    /// </para>
    /// </summary>
    /// <remarks>
    /// In <see cref="CoRegisterClassObject"/>, members of both the <see cref="REGCLS"/> and the <see cref="CLSCTX"/> enumerations,
    /// taken together, determine how the class object is registered.
    /// An EXE surrogate (in which DLL servers are run) calls <see cref="CoRegisterClassObject"/> to register a class factory
    /// using a new <see cref="REGCLS"/> value, <see cref="REGCLS_SURROGATE"/>.
    /// All class factories for DLL surrogates should be registered with <see cref="REGCLS_SURROGATE"/> set.
    /// Do not set <see cref="REGCLS_SINGLUSE"/> or <see cref="REGCLS_MULTIPLEUSE"/> when you register a surrogate for DLL servers.
    /// The following table summarizes the allowable <see cref="REGCLS"/> value combinations and the object registrations affected by the combinations.
    ///                                     REGCLS_SINGLEUSE    REGCLS_MULTIPLEUSE  REGCLS_MULTI_SEPARATE   Other
    ///  <see cref="CLSCTX_INPROC_SERVER"/> Error               In-process          In-process              Error
    ///  <see cref="CLSCTX_LOCAL_SERVER"/>  Local               In-process/local    Local                   Error
    ///  Both of the above                  Error               In-process/local    In-process/local        Error
    ///  Other                              Error               Error               Error                   Error
    /// </remarks>
    public enum REGCLS
    {
        /// <summary>
        /// After an application is connected to a class object with <see cref="CoGetClassObject"/>,
        /// the class object is removed from public view so that no other applications can connect to it.
        /// This value is commonly used for single document interface (SDI) applications.
        /// Specifying this value does not affect the responsibility of the object application to call <see cref="CoRevokeClassObject"/>;
        /// it must always call <see cref="CoRevokeClassObject"/> when it is finished with an object class.
        /// </summary>
        REGCLS_SINGLEUSE = 0,

        /// <summary>
        /// Multiple applications can connect to the class object through calls to <see cref="CoGetClassObject"/>.
        /// If both the <see cref="REGCLS_MULTIPLEUSE"/> and <see cref="CLSCTX_LOCAL_SERVER"/> are set in a call to <see cref="CoRegisterClassObject"/>,
        /// the class object is also automatically registered as an in-process server, whether <see cref="CLSCTX_INPROC_SERVER"/> is explicitly set.
        /// </summary>
        REGCLS_MULTIPLEUSE = 1,

        /// <summary>
        /// Useful for registering separate <see cref="CLSCTX_LOCAL_SERVER"/> and <see cref="CLSCTX_INPROC_SERVER"/> class factories
        /// through calls to <see cref="CoGetClassObject"/>.
        /// If <see cref="REGCLS_MULTI_SEPARATE"/> is set, each execution context must be set separately;
        /// <see cref="CoRegisterClassObject"/> does not automatically register an out-of-process server
        /// (for which <see cref="CLSCTX_LOCAL_SERVER"/> is set) as an in-process server.
        /// This allows the EXE to create multiple instances of the object for in-process needs, such as self embeddings,
        /// without disturbing its <see cref="CLSCTX_LOCAL_SERVER"/> registration.
        /// If an EXE registers a <see cref="REGCLS_MULTI_SEPARATE"/> class factory and a <see cref="CLSCTX_INPROC_SERVER"/> class factory,
        /// instance creation calls that specify <see cref="CLSCTX_INPROC_SERVER"/> in the <see cref="CLSCTX"/> parameter executed
        /// by the EXE would be satisfied locally without approaching the SCM. 
        ///This mechanism is useful when the EXE uses functions such as <see cref="OleCreate"/> and <see cref="OleLoad"/> to create embeddings,
        ///but at the same does not wish to launch a new instance of itself for the self-embedding case.
        ///The distinction is important for embeddings because the default handler aggregates the proxy manager by default
        ///and the application should override this default behavior by calling <see cref="OleCreateEmbeddingHelper"/> for the self-embedding case.
        /// If your application need not distinguish between the local and inproc case,
        /// you need not register your class factory using <see cref="REGCLS_MULTI_SEPARATE"/>.
        /// In fact, the application incurs an extra network round trip to the SCM when it registers its MULTIPLEUSE class factory
        /// as "MULTI_SEPARATE and does not register another class factory as INPROC_SERVER.
        /// </summary>
        REGCLS_MULTI_SEPARATE = 2,

        /// <summary>
        /// Suspends registration and activation requests for the specified CLSID until there is a call to <see cref="CoResumeClassObjects"/>.
        /// This is used typically to register the CLSIDs for servers that can register multiple class objects to reduce the overall registration time,
        /// and thus the server application startup time, by making a single call to the SCM, no matter how many CLSIDs are registered for the server.
        /// Note
        /// This flag prevents COM activation errors from a possible race condition between an application shutting down
        /// and that application attempting to register a COM class.
        /// </summary>
        REGCLS_SUSPENDED = 4,

        /// <summary>
        /// The class object is a surrogate process used to run DLL servers.
        /// The class factory registered by the surrogate process is not the actual class factory implemented by the DLL server,
        /// but a generic class factory implemented by the surrogate.
        /// This generic class factory delegates instance creation and marshaling to the class factory of the DLL server running in the surrogate.
        /// For further information on DLL surrogates, see the DllSurrogate registry value.
        /// </summary>
        REGCLS_SURROGATE = 8,

        /// <summary>
        /// The class object aggregates the free-threaded marshaler and will be made visible to all inproc apartments.
        /// Can be used together with other flags.
        /// For example, <see cref="REGCLS_AGILE"/> <see cref="REGCLS_MULTIPLEUSE"/> to register a class object
        /// that can be used multiple times from different apartments.
        /// Without other flags, behavior will retain <see cref="REGCLS_SINGLEUSE"/> semantics in that only one instance can be generated.
        /// </summary>
        REGCLS_AGILE = 0x10,
    }
}

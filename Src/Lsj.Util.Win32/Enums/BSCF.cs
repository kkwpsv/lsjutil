using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Values from the <see cref="BSCF"/> enumeration are passed to the client
    /// in <see cref="IBindStatusCallback.OnDataAvailable"/> to indicate the type of data that is available.
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775135(v%3Dvs.85)"/>
    /// </para>
    /// </summary>
    public enum BSCF
    {
        /// <summary>
        /// Identify the first call to <see cref="IBindStatusCallback.OnDataAvailable"/> for a given bind operation.
        /// </summary>
        BSCF_FIRSTDATANOTIFICATION = 0x1,

        /// <summary>
        /// Identify an intermediate call to <see cref="IBindStatusCallback.OnDataAvailable"/> for a bind operation.
        /// </summary>
        BSCF_INTERMEDIATEDATANOTIFICATION = 0x2,

        /// <summary>
        /// Identify the last call to <see cref="IBindStatusCallback.OnDataAvailable"/> for a bind operation.
        /// </summary>
        BSCF_LASTDATANOTIFICATION = 0x4,

        /// <summary>
        /// All of the requested data is available.
        /// </summary>
        BSCF_DATAFULLYAVAILABLE = 0x8,

        /// <summary>
        /// Size of the data available is unknown.
        /// </summary>
        BSCF_AVAILABLEDATASIZEUNKNOWN = 0x10,

        /// <summary>
        /// Internet Explorer 8.
        /// Flag sent to <see cref="IBindStatusCallback.OnDataAvailable"/> to bypass cache downloads for file:// URLs.
        /// Normally, the cache file is emptied when new data is available.
        /// Specify this flag when it is not necessary to read the data and throw it away, such as when downloading a file through a UNC path.
        /// </summary>
        BSCF_SKIPDRAINDATAFORFILEURLS = 0x20,

        /// <summary>
        /// Internet Explorer 8.
        /// Notification to the <see cref="IInternetProtocolSink.ReportProgress"/> that the size cannot be expressed in 32-bit terms for downloads exceeding 4 GB.
        /// </summary>
        BSCF_64BITLENGTHDOWNLOAD = 0x40,
    }
}

using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Values that specify debug message severity levels for an information queue.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ne-dxgidebug-dxgi_info_queue_message_severity"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this enumeration when you call <see cref="IDXGIInfoQueue.GetMessage"/> to retrieve a message
    /// and when you call <see cref="IDXGIInfoQueue.AddMessage"/> to add a message.
    /// Also, use this enumeration with <see cref="IDXGIInfoQueue.AddApplicationMessage"/>.
    /// Note
    /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
    /// </remarks>
    public enum DXGI_INFO_QUEUE_MESSAGE_SEVERITY
    {
        /// <summary>
        /// Defines some type of corruption that has occurred.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_SEVERITY_CORRUPTION = 0,

        /// <summary>
        /// Defines an error message.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_SEVERITY_ERROR,

        /// <summary>
        /// Defines an error message.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_SEVERITY_WARNING,

        /// <summary>
        /// Defines an information message.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_SEVERITY_INFO,

        /// <summary>
        /// Defines a message other than corruption, error, warning, or information.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_SEVERITY_MESSAGE
    }
}

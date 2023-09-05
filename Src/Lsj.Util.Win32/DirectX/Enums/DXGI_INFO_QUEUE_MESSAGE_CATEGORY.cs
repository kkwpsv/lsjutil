namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Values that specify categories of debug messages.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ne-dxgidebug-dxgi_info_queue_message_category"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this enumeration when you call <see cref="IDXGIInfoQueue.GetMessage"/> to retrieve a message
    /// and when you call <see cref="IDXGIInfoQueue.AddMessage"/> to add a message.
    /// When you create an info queue filter, you can use these values to allow or deny any categories of messages
    /// to pass through the storage and retrieval filters.
    /// </remarks>
    public enum DXGI_INFO_QUEUE_MESSAGE_CATEGORY
    {
        /// <summary>
        /// Unknown category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_UNKNOWN = 0,

        /// <summary>
        /// Miscellaneous category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_MISCELLANEOUS,

        /// <summary>
        /// Initialization category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_INITIALIZATION,

        /// <summary>
        /// Cleanup category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_CLEANUP,

        /// <summary>
        /// Compilation category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_COMPILATION,

        /// <summary>
        /// State creation category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_CREATION,

        /// <summary>
        /// State setting category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_SETTING,

        /// <summary>
        /// State getting category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_GETTING,

        /// <summary>
        /// Resource manipulation category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_RESOURCE_MANIPULATION,

        /// <summary>
        /// Execution category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_EXECUTION,

        /// <summary>
        /// Shader category.
        /// </summary>
        DXGI_INFO_QUEUE_MESSAGE_CATEGORY_SHADER
    }
}

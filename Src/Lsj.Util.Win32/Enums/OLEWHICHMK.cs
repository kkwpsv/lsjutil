namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates which part of an object's moniker is being set or retrieved.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-olewhichmk"/>
    /// </para>
    /// </summary>
    public enum OLEWHICHMK
    {
        /// <summary>
        /// The moniker of the object's container.
        /// Typically, this is a file moniker.
        /// This moniker is not persistently stored inside the object, since the container can be renamed even while the object is not loaded.
        /// </summary>
        OLEWHICHMK_CONTAINER = 1,

        /// <summary>
        /// The moniker of the object relative to its container.
        /// Typically, this is an item moniker, and it is part of the persistent state of the object.
        /// If this moniker is composed on to the end of the container's moniker, the resulting moniker is the full moniker of the object.
        /// </summary>
        OLEWHICHMK_OBJREL = 2,

        /// <summary>
        /// The full moniker of the object.
        /// Binding to this moniker results in a connection to the object.
        /// This moniker is not persistently stored inside the object, since the container can be renamed even while the object is not loaded.
        /// </summary>
        OLEWHICHMK_OBJFULL = 3
    }
}

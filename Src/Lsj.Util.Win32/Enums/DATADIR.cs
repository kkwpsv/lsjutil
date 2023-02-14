using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the direction of the data flow.
    /// This determines the formats that the resulting enumerator can enumerate.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-datadir"/>
    /// </para>
    /// </summary>
    public enum DATADIR
    {
        /// <summary>
        /// Requests that <see cref="IDataObject.EnumFormatEtc"/> supply an enumerator
        /// for the formats that can be specified in <see cref="IDataObject.GetData"/>.
        /// </summary>
        DATADIR_GET = 1,

        /// <summary>
        /// Requests that <see cref="IDataObject.EnumFormatEtc"/> supply an enumerator
        /// for the formats that can be specified in <see cref="IDataObject.SetData"/>.
        /// </summary>
        DATADIR_SET = 2,
    }
}

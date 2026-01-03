using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.MediaFoundation
{
    /// <summary>
    /// Mf.dll
    /// </summary>
    public static class Mf
    {
        /// <summary>
        /// <para>
        /// Queries an object for a specified service interface.
        /// </para>
        /// <para>
        /// This function is a helper function that wraps the <see cref="IMFGetService.GetService"/> method.
        /// The function queries the object for the <see cref="IMFGetService"/> interface and,
        /// if successful, calls <see cref="IMFGetService.GetService"/> on the object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfidl/nf-mfidl-mfgetservice"/>
        /// </para>
        /// </summary>
        /// <param name="punkObject">
        /// A pointer to the <see cref="IUnknown"/> interface of the object to query.
        /// </param>
        /// <param name="guidService">
        /// The service identifier (SID) of the service.
        /// For a list of service identifiers, see Service Interfaces.
        /// </param>
        /// <param name="riid">
        /// The interface identifier (IID) of the interface being requested.
        /// </param>
        /// <param name="ppvObject">
        /// Receives the interface pointer. The caller must release the interface.
        /// </param>
        /// <returns>
        /// <para>
        /// The function returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_UNSUPPORTED_SERVICE"/>
        /// </term>
        /// <term>
        /// The service requested cannot be found in the object represented by <paramref name="punkObject"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Mf.dll", CharSet = CharSet.Unicode, EntryPoint = "MFGetService", ExactSpelling = true)]
        public static extern HRESULT MFGetService(
#if NETFRAMEWORK
            [In] nint punkObject,
#else
            [In] P<IUnknown> punkObject,
#endif
            [In] in GUID guidService, [In] in IID riid, [Out] out LPVOID ppvObject);
    }
}

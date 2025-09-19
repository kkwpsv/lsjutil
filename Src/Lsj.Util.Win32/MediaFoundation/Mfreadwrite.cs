using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;

namespace Lsj.Util.Win32.MediaFoundation
{
    /// <summary>
    /// Mfreadwrite.dll
    /// </summary>
    public static class Mfreadwrite
    {
        /// <summary>
        /// <para>
        /// Creates the source reader from a URL.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfreadwrite/nf-mfreadwrite-mfcreatesourcereaderfromurl"/>
        /// </para>
        /// </summary>
        /// <param name="pwszURL">
        /// The URL of a media file to open.
        /// </param>
        /// <param name="pAttributes">
        /// Pointer to the <see cref="IMFAttributes"/> interface.
        /// You can use this parameter to configure the source reader.
        /// For more information, see Source Reader Attributes.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="ppSourceReader">
        /// Receives a pointer to the <see cref="IMFSourceReader"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Call CoInitialize(Ex) and <see cref="MFStartup"/> before calling this function.
        /// </para>
        /// <para>
        /// Internally, the source reader calls the <see cref="IMFSourceResolver.CreateObjectFromURL"/> method
        /// to create a media source from the URL.
        /// </para>
        /// <para>
        /// This function is available on Windows Vista if Platform Update Supplement for Windows Vista is installed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista, BuildNumbers.WindowsVistaSP2, Note = "Platform Update Supplement")]
        [DllImport("Mfreadwrite.dll", CharSet = CharSet.Unicode, EntryPoint = "MFCreateSourceReaderFromURL", ExactSpelling = true)]
        public static extern HRESULT MFCreateSourceReaderFromURL([In] LPCWSTR pwszURL, P<IMFAttributes> pAttributes,
            [Out] out P<IMFSourceReader> ppSourceReader);
    }
}

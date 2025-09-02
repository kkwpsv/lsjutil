using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a description of a media format.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imfmediatype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To create a new media type, call <see cref="MFCreateMediaType"/>.
    /// </para>
    /// <para>
    /// All of the information in a media type is stored as attributes.
    /// To clone a media type, call <see cref="IMFAttributes.CopyAllItems"/>.
    /// </para>
    /// <para>
    /// This interface is available on the following platforms
    /// if the Windows Media Format 11 SDK redistributable components are installed:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Windows XP with Service Pack 2 (SP2) and later.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
    /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "44ae0fa8-ea31-4109-8d2e-4cae4997c555", BeginVTableSlotIndex = 33, EndVTableSlotIndex = 37,
        InheritedFromTypes = [typeof(IUnknown), typeof(IMFAttributes)])]
    public unsafe struct IMFMediaType
    {
        IntPtr* _vTable;
    }
}

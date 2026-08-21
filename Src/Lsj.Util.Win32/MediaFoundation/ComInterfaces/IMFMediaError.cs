using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides the current error status for the Media Engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/nn-mfmediaengine-imfmediaerror"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="IMFMediaError"/> interface corresponds to the <c>MediaError</c> object in HTML5.
    /// </para>
    /// <para>
    /// To get a pointer to this interface, call <see cref="IMFMediaEngine.GetError"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "fc0e10d2-ab2a-4501-a951-06bb1075184c", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 6, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaError
    {
        nint* _vTable;
    }
}

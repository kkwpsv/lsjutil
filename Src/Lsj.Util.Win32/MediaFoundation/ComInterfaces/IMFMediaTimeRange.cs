using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a list of time ranges, where each range is defined by a start and end time.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/nn-mfmediaengine-imfmediatimerange"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="IMFMediaTimeRange"/> interface corresponds to the <c>TimeRanges</c> interface in HTML5.
    /// </para>
    /// <para>
    /// Several <see cref="IMFMediaEngine"/> methods return <see cref="IMFMediaTimeRange"/> pointers.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "db71a2fc-078a-414e-9df9-8c2531b0aa6c", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 8, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaTimeRange
    {
        nint* _vTable;
    }
}

using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Implemented by media sink objects.
    /// This interface is the base interface for all Media Foundation media sinks.
    /// Stream sinks handle the actual processing of data on each stream.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfidl/nn-mfidl-imfmediasink"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "6ef2a660-47c0-4666-b13d-cbb717f2fa2c", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 11, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaSink
    {
        IntPtr* _vTable;
    }
}

using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Retrieves events from any Media Foundation object that generates events.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imfmediaeventgenerator"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An object that supports this interface maintains a queue of events.
    /// The client of the object can retrieve the events either synchronously or asynchronously.
    /// The synchronous method is <see cref="GetEvent"/>.
    /// The asynchronous methods are <see cref="BeginGetEvent"/> and <see cref="EndGetEvent"/>.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "2CD0BD52-BCD5-4B89-B62C-EADC0C031E7D", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 6,InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaEventGenerator
    {
        nint* _vTable;
    }
}

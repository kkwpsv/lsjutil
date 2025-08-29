using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides a generic way to store key/value pairs on an object.
    /// The keys are <see cref="GUID"/>s, and the values can be any of the following data types:
    /// <see cref="UINT32"/>, <see cref="UINT64"/>, double, <see cref="GUID"/>,
    /// wide-character string, byte array, or <see cref="IUnknown"/> pointer.
    /// The standard implementation of this interface holds a thread lock while values are added, deleted, or retrieved.
    /// </para>
    /// <para>
    /// For a list of predefined attribute <see cref="GUID"/>s, see Media Foundation Attributes.
    /// Each attribute <see cref="GUID"/> has an expected data type.
    /// The various "set" methods in <see cref="IMFAttributes"/>
    /// do not validate the type against the attribute <see cref="GUID"/>.
    /// It is the application's responsibility to set the correct type for the attribute.
    /// </para>
    /// <para>
    /// To create an empty attribute store, call <see cref="MFCreateAttributes"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imfattributes"/>
    /// </para>
    /// </summary>
    /// <remarks>
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
    [ComInterface(IID = "2cd2d921-c447-44a7-a13c-4adabfc247e3", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 32, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFAttributes
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the value associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// A <see cref="GUID"/> that identifies which value to retrieve.
        /// </param>
        /// <param name="pValue">
        /// A pointer to a <see cref="PROPVARIANT"/> that receives the value.
        /// The method fills the <see cref="PROPVARIANT"/> with a copy of the stored value, if the value is found.
        /// Call <see cref="PropVariantClear"/> to free the memory allocated by this method.
        /// This parameter can be <see cref="NullRef{PROPVARIANT}"/>.
        /// If this parameter is <see cref="NullRef{PROPVARIANT}"/>,
        /// the method searches for the key and returns <see cref="S_OK"/> if the key is found, but does not copy the value.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
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
        /// <see cref="MF_E_ATTRIBUTENOTFOUND"/>
        /// </term>
        /// <term>
        /// The specified key was not found.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
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
        public HRESULT GetItem([In] in GUID guidKey, [In][Out] ref PROPVARIANT pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, ref PROPVARIANT, HRESULT>)_vTable[3])(thisPtr, guidKey, ref pValue);
            }
        }
    }
}

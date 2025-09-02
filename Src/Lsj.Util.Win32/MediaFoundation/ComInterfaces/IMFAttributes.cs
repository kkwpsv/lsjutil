using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.MediaFoundation.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.MediaFoundation.Enums.MF_ATTRIBUTE_TYPE;
using static Lsj.Util.Win32.MediaFoundation.Enums.MF_ATTRIBUTES_MATCH_TYPE;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;
using static Lsj.Util.Win32.Ole32;
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

        /// <summary>
        /// Retrieves the data type of the value associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to query.
        /// </param>
        /// <param name="pType">
        /// Receives a member of the <see cref="MF_ATTRIBUTE_TYPE"/> enumeration.
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
        /// The specified key is not stored in this object.
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
        public HRESULT GetItemType([In] in GUID guidKey, [Out] out MF_ATTRIBUTE_TYPE pType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out MF_ATTRIBUTE_TYPE, HRESULT>)_vTable[4])(thisPtr, guidKey, out pType);
            }
        }

        /// <summary>
        /// Queries whether a stored attribute value equals to a specified <see cref="PROPVARIANT"/>.
        /// </summary>
        /// <param name="guidKey">
        /// GUID that identifies which value to query.
        /// </param>
        /// <param name="Value">
        /// <see cref="PROPVARIANT"/> that contains the value to compare.
        /// </param>
        /// <param name="pbResult">
        /// Receives a Boolean value indicating whether the attribute matches the value given in <paramref name="Value"/>.
        /// See Remarks. This parameter must not be <paramref name="Value"/>. 
        /// If this parameter is <see cref="NULL"/>, an access violation occurs.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The method sets <paramref name="pbResult"/> to <see cref="FALSE"/> for any of the following reasons:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// No attribute is found whose key matches the one given in <paramref name="guidKey"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The attribute's <see cref="PROPVARIANT"/> type does not match the type given in <paramref name="Value"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The attribute value does not match the value given in <paramref name="Value"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The method fails.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Otherwise, the method sets <paramref name="pbResult"/> to <see cref="TRUE"/>.
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
        public HRESULT CompareItem([In] in GUID guidKey, [In][Out] ref PROPVARIANT Value, [Out] out BOOL pbResult)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, ref PROPVARIANT, out BOOL, HRESULT>)_vTable[5])
                    (thisPtr, guidKey, ref Value, out pbResult);
            }
        }

        /// <summary>
        /// Compares the attributes on this object with the attributes on another object.
        /// </summary>
        /// <param name="pTheirs">
        /// Pointer to the <see cref="IMFAttributes"/> interface of the object to compare with this object.
        /// </param>
        /// <param name="MatchType">
        /// Member of the <see cref="MF_ATTRIBUTES_MATCH_TYPE"/> enumeration,
        /// specifying the type of comparison to make.
        /// </param>
        /// <param name="pbResult">
        /// Receives a Boolean value.
        /// The value is <see cref="TRUE"/>
        /// if the two sets of attributes match in the way specified by the <paramref name="MatchType"/> parameter.
        /// Otherwise, the value is <see cref="FALSE"/>.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If pThis is the object whose <see cref="Compare"/> method is called,
        /// and <paramref name="pTheirs"/> is the object passed in as the <paramref name="pTheirs"/> parameter,
        /// the following comparisons are defined by <paramref name="MatchType"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Match type
        /// </term>
        /// <term>
        /// Returns <see cref="TRUE"/> if and only if
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MF_ATTRIBUTES_MATCH_OUR_ITEMS"/>
        /// </term>
        /// <term>
        /// For every attribute in pThis, an attribute with the same key and value exists in <paramref name="pTheirs"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_ATTRIBUTES_MATCH_THEIR_ITEMS"/>
        /// </term>
        /// <term>
        /// For every attribute in <paramref name="pTheirs"/>, an attribute with the same key and value exists in pThis.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_ATTRIBUTES_MATCH_ALL_ITEMS"/>
        /// </term>
        /// <term>
        /// The key/value pairs are identical in both objects.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_ATTRIBUTES_MATCH_INTERSECTION"/>
        /// </term>
        /// <term>
        /// Take the intersection of the keys in pThis and the keys in <paramref name="pTheirs"/>.
        /// The values associated with those keys are identical in both pThis and <paramref name="pTheirs"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_ATTRIBUTES_MATCH_SMALLER"/>
        /// </term>
        /// <term>
        /// Take the object with the smallest number of attributes.
        /// For every attribute in that object, an attribute with the same key and value exists in the other object.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <paramref name="pTheirs"/> and <paramref name="pbResult"/> parameters must not be <see cref="NULL"/>.
        /// If either parameter is <see cref="NULL"/>, an access violation occurs.
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
        public HRESULT Compare([In] in IMFAttributes pTheirs, [In] MF_ATTRIBUTES_MATCH_TYPE MatchType, [Out] out BOOL pbResult)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IMFAttributes, MF_ATTRIBUTES_MATCH_TYPE, out BOOL, HRESULT>)_vTable[6])
                    (thisPtr, pTheirs, MatchType, out pbResult);
            }
        }

        /// <summary>
        /// Retrieves a <see cref="UINT32"/> value associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_UINT32"/>.
        /// </param>
        /// <param name="punValue">
        /// Receives a <see cref="UINT32"/> value.
        /// If the key is found and the data type is <see cref="UINT32"/>,
        /// the method copies the value into this parameter.
        /// Otherwise, the original value of this parameter is not changed.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a <see cref="UINT32"/>.
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
        public HRESULT GetUINT32([In] in GUID guidKey, [Out] out UINT32 punValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out UINT32, HRESULT>)_vTable[7])(thisPtr, guidKey, out punValue);
            }
        }

        /// <summary>
        /// Retrieves a <see cref="UINT64"/> value associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_UINT64"/>.
        /// </param>
        /// <param name="punValue">
        /// Receives a <see cref="UINT64"/> value.
        /// If the key is found and the data type is <see cref="UINT64"/>,
        /// the method copies the value into this parameter.
        /// Otherwise, the original value of this parameter is not changed.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a <see cref="UINT64"/>.
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
        public HRESULT GetUINT64([In] in GUID guidKey, [Out] out UINT64 punValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out UINT64, HRESULT>)_vTable[8])(thisPtr, guidKey, out punValue);
            }
        }

        /// <summary>
        /// Retrieves a <see langword="double"/> value associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_DOUBLE"/>.
        /// </param>
        /// <param name="pfValue">
        /// Receives a <see langword="double"/> value.
        /// If the key is found and the data type is <see langword="double"/>,
        /// the method copies the value into this parameter.
        /// Otherwise, the original value of this parameter is not changed.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a <see langword="double"/>.
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
        public HRESULT GetDouble([In] in GUID guidKey, [Out] out double pfValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out double, HRESULT>)_vTable[9])(thisPtr, guidKey, out pfValue);
            }
        }

        /// <summary>
        /// Retrieves a <see cref="GUID"/> value associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_GUID"/>.
        /// </param>
        /// <param name="pguidValue">
        /// Receives a <see cref="GUID"/> value.
        /// If the key is found and the data type is <see cref="GUID"/>,
        /// the method copies the value into this parameter.
        /// Otherwise, the original value of this parameter is not changed.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a <see cref="GUID"/>.
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
        public HRESULT GetGUID([In] in GUID guidKey, [Out] out GUID pguidValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out GUID, HRESULT>)_vTable[10])(thisPtr, guidKey, out pguidValue);
            }
        }

        /// <summary>
        /// Retrieves a string value associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_STRING"/>.
        /// </param>
        /// <param name="pcchLength">
        /// If the key is found and the value is a string type,
        /// this parameter receives the number of characters in the string,
        /// not including the terminating <see cref="NULL"/> character.
        /// To get the string value, call <see cref="IMFAttributes.GetString"/>.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a string.
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
        public HRESULT GetStringLength([In] in GUID guidKey, [Out] out UINT32 pcchLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out UINT32, HRESULT>)_vTable[11])(thisPtr, guidKey, out pcchLength);
            }
        }

        /// <summary>
        /// Retrieves a wide-character string associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_STRING"/>.
        /// </param>
        /// <param name="pwszValue">
        /// Pointer to a wide-character array allocated by the caller.
        /// The array must be large enough to hold the string,
        /// including the terminating <see cref="NULL"/> character.
        /// If the key is found and the value is a string type, the method copies the string into this buffer.
        /// To find the length of the string, call <see cref="GetStringLength"/>.
        /// </param>
        /// <param name="cchBufSize">
        /// The size of the <paramref name="pwszValue"/> array, in characters.
        /// This value includes the terminating <see cref="NULL"/> character.
        /// </param>
        /// <param name="pcchLength">
        /// Receives the number of characters in the string,
        /// excluding the terminating <see cref="NULL"/> character.
        /// This parameter can be <see cref="NullRef{UINT32}"/>.
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
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// The length of the string is too large to fit in a <see cref="UINT32"/> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_NOT_SUFFICIENT_BUFFER"/>
        /// </term>
        /// <term>
        /// The buffer is not large enough to hold the string.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a string.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You can also use the <see cref="GetAllocatedString"/> method,
        /// which allocates the buffer to hold the string.
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
        public HRESULT GetString([In] in GUID guidKey, [In] LPWSTR pwszValue, [In] UINT32 cchBufSize, [Out] out UINT32 pcchLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, LPWSTR, UINT32, out UINT32, HRESULT>)_vTable[12])
                    (thisPtr, guidKey, pwszValue.Handle, cchBufSize, out pcchLength);
            }
        }

        /// <summary>
        /// Gets a wide-character string associated with a key.
        /// This method allocates the memory for the string.
        /// </summary>
        /// <param name="guidKey">
        /// A <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_STRING"/>.
        /// </param>
        /// <param name="pwszValue">
        /// If the key is found and the value is a string type,
        /// this parameter receives a copy of the string.
        /// The caller must free the memory for the string by calling <see cref="CoTaskMemFree"/>.
        /// </param>
        /// <param name="pcchLength">
        /// Receives the number of characters in the string,
        /// excluding the terminating <see cref="NULL"/> character.
        /// This parameter must not be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>. Possible values include, but are not limited to, those in the following table.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a string.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To copy a string value into a caller-allocated buffer, use the <see cref="GetString"/> method.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms
        /// if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
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
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// An earlier version of the documentation incorrectly stated
        /// that the <paramref name="pcchLength"/> parameter can be <see cref="NullRef{UINT32}"/>.
        /// Setting this parameter to <see cref="NullRef{UINT32}"/> might succeed in some cases, but is not guaranteed.
        /// The caller must pass a non-<see cref="NullRef{UINT32}"/> pointer for this parameter.
        /// </para>
        /// </remarks>

        public HRESULT GetAllocatedString([In] in GUID guidKey, [Out] out LPWSTR pwszValue, [Out] out UINT32 pcchLength)
        {
            fixed (void* thisPtr = &this)
            {
                var result = ((delegate* unmanaged[Stdcall]<void*, in GUID, out nint, out UINT32, HRESULT>)_vTable[13])
                    (thisPtr, guidKey, out var tempValue, out pcchLength);
                pwszValue = new LPWSTR(tempValue);
                return result;
            }
        }

        /// <summary>
        /// Retrieves the length of a byte array associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_BLOB"/>.
        /// </param>
        /// <param name="pcbBlobSize">
        /// If the key is found and the value is a byte array,
        /// this parameter receives the size of the array, in bytes.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a byte array.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To get the byte array, call <see cref="GetBlob"/>.
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
        public HRESULT GetBlobSize([In] in GUID guidKey, [Out] out UINT32 pcbBlobSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out UINT32, HRESULT>)_vTable[14])(thisPtr, guidKey, out pcbBlobSize);
            }
        }

        /// <summary>
        /// Retrieves a byte array associated with a key.
        /// This method copies the array into a caller-allocated buffer.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_BLOB"/>.
        /// </param>
        /// <param name="pBuf">
        /// Pointer to a buffer allocated by the caller.
        /// If the key is found and the value is a byte array, the method copies the array into this buffer.
        /// To find the required size of the buffer, call <see cref="GetBlobSize"/>.
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the <paramref name="pBuf"/> buffer, in bytes.
        /// </param>
        /// <param name="pcbBlobSize">
        /// Receives the size of the byte array. 
        /// This parameter can be <see cref="NullRef{UINT32}"/>.
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
        /// <see cref="E_NOT_SUFFICIENT_BUFFER"/>
        /// </term>
        /// <term>
        /// The buffer is not large enough to the array.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a byte array.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You can also use the <see cref="GetAllocatedBlob"/> method,
        /// which allocates the buffer to hold the byte array.
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
        public HRESULT GetBlob([In] in GUID guidKey, [In] P<UINT8> pBuf, [In] UINT32 cbBufSize, [Out] out UINT32 pcbBlobSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, P<UINT8>, UINT32, out UINT32, HRESULT>)_vTable[15])
                    (thisPtr, guidKey, pBuf, cbBufSize, out pcbBlobSize);
            }
        }

        /// <summary>
        /// Retrieves a byte array associated with a key.
        /// This method allocates the memory for the array.
        /// </summary>
        /// <param name="guidKey">
        /// GUID that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_BLOB"/>.
        /// </param>
        /// <param name="ppBuf">
        /// If the key is found and the value is a byte array,
        /// this parameter receives a copy of the array.
        /// The caller must free the memory for the array by calling <see cref="CoTaskMemFree"/>.
        /// </param>
        /// <param name="pcbSize">
        /// Receives the size of the array, in bytes.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not a byte array.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To copy a byte array value into a caller-allocated buffer,
        /// use the <see cref="GetBlob"/> method.
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
        public HRESULT GetAllocatedBlob([In] in GUID guidKey, [Out] out P<UINT8> ppBuf, [Out] out UINT32 pcbSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out P<UINT8>, out UINT32, HRESULT>)_vTable[16])
                    (thisPtr, guidKey, out ppBuf, out pcbSize);
            }
        }

        /// <summary>
        /// Retrieves an interface pointer associated with a key.
        /// </summary>
        /// <param name="guidKey">
        /// GUID that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_IUNKNOWN"/>.
        /// </param>
        /// <param name="riid">
        /// Interface identifier (IID) of the interface to retrieve.
        /// </param>
        /// <param name="ppv">
        /// Receives a pointer to the requested interface.
        /// The caller must release the interface.
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
        /// <see cref="E_NOINTERFACE"/>
        /// </term>
        /// <term>
        /// The attribute value is an <see cref="IUnknown"/> pointer but does not support requested interface.
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
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// The attribute value is not an <see cref="IUnknown"/> pointer.
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
        public HRESULT GetUnknown([In] in GUID guidKey, [In] in IID riid, [Out] out IntPtr ppv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in IID, out IntPtr, HRESULT>)_vTable[17])
                    (thisPtr, guidKey, riid, out ppv);
            }
        }

        /// <summary>
        /// Adds an attribute value with a specified key.
        /// </summary>
        /// <param name="guidKey">
        /// A <see cref="GUID"/> that identifies the value to set.
        /// If this key already exists, the method overwrites the old value.
        /// </param>
        /// <param name="Value">
        /// A <see cref="PROPVARIANT"/> that contains the attribute value.
        /// The method copies the value.
        /// The <see cref="PROPVARIANT"/> type must be one of the types
        /// listed in the <see cref="MF_ATTRIBUTE_TYPE"/> enumeration.
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
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// Insufficient memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDTYPE"/>
        /// </term>
        /// <term>
        /// Invalid attribute type.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method checks whether the <see cref="PROPVARIANT"/> type is one of the attribute types
        /// defined in <see cref="MF_ATTRIBUTE_TYPE"/>, and fails if an unsupported type is used.
        /// However, this method does not check
        /// whether the <see cref="PROPVARIANT"/> is the correct type for the specified attribute GUID.
        /// (There is no programmatic way to associate attribute GUIDs with property types.)
        /// For a list of Media Foundation attributes and their data types, see Media Foundation Attributes.
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
        public HRESULT SetItem([In] in GUID guidKey, [In] in PROPVARIANT Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in PROPVARIANT, HRESULT>)_vTable[18])(thisPtr, guidKey, Value);
            }
        }

        /// <summary>
        /// Removes a key/value pair from the object's attribute list.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies the value to delete.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the specified key does not exist, the method returns <see cref="S_OK"/>.
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
        public HRESULT DeleteItem([In] in GUID guidKey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, HRESULT>)_vTable[19])(thisPtr, guidKey);
            }
        }

        /// <summary>
        /// Removes all key/value pairs from the object's attribute list.
        /// </summary>
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
        public HRESULT DeleteAllItems()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[20])(thisPtr);
            }
        }

        /// <summary>
        /// Associates a <see cref="UINT32"/> value with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies the value to set.
        /// If this key already exists, the method overwrites the old value.
        /// </param>
        /// <param name="unValue">
        /// New value for this key.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve the <see cref="UINT32"/> value, call <see cref="GetUINT32"/>.
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
        public HRESULT SetUINT32([In] in GUID guidKey, [In] UINT32 unValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, UINT32, HRESULT>)_vTable[21])(thisPtr, guidKey, unValue);
            }
        }

        /// <summary>
        /// Associates a <see cref="UINT64"/> value with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies the value to set.
        /// If this key already exists, the method overwrites the old value.
        /// </param>
        /// <param name="unValue">
        /// New value for this key.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve the <see cref="UINT64"/> value, call <see cref="GetUINT64"/>.
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
        public HRESULT SetUINT64([In] in GUID guidKey, [In] UINT64 unValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, UINT64, HRESULT>)_vTable[22])(thisPtr, guidKey, unValue);
            }
        }

        /// <summary>
        /// Associates a <see langword="double"/> value with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies the value to set.
        /// If this key already exists, the method overwrites the old value.
        /// </param>
        /// <param name="fValue">
        /// New value for this key.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve the double value, call <see cref="GetDouble"/>.
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
        public HRESULT SetDouble([In] in GUID guidKey, [In] double fValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, double, HRESULT>)_vTable[23])(thisPtr, guidKey, fValue);
            }
        }

        /// <summary>
        /// Associates a <see cref="GUID"/> value with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies the value to set.
        /// If this key already exists, the method overwrites the old value.
        /// </param>
        /// <param name="guidValue">
        /// New value for this key.
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
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// Insufficient memory.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve the <see cref="GUID"/> value, call <see cref="GetGUID"/>.
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
        public HRESULT SetGUID([In] in GUID guidKey, [In] in GUID guidValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in GUID, HRESULT>)_vTable[24])(thisPtr, guidKey, guidValue);
            }
        }

        /// <summary>
        /// Associates a wide-character string with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies the value to set.
        /// If this key already exists, the method overwrites the old value.
        /// </param>
        /// <param name="wszValue">
        /// Null-terminated wide-character string to associate with this key.
        /// The method stores a copy of the string.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve the string, call <see cref="GetString"/> or <see cref="GetAllocatedString"/>.
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
        public HRESULT SetString([In] in GUID guidKey, [In] LPCWSTR wszValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, LPCWSTR, HRESULT>)_vTable[25])(thisPtr, guidKey, wszValue);
            }
        }

        /// <summary>
        /// Associates a byte array with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies the value to set.
        /// If this key already exists, the method overwrites the old value.
        /// </param>
        /// <param name="pBuf">
        /// Pointer to a byte array to associate with this key.
        /// The method stores a copy of the array.
        /// </param>
        /// <param name="cbBufSize">
        /// Size of the array, in bytes.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve the byte array, call <see cref="GetBlob"/> or <see cref="GetAllocatedBlob"/>.
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
        public HRESULT SetBlob([In] in GUID guidKey, [In] P<UINT8> pBuf, [In] UINT32 cbBufSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, P<UINT8>, UINT32, HRESULT>)_vTable[26])
                    (thisPtr, guidKey, pBuf, cbBufSize);
            }
        }

        /// <summary>
        /// Associates an <see cref="IUnknown"/> pointer with a key.
        /// </summary>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies the value to set.
        /// If this key already exists, the method overwrites the old value.
        /// </param>
        /// <param name="pUnknown">
        /// <see cref="IUnknown"/> pointer to be associated with this key.
        /// </param>
        /// <returns>
        /// <para>
        /// Return value
        /// </para>
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To retrieve the <see cref="IUnknown"/> pointer, call <see cref="GetUnknown"/>.
        /// </para>
        /// <para>
        /// It is not an error to call <see cref="SetUnknown"/>
        /// with <paramref name="pUnknown"/> equal to <see cref="NullRef{IUnknown}"/>.
        /// However, <see cref="GetUnknown"/> will return <see cref="MF_E_INVALIDTYPE"/>.
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
        public HRESULT SetUnknown([In] in GUID guidKey, [In] in IUnknown pUnknown)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in IUnknown, HRESULT>)_vTable[27])(thisPtr, guidKey, pUnknown);
            }
        }

        /// <summary>
        /// Locks the attribute store so that no other thread can access it.
        /// If the attribute store is already locked by another thread,
        /// this method blocks until the other thread unlocks the object.
        /// After calling this method, call <see cref="IMFAttributes.UnlockStore"/> to unlock the object.
        /// </summary>
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method can cause a deadlock if a thread that calls <see cref="LockStore"/>
        /// waits on a thread that calls any other <see cref="IMFAttributes"/> methods on the same object.
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
        public HRESULT LockStore()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[28])(thisPtr);
            }
        }

        /// <summary>
        /// Unlocks the attribute store after a call to the <see cref="LockStore"/> method.
        /// While the object is unlocked, multiple threads can access the object's attributes.
        /// </summary>
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
        public HRESULT UnlockStore()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[29])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves the number of attributes that are set on this object.
        /// </summary>
        /// <param name="pcItems">
        /// Receives the number of attributes.
        /// This parameter must not be <see cref="NullRef{UINT32}"/>.
        /// If this parameter is <see cref="NullRef{UINT32}"/>, an access violation occurs.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To enumerate all of the attributes, call <see cref="GetItemByIndex"/> for each index value.
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
        public HRESULT GetCount([Out] out UINT32 pcItems)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT32, HRESULT>)_vTable[30])(thisPtr, out pcItems);
            }
        }

        /// <summary>
        /// Retrieves an attribute at the specified index.
        /// </summary>
        /// <param name="unIndex">
        /// Index of the attribute to retrieve.
        /// To get the number of attributes, call <see cref="GetCount"/>.
        /// </param>
        /// <param name="pguidKey">
        /// Receives the <see cref="GUID"/> that identifies this attribute.
        /// </param>
        /// <param name="pValue">
        /// Pointer to a <see cref="PROPVARIANT"/> that receives the value.
        /// This parameter can be <see cref="NullRef{PROPVARIANT}"/>.
        /// If it is not <see cref="NullRef{PROPVARIANT}"/>,
        /// the method fills the <see cref="PROPVARIANT"/> with a copy of the attribute value.
        /// Call <see cref="PropVariantClear"/> to free the memory allocated by this method.
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
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// Invalid index.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To enumerate all of an object's attributes in a thread-safe way, do the following:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Call <see cref="LockStore"/> to prevent another thread from adding or deleting attributes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="GetCount"/> to find the number of attributes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="GetItemByIndex"/> to get each attribute by index.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="UnlockStore"/> to unlock the attribute store.
        /// </description>
        /// </item>
        /// </list>
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
        public HRESULT GetItemByIndex([In] UINT32 unIndex, [Out] out GUID pguidKey, [In][Out] ref PROPVARIANT pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT32, out GUID, ref PROPVARIANT, HRESULT>)_vTable[31])
                    (thisPtr, unIndex, out pguidKey, ref pValue);
            }
        }

        /// <summary>
        /// Copies all of the attributes from this object into another attribute store.
        /// </summary>
        /// <param name="pDest">
        /// A pointer to the <see cref="IMFAttributes"/> interface of the attribute store that receives the copy.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method deletes all of the attributes originally stored in <paramref name="pDest"/>.
        /// </para>
        /// <para>
        /// Note  
        /// </para>
        /// <para>
        /// When you call <see cref="CopyAllItems"/> on an <see cref="IMFSample"/>,
        /// which inherits this method, the sample time, duration, and flags are not copied to the destination sample.
        /// You must copy these values to the new sample manually.
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
        public HRESULT CopyAllItems([In] in IMFAttributes pDest)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IMFAttributes, HRESULT>)_vTable[32])(thisPtr, pDest);
            }
        }
    }
}

using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.MediaFoundation.Enums.MF_ATTRIBUTE_TYPE;

namespace Lsj.Util.Win32.MediaFoundation
{
    /// <summary>
    /// Mfapi.h
    /// </summary>
    public static class Mfapi
    {
        private static UINT32 HI32(UINT64 unPacked)
        {
            return (UINT32)(unPacked >> 32);
        }

        private static UINT32 LO32(UINT64 unPacked)
        {
            return (UINT32)(uint)unPacked;
        }

        /// <summary>
        /// <para>
        /// Retrieves an attribute whose value is a size, expressed as a width and height.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfapi/nf-mfapi-mfgetattributesize"/>
        /// </para>
        /// </summary>
        /// <param name="pAttributes">
        /// Pointer to the <see cref="IMFAttributes"/> interface of the attribute store.
        /// </param>
        /// <param name="guidKey">
        /// <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_UINT64"/>.
        /// </param>
        /// <param name="punWidth">
        /// Receives the width.
        /// </param>
        /// <param name="punHeight">
        /// Receives the height.
        /// </param>
        /// <returns>
        /// This function can return one of these values.
        /// </returns>
        /// <remarks>
        /// Some attributes specify a size as a packed <see cref="UINT64"/> value.
        /// Use this function to get the numerator and denominator as separate 32-bit values.
        /// </remarks>
        public static HRESULT MFGetAttributeSize([In] P<IMFAttributes> pAttributes, [In] in GUID guidKey,
            [Out] out UINT32 punWidth, [Out] out UINT32 punHeight)
        {
            return MFGetAttribute2UINT32asUINT64(pAttributes, guidKey, out punWidth, out punHeight);
        }

        /// <summary>
        /// <para>
        /// Gets an attribute whose value is two <see cref="UINT32"/> values packed into a <see cref="UINT64"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfapi/nf-mfapi-mfgetattribute2uint32asuint64"/>
        /// </para>
        /// </summary>
        /// <param name="pAttributes">
        /// A pointer to the <see cref="IMFAttributes"/> interface of the attribute store.
        /// </param>
        /// <param name="guidKey">
        /// A <see cref="GUID"/> that identifies which value to retrieve.
        /// The attribute type must be <see cref="MF_ATTRIBUTE_UINT64"/>.
        /// </param>
        /// <param name="punHigh32">
        /// Receives the high-order 32 bits.
        /// </param>
        /// <param name="punLow32">
        /// Receives the low-order 32 bits.
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
        /// Internally, this function calls <see cref="IMFAttributes.GetUINT64"/> to get the <see cref="UINT64"/> value,
        /// and <see cref="Unpack2UINT32AsUINT64"/> to unpack the two 32-bit values.
        /// </remarks>
        public static HRESULT MFGetAttribute2UINT32asUINT64([In] P<IMFAttributes> pAttributes, [In] in GUID guidKey,
            [Out] out UINT32 punHigh32, [Out] out UINT32 punLow32)
        {
            HRESULT hr = S_OK;

            hr = pAttributes.Value.GetUINT64(guidKey, out var unPacked);
            if (!hr)
            {
                punHigh32 = 0;
                punLow32 = 0;
                return hr;
            }
            Unpack2UINT32AsUINT64(unPacked, out punHigh32, out punLow32);

            return hr;
        }

        /// <summary>
        /// <para>
        /// Gets the low-order and high-order <see cref="UINT32"/> values from a <see cref="UINT64"/> value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfapi/nf-mfapi-unpack2uint32asuint64"/>
        /// </para>
        /// </summary>
        /// <param name="unPacked">
        /// The value to convert.
        /// </param>
        /// <param name="punHigh">
        /// Receives the high-order 32 bits.
        /// </param>
        /// <param name="punLow">
        /// Receives the low-order 32 bits.
        /// </param>
        /// <remarks>
        /// You can use this function to unpack a <see cref="UINT64"/> value
        /// that you receive from the <see cref="IMFAttributes.GetUINT64"/> method.
        /// </remarks>
        public static void Unpack2UINT32AsUINT64([In] UINT64 unPacked, [Out] out UINT32 punHigh, [Out] out UINT32 punLow)
        {
            punHigh = HI32(unPacked);
            punLow = LO32(unPacked);
        }
    }
}

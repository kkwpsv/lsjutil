using Lsj.Util.Win32.MediaFoundation.ComInterfaces;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how to compare the attributes on two objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/ne-mfobjects-mf_attributes_match_type"/>
    /// </para>
    /// </summary>
    public enum MF_ATTRIBUTES_MATCH_TYPE
    {
        /// <summary>
        /// Check whether all the attributes in pThis exist in pTheirs and have the same data,
        /// where pThis is the object whose <see cref="IMFAttributes.Compare"/> method is being called
        /// and pTheirs is the object given in the pTheirs parameter.
        /// </summary>
        MF_ATTRIBUTES_MATCH_OUR_ITEMS = 0,

        /// <summary>
        /// Check whether all the attributes in pTheirs exist in pThis and have the same data,
        /// where pThis is the object whose <see cref="IMFAttributes.Compare"/> method is being called
        /// and pTheirs is the object given in the pTheirs parameter.
        /// </summary>
        MF_ATTRIBUTES_MATCH_THEIR_ITEMS = 1,

        /// <summary>
        /// Check whether both objects have identical attributes with the same data.
        /// </summary>
        MF_ATTRIBUTES_MATCH_ALL_ITEMS = 2,

        /// <summary>
        /// Check whether the attributes that exist in both objects have the same data.
        /// </summary>
        MF_ATTRIBUTES_MATCH_INTERSECTION = 3,

        /// <summary>
        /// Find the object with the fewest number of attributes,
        /// and check if those attributes exist in the other object and have the same data.
        /// </summary>
        MF_ATTRIBUTES_MATCH_SMALLER = 4,
    }
}

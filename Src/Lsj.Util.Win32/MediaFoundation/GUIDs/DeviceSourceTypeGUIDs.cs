using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.MediaFoundation.GUIDs
{
    /// <summary>
    /// Device source type GUIDs
    /// </summary>
    public static class DeviceSourceTypeGUIDs
    {
        /// <summary>
        /// MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_AUDCAP_GUID
        /// </summary>
        public static readonly GUID MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_AUDCAP_GUID = (GUID)"14dd9a1c-7cff-41be-b1b9-ba1ac6ecb571";

        /// <summary>
        /// MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_GUID
        /// </summary>
        public static readonly GUID MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_GUID = (GUID)"8ac3587a-4ae7-42d8-99e0-0a6013eef90f";
    }
}

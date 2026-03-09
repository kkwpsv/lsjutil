using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.MediaFoundation.GUIDs;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lsj.Util.Win32.Extensions.MediaFoundation
{
    /// <summary>
    /// GUID to string helper
    /// </summary>
    public static class GUIDToStringHelper
    {
        private static Dictionary<GUID, string>? _majorMediaTypesCahce;
        /// <summary>
        /// Major media types guid to string
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string MajorMediaTypesToString(in GUID guid)
        {
            _majorMediaTypesCahce ??= typeof(MajorMediaTypes).GetMembers().OfType<FieldInfo>().Where(x => x.FieldType == typeof(GUID) && x.IsStatic).ToDictionary(x => (GUID)x.GetValue(null)!, x => x.Name);

            return _majorMediaTypesCahce.TryGetValue(guid, out var value) ? value : guid.ToString();
        }

        private static Dictionary<GUID, string>? _videoSubTypeCahce;
        /// <summary>
        /// Media subtypes guid to string
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string MediaSubtypesToString(in GUID guid)
        {
            _videoSubTypeCahce ??= typeof(VideoSubtypeGUIDs).GetMembers().OfType<FieldInfo>().Where(x => x.FieldType == typeof(GUID) && x.IsStatic).ToDictionary(x => (GUID)x.GetValue(null)!, x => x.Name);

            return _videoSubTypeCahce.TryGetValue(guid, out var value) ? value : guid.ToString();
        }

        private static Dictionary<GUID, string>? _mediaCaptureEventExtendedTypeCahce;
        /// <summary>
        /// Media subtypes guid to string
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string MediaCaptureEventExtendedTypesToString(in GUID guid)
        {
            _mediaCaptureEventExtendedTypeCahce ??= typeof(MediaCaptureEventExtendedTypeGuids).GetMembers().OfType<FieldInfo>().Where(x => x.FieldType == typeof(GUID) && x.IsStatic).ToDictionary(x => (GUID)x.GetValue(null)!, x => x.Name);

            return _mediaCaptureEventExtendedTypeCahce.TryGetValue(guid, out var value) ? value : guid.ToString();
        }
    }
}

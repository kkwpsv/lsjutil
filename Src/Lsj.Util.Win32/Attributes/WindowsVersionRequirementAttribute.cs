using System;

namespace Lsj.Util.Win32.Attributes
{
    /// <summary>
    /// Windows Version
    /// </summary>
    public enum WindowsVersion
    {
        /// <summary>
        /// Windows 7 (Windows NT 6.1)
        /// </summary>
        Windows7 = 0x06_01_00_00,

        /// <summary>
        /// Windows 8 (Windows NT 6.2)
        /// </summary>
        Windows8 = 0x06_02_00_00,

        /// <summary>
        /// Windows 10 (Windows NT 10.0)
        /// </summary>
        Windows10 = 0x0A_00_00_00,
    }

    /// <summary>
    /// Required Windows version
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Struct)]
    public class WindowsVersionRequirementAttribute : Attribute
    {
        /// <summary>
        /// WindowsVersionRequirementAttribute
        /// </summary>
        /// <param name="version"></param>
        public WindowsVersionRequirementAttribute(WindowsVersion version)
        {
            Version = version;
            switch (version)
            {
                case WindowsVersion.Windows7:
                    BuildNumber = 7600;
                    break;
                case WindowsVersion.Windows8:
                    BuildNumber = 9200;
                    break;
                case WindowsVersion.Windows10:
                    BuildNumber = 10240;
                    break;

            }
        }

        /// <summary>
        /// WindowsVersionRequirementAttribute
        /// </summary>
        /// <param name="version"></param>
        /// <param name="buildNumber"></param>
        public WindowsVersionRequirementAttribute(WindowsVersion version, int buildNumber)
        {
            Version = version;
            BuildNumber = buildNumber;
        }

        /// <summary>
        /// Version
        /// </summary>
        public WindowsVersion Version { get; }

        /// <summary>
        /// Build Number
        /// </summary>
        public int BuildNumber { get; }
    }
}

using System;

namespace Lsj.Util.Win32.Attributes
{
    /// <summary>
    /// Windows Version
    /// </summary>
    public enum WindowsVersion
    {
        /// <summary>
        /// Windows NT 4.0
        /// </summary>
        WindowsNT40 = 0x04_00_00_00,

        /// <summary>
        /// Windows 2000 (Windows NT 5.0)
        /// </summary>
        Windows2000 = 0x05_00_00_00,

        /// <summary>
        /// Windows XP (Windows NT 5.1)
        /// </summary>
        WindowsXP = 0x05_01_00_00,

        /// <summary>
        /// Windows Vista (Windows NT 6.0)
        /// </summary>
        WindowsVista = 0x06_00_00_00,

        /// <summary>
        /// Windows 7 (Windows NT 6.1)
        /// </summary>
        Windows7 = 0x06_01_00_00,

        /// <summary>
        /// Windows 8 (Windows NT 6.2)
        /// </summary>
        Windows8 = 0x06_02_00_00,

        /// <summary>
        /// Windows 8.1 (Windows NT 6.3)
        /// </summary>
        Windows8_1 = 0x06_03_00_00,

        /// <summary>
        /// Windows 10 (Windows NT 10.0)
        /// </summary>
        Windows10 = 0x0A_00_00_00,

        /// <summary>
        /// Windows 11 (Windows NT 10.0)
        /// </summary>
        Windows11 = 0x0A_00_00_0B,
    }

    /// <summary>
    /// Required Windows version
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Struct | AttributeTargets.Field)]
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
                case WindowsVersion.Windows2000:
                    BuildNumber = 2195;
                    break;
                case WindowsVersion.WindowsXP:
                    BuildNumber = 2600;
                    break;
                case WindowsVersion.WindowsVista:
                    BuildNumber = 6000;
                    break;
                case WindowsVersion.Windows7:
                    BuildNumber = 7600;
                    break;
                case WindowsVersion.Windows8:
                    BuildNumber = 9200;
                    break;
                case WindowsVersion.Windows8_1:
                    BuildNumber = 9600;
                    break;
                case WindowsVersion.Windows10:
                    BuildNumber = BuildNumbers.Windows10_1507;
                    break;
                case WindowsVersion.Windows11:
                    BuildNumber = BuildNumbers.Windows11_21H2;
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

        /// <summary>
        /// Note
        /// </summary>
        public string? Note { get; set; }
    }
}

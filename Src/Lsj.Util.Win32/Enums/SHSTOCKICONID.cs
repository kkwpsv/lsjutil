using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Used by <see cref="SHGetStockIconInfo"/> to identify which stock system icon to retrieve.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/ne-shellapi-shstockiconid
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="SIID_INVALID"/>, with a value of -1, indicates an invalid <see cref="SHSTOCKICONID"/> value.
    /// </remarks>
    public enum SHSTOCKICONID
    {
        /// <summary>
        /// An invalid <see cref="SHSTOCKICONID"/> value.
        /// </summary>
        SIID_INVALID = -1,

        /// <summary>
        /// Document of a type with no associated application.
        /// </summary>
        SIID_DOCNOASSOC = 0,

        /// <summary>
        /// Document of a type with an associated application.
        /// </summary>
        SIID_DOCASSOC = 1,

        /// <summary>
        /// Generic application with no custom icon.
        /// </summary>
        SIID_APPLICATION = 2,

        /// <summary>
        /// Folder (generic, unspecified state).
        /// </summary>
        SIID_FOLDER = 3,

        /// <summary>
        /// Folder (open).
        /// </summary>
        SIID_FOLDEROPEN = 4,

        /// <summary>
        /// 5.25-inch disk drive.
        /// </summary>
        SIID_DRIVE525 = 5,

        /// <summary>
        /// 3.5-inch disk drive.
        /// </summary>
        SIID_DRIVE35 = 6,

        /// <summary>
        /// Removable drive.
        /// </summary>
        SIID_DRIVEREMOVE = 7,

        /// <summary>
        /// Fixed drive (hard disk).
        /// </summary>
        SIID_DRIVEFIXED = 8,

        /// <summary>
        /// Network drive (connected).
        /// </summary>
        SIID_DRIVENET = 9,

        /// <summary>
        /// Network drive (disconnected).
        /// </summary>
        SIID_DRIVENETDISABLED = 10,

        /// <summary>
        /// CD drive.
        /// </summary>
        SIID_DRIVECD = 11,

        /// <summary>
        /// RAM disk drive.
        /// </summary>
        SIID_DRIVERAM = 12,

        /// <summary>
        /// The entire network.
        /// </summary>
        SIID_WORLD = 13,

        /// <summary>
        /// A computer on the network.
        /// </summary>
        SIID_SERVER = 15,

        /// <summary>
        /// A local printer or print destination.
        /// </summary>
        SIID_PRINTER = 16,

        /// <summary>
        /// The Network virtual folder (FOLDERID_NetworkFolder/CSIDL_NETWORK).
        /// </summary>
        SIID_MYNETWORK = 17,

        /// <summary>
        /// The Search feature.
        /// </summary>
        SIID_FIND = 22,

        /// <summary>
        /// The Help and Support feature.
        /// </summary>
        SIID_HELP = 23,

        /// <summary>
        /// Overlay for a shared item.
        /// </summary>
        SIID_SHARE = 28,

        /// <summary>
        /// Overlay for a shortcut.
        /// </summary>
        SIID_LINK = 29,

        /// <summary>
        /// Overlay for items that are expected to be slow to access.
        /// </summary>
        SIID_SLOWFILE = 30,

        /// <summary>
        /// The Recycle Bin (empty).
        /// </summary>
        SIID_RECYCLER = 31,

        /// <summary>
        /// The Recycle Bin (not empty).
        /// </summary>
        SIID_RECYCLERFULL = 32,

        /// <summary>
        /// Audio CD media.
        /// </summary>
        SIID_MEDIACDAUDIO = 40,

        /// <summary>
        /// Security lock.
        /// </summary>
        SIID_LOCK = 47,

        /// <summary>
        /// A virtual folder that contains the results of a search.
        /// </summary>
        SIID_AUTOLIST = 49,

        /// <summary>
        /// A network printer.
        /// </summary>
        SIID_PRINTERNET = 50,

        /// <summary>
        /// A server shared on a network.
        /// </summary>
        SIID_SERVERSHARE = 51,

        /// <summary>
        /// A local fax printer.
        /// </summary>
        SIID_PRINTERFAX = 52,

        /// <summary>
        /// A network fax printer.
        /// </summary>
        SIID_PRINTERFAXNET = 53,

        /// <summary>
        /// A file that receives the output of a Print to file operation.
        /// </summary>
        SIID_PRINTERFILE = 54,

        /// <summary>
        /// A category that results from a Stack by command to organize the contents of a folder.
        /// </summary>
        SIID_STACK = 55,

        /// <summary>
        /// Super Video CD (SVCD) media.
        /// </summary>
        SIID_MEDIASVCD = 56,

        /// <summary>
        /// A folder that contains only subfolders as child items.
        /// </summary>
        SIID_STUFFEDFOLDER = 57,

        /// <summary>
        /// Unknown drive type.
        /// </summary>
        SIID_DRIVEUNKNOWN = 58,

        /// <summary>
        /// DVD drive.
        /// </summary>
        SIID_DRIVEDVD = 59,

        /// <summary>
        /// DVD media.
        /// </summary>
        SIID_MEDIADVD = 60,

        /// <summary>
        /// DVD-RAM Media
        /// </summary>
        SIID_MEDIADVDRAM = 61,

        /// <summary>
        /// DVD-RW Media
        /// </summary>
        SIID_MEDIADVDRW = 62,

        /// <summary>
        /// DVD-R Media
        /// </summary>
        SIID_MEDIADVDR = 63,

        /// <summary>
        /// DVD-ROM Media
        /// </summary>
        SIID_MEDIADVDROM = 64,

        /// <summary>
        /// CD+ (enhanced audio CD) media.
        /// </summary>
        SIID_MEDIACDAUDIOPLUS = 65,

        /// <summary>
        /// CD-RW media.
        /// </summary>
        SIID_MEDIACDRW = 66,

        /// <summary>
        /// CD-R Media
        /// </summary>
        SIID_MEDIACDR = 67,

        /// <summary>
        /// A writeable CD in the process of being burned.
        /// </summary>
        SIID_MEDIACDBURN = 68,

        /// <summary>
        /// Blank writable CD media.
        /// </summary>
        SIID_MEDIABLANKCD = 69,

        /// <summary>
        /// CD-ROM Media
        /// </summary>
        SIID_MEDIACDROM = 70,

        /// <summary>
        /// An audio file.
        /// </summary>
        SIID_AUDIOFILES = 71,

        /// <summary>
        /// An image file.
        /// </summary>
        SIID_IMAGEFILES = 72,

        /// <summary>
        /// A video file.
        /// </summary>
        SIID_VIDEOFILES = 73,

        /// <summary>
        /// A mixed file.
        /// </summary>
        SIID_MIXEDFILES = 74,

        /// <summary>
        /// Folder back.
        /// </summary>
        SIID_FOLDERBACK = 75,

        /// <summary>
        /// Folder front.
        /// </summary>
        SIID_FOLDERFRONT = 76,

        /// <summary>
        /// Security shield. Use for UAC prompts only.
        /// </summary>
        SIID_SHIELD = 77,

        /// <summary>
        /// Warning.
        /// </summary>
        SIID_WARNING = 78,

        /// <summary>
        /// Informational.
        /// </summary>
        SIID_INFO = 79,

        /// <summary>
        /// Error.
        /// </summary>
        SIID_ERROR = 80,

        /// <summary>
        /// Key.
        /// </summary>
        SIID_KEY = 81,

        /// <summary>
        /// Software.
        /// </summary>
        SIID_SOFTWARE = 82,

        /// <summary>
        /// A UI item, such as a button, that issues a rename command.
        /// </summary>
        SIID_RENAME = 83,

        /// <summary>
        /// A UI item, such as a button, that issues a delete command.
        /// </summary>
        SIID_DELETE = 84,

        /// <summary>
        /// Audio DVD media.
        /// </summary>
        SIID_MEDIAAUDIODVD = 85,

        /// <summary>
        /// Movie DVD media.
        /// </summary>
        SIID_MEDIAMOVIEDVD = 86,

        /// <summary>
        /// Enhanced CD media.
        /// </summary>
        SIID_MEDIAENHANCEDCD = 87,

        /// <summary>
        /// Enhanced DVD media.
        /// </summary>
        SIID_MEDIAENHANCEDDVD = 88,

        /// <summary>
        /// High definition DVD media in the HD DVD format.
        /// </summary>
        SIID_MEDIAHDDVD = 89,

        /// <summary>
        /// High definition DVD media in the Blu-ray Disc™ format.
        /// </summary>
        SIID_MEDIABLURAY = 90,

        /// <summary>
        /// Video CD (VCD) media.
        /// </summary>
        SIID_MEDIAVCD = 91,

        /// <summary>
        /// DVD+R media.
        /// </summary>
        SIID_MEDIADVDPLUSR = 92,

        /// <summary>
        /// DVD+RW media.
        /// </summary>
        SIID_MEDIADVDPLUSRW = 93,

        /// <summary>
        /// A desktop computer.
        /// </summary>
        SIID_DESKTOPPC = 94,

        /// <summary>
        /// A mobile computer (laptop).
        /// </summary>
        SIID_MOBILEPC = 95,

        /// <summary>
        /// The User Accounts Control Panel item.
        /// </summary>
        SIID_USERS = 96,

        /// <summary>
        /// Smart media.
        /// </summary>
        SIID_MEDIASMARTMEDIA = 97,

        /// <summary>
        /// CompactFlash media.
        /// </summary>
        SIID_MEDIACOMPACTFLASH = 98,

        /// <summary>
        /// A cell phone.
        /// </summary>
        SIID_DEVICECELLPHONE = 99,

        /// <summary>
        /// A digital camera.
        /// </summary>
        SIID_DEVICECAMERA = 100,

        /// <summary>
        /// A digital video camera.
        /// </summary>
        SIID_DEVICEVIDEOCAMERA = 101,

        /// <summary>
        /// An audio player.
        /// </summary>
        SIID_DEVICEAUDIOPLAYER = 102,

        /// <summary>
        /// Connect to network.
        /// </summary>
        SIID_NETWORKCONNECT = 103,

        /// <summary>
        /// The Network and Internet Control Panel item.
        /// </summary>
        SIID_INTERNET = 104,

        /// <summary>
        /// A compressed file with a .zip file name extension.
        /// </summary>
        SIID_ZIPFILE = 105,

        /// <summary>
        /// The Additional Options Control Panel item.
        /// </summary>
        SIID_SETTINGS = 106,

        /// <summary>
        /// Windows Vista with Service Pack 1 (SP1) and later.
        /// High definition DVD drive (any type - HD DVD-ROM, HD DVD-R, HD-DVD-RAM) that uses the HD DVD format.
        /// </summary>
        SIID_DRIVEHDDVD = 132,

        /// <summary>
        /// Windows Vista with SP1 and later.
        /// High definition DVD drive (any type - BD-ROM, BD-R, BD-RE) that uses the Blu-ray Disc format.
        /// </summary>
        SIID_DRIVEBD = 133,

        /// <summary>
        /// Windows Vista with SP1 and later.
        /// High definition DVD-ROM media in the HD DVD-ROM format.
        /// </summary>
        SIID_MEDIAHDDVDROM = 134,

        /// <summary>
        /// Windows Vista with SP1 and later.
        /// High definition DVD-R media in the HD DVD-R format.
        /// </summary>
        SIID_MEDIAHDDVDR = 135,

        /// <summary>
        /// Windows Vista with SP1 and later. High definition DVD-RAM media in the HD DVD-RAM format.
        /// </summary>
        SIID_MEDIAHDDVDRAM = 136,

        /// <summary>
        /// Windows Vista with SP1 and later.
        /// High definition DVD-ROM media in the Blu-ray Disc BD-ROM format.
        /// </summary>
        SIID_MEDIABDROM = 137,

        /// <summary>
        /// Windows Vista with SP1 and later.
        /// High definition write-once media in the Blu-ray Disc BD-R format.
        /// </summary>
        SIID_MEDIABDR = 138,

        /// <summary>
        /// Windows Vista with SP1 and later.
        /// High definition read/write media in the Blu-ray Disc BD-RE format.
        /// </summary>
        SIID_MEDIABDRE = 139,

        /// <summary>
        /// Windows Vista with SP1 and later.
        /// A cluster disk array.
        /// </summary>
        SIID_CLUSTEREDDRIVE = 140,

        /// <summary>
        /// The highest valid value in the enumeration. Values over 160 are Windows 7-only icons.
        /// </summary>
        SIID_MAX_ICONS = 181,
    }
}

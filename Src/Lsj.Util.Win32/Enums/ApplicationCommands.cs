using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Application commands
    /// </summary>
    public enum ApplicationCommands : short
    {
        /// <summary>
        /// APPCOMMAND_BROWSER_BACKWARD
        /// </summary>
        APPCOMMAND_BROWSER_BACKWARD = 1,

        /// <summary>
        /// APPCOMMAND_BROWSER_FORWARD
        /// </summary>
        APPCOMMAND_BROWSER_FORWARD = 2,

        /// <summary>
        /// APPCOMMAND_BROWSER_REFRESH
        /// </summary>
        APPCOMMAND_BROWSER_REFRESH = 3,

        /// <summary>
        /// APPCOMMAND_BROWSER_STOP
        /// </summary>
        APPCOMMAND_BROWSER_STOP = 4,

        /// <summary>
        /// APPCOMMAND_BROWSER_SEARCH
        /// </summary>
        APPCOMMAND_BROWSER_SEARCH = 5,

        /// <summary>
        /// APPCOMMAND_BROWSER_FAVORITES
        /// </summary>
        APPCOMMAND_BROWSER_FAVORITES = 6,

        /// <summary>
        /// APPCOMMAND_BROWSER_HOME
        /// </summary>
        APPCOMMAND_BROWSER_HOME = 7,

        /// <summary>
        /// APPCOMMAND_VOLUME_MUTE
        /// </summary>
        APPCOMMAND_VOLUME_MUTE = 8,

        /// <summary>
        /// APPCOMMAND_VOLUME_DOWN
        /// </summary>
        APPCOMMAND_VOLUME_DOWN = 9,

        /// <summary>
        /// APPCOMMAND_VOLUME_UP
        /// </summary>
        APPCOMMAND_VOLUME_UP = 10,

        /// <summary>
        /// APPCOMMAND_MEDIA_NEXTTRACK
        /// </summary>
        APPCOMMAND_MEDIA_NEXTTRACK = 11,

        /// <summary>
        /// APPCOMMAND_MEDIA_PREVIOUSTRACK
        /// </summary>
        APPCOMMAND_MEDIA_PREVIOUSTRACK = 12,

        /// <summary>
        /// APPCOMMAND_MEDIA_STOP
        /// </summary>
        APPCOMMAND_MEDIA_STOP = 13,

        /// <summary>
        /// APPCOMMAND_MEDIA_PLAY_PAUSE
        /// </summary>
        APPCOMMAND_MEDIA_PLAY_PAUSE = 14,

        /// <summary>
        /// APPCOMMAND_LAUNCH_MAIL
        /// </summary>
        APPCOMMAND_LAUNCH_MAIL = 15,

        /// <summary>
        /// APPCOMMAND_LAUNCH_MEDIA_SELECT
        /// </summary>
        APPCOMMAND_LAUNCH_MEDIA_SELECT = 16,

        /// <summary>
        /// APPCOMMAND_LAUNCH_APP1
        /// </summary>
        APPCOMMAND_LAUNCH_APP1 = 17,

        /// <summary>
        /// APPCOMMAND_LAUNCH_APP2
        /// </summary>
        APPCOMMAND_LAUNCH_APP2 = 18,

        /// <summary>
        /// APPCOMMAND_BASS_DOWN
        /// </summary>
        APPCOMMAND_BASS_DOWN = 19,

        /// <summary>
        /// APPCOMMAND_BASS_BOOST
        /// </summary>
        APPCOMMAND_BASS_BOOST = 20,

        /// <summary>
        /// APPCOMMAND_BASS_UP
        /// </summary>
        APPCOMMAND_BASS_UP = 21,

        /// <summary>
        /// APPCOMMAND_TREBLE_DOWN
        /// </summary>
        APPCOMMAND_TREBLE_DOWN = 22,

        /// <summary>
        /// APPCOMMAND_TREBLE_UP
        /// </summary>
        APPCOMMAND_TREBLE_UP = 23,

        /// <summary>
        /// APPCOMMAND_MICROPHONE_VOLUME_MUTE
        /// </summary>
        APPCOMMAND_MICROPHONE_VOLUME_MUTE = 24,

        /// <summary>
        /// APPCOMMAND_MICROPHONE_VOLUME_DOWN
        /// </summary>
        APPCOMMAND_MICROPHONE_VOLUME_DOWN = 25,

        /// <summary>
        /// APPCOMMAND_MICROPHONE_VOLUME_UP
        /// </summary>
        APPCOMMAND_MICROPHONE_VOLUME_UP = 26,

        /// <summary>
        /// APPCOMMAND_HELP
        /// </summary>
        APPCOMMAND_HELP = 27,

        /// <summary>
        /// APPCOMMAND_FIND
        /// </summary>
        APPCOMMAND_FIND = 28,

        /// <summary>
        /// APPCOMMAND_NEW
        /// </summary>
        APPCOMMAND_NEW = 29,

        /// <summary>
        /// APPCOMMAND_OPEN
        /// </summary>
        APPCOMMAND_OPEN = 30,

        /// <summary>
        /// APPCOMMAND_CLOSE
        /// </summary>
        APPCOMMAND_CLOSE = 31,

        /// <summary>
        /// APPCOMMAND_SAVE
        /// </summary>
        APPCOMMAND_SAVE = 32,

        /// <summary>
        /// APPCOMMAND_PRINT
        /// </summary>
        APPCOMMAND_PRINT = 33,

        /// <summary>
        /// APPCOMMAND_UNDO
        /// </summary>
        APPCOMMAND_UNDO = 34,

        /// <summary>
        /// APPCOMMAND_REDO
        /// </summary>
        APPCOMMAND_REDO = 35,

        /// <summary>
        /// APPCOMMAND_COPY
        /// </summary>
        APPCOMMAND_COPY = 36,

        /// <summary>
        /// APPCOMMAND_CUT
        /// </summary>
        APPCOMMAND_CUT = 37,

        /// <summary>
        /// APPCOMMAND_PASTE
        /// </summary>
        APPCOMMAND_PASTE = 38,

        /// <summary>
        /// APPCOMMAND_REPLY_TO_MAIL
        /// </summary>
        APPCOMMAND_REPLY_TO_MAIL = 39,

        /// <summary>
        /// APPCOMMAND_FORWARD_MAIL
        /// </summary>
        APPCOMMAND_FORWARD_MAIL = 40,

        /// <summary>
        /// APPCOMMAND_SEND_MAIL
        /// </summary>
        APPCOMMAND_SEND_MAIL = 41,

        /// <summary>
        /// APPCOMMAND_SPELL_CHECK
        /// </summary>
        APPCOMMAND_SPELL_CHECK = 42,

        /// <summary>
        /// APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE
        /// </summary>
        APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE = 43,

        /// <summary>
        /// APPCOMMAND_MIC_ON_OFF_TOGGLE
        /// </summary>
        APPCOMMAND_MIC_ON_OFF_TOGGLE = 44,

        /// <summary>
        /// APPCOMMAND_CORRECTION_LIST
        /// </summary>
        APPCOMMAND_CORRECTION_LIST = 45,

        /// <summary>
        /// APPCOMMAND_MEDIA_PLAY
        /// </summary>
        APPCOMMAND_MEDIA_PLAY = 46,

        /// <summary>
        /// APPCOMMAND_MEDIA_PAUSE
        /// </summary>
        APPCOMMAND_MEDIA_PAUSE = 47,

        /// <summary>
        /// APPCOMMAND_MEDIA_RECORD
        /// </summary>
        APPCOMMAND_MEDIA_RECORD = 48,

        /// <summary>
        /// APPCOMMAND_MEDIA_FAST_FORWARD
        /// </summary>
        APPCOMMAND_MEDIA_FAST_FORWARD = 49,

        /// <summary>
        /// APPCOMMAND_MEDIA_REWIND
        /// </summary>
        APPCOMMAND_MEDIA_REWIND = 50,

        /// <summary>
        /// APPCOMMAND_MEDIA_CHANNEL_UP
        /// </summary>
        APPCOMMAND_MEDIA_CHANNEL_UP = 51,

        /// <summary>
        /// APPCOMMAND_MEDIA_CHANNEL_DOWN
        /// </summary>
        APPCOMMAND_MEDIA_CHANNEL_DOWN = 52,

        /// <summary>
        /// APPCOMMAND_DELETE
        /// </summary>
        APPCOMMAND_DELETE = 53,

        /// <summary>
        /// APPCOMMAND_DWM_FLIP3D
        /// </summary>
        APPCOMMAND_DWM_FLIP3D = 54,
    }
}

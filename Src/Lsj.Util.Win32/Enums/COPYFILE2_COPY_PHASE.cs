﻿using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Structs.COPYFILE2_MESSAGE;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the phase of a copy at the time of an error.
    /// This is used in the <see cref="COPYFILE2_MESSAGE_Error"/> structure embedded in the <see cref="COPYFILE2_MESSAGE"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ne-winbase-copyfile2_copy_phase"/>
    /// </para>
    /// </summary>
    public enum COPYFILE2_COPY_PHASE
    {
        /// <summary>
        /// The copy had not yet started processing.
        /// </summary>
        COPYFILE2_PHASE_NONE,

        /// <summary>
        /// The source was being prepared including opening a handle to the source.
        /// This phase happens once per stream copy operation.
        /// </summary>
        COPYFILE2_PHASE_PREPARE_SOURCE,

        /// <summary>
        /// The destination was being prepared including opening a handle to the destination.
        /// This phase happens once per stream copy operation.
        /// </summary>
        COPYFILE2_PHASE_PREPARE_DEST,

        /// <summary>
        /// The source file was being read.
        /// This phase happens one or more times per stream copy operation.
        /// </summary>
        COPYFILE2_PHASE_READ_SOURCE,

        /// <summary>
        /// The destination file was being written.
        /// This phase happens one or more times per stream copy operation.
        /// </summary>
        COPYFILE2_PHASE_WRITE_DESTINATION,

        /// <summary>
        /// Both the source and destination were on the same remote server and the copy was being processed remotely.
        /// This phase happens once per stream copy operation.
        /// </summary>
        COPYFILE2_PHASE_SERVER_COPY,

        /// <summary>
        /// The copy operation was processing symbolic links and/or reparse points.
        /// This phase happens once per file copy operation.
        /// </summary>
        COPYFILE2_PHASE_NAMEGRAFT_COPY,

        /// <summary>
        /// One greater than the maximum value. Valid values for this enumeration will be less than this value.
        /// </summary>
        COPYFILE2_PHASE_MAX
    }
}

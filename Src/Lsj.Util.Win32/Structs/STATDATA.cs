using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information used to specify each advisory connection.
    /// It is used for enumerating current advisory connections.
    /// It holds data returned by the <see cref="IEnumSTATDATA"/> enumerator.
    /// This enumerator interface is returned by <see cref="IDataObject.DAdvise"/>.
    /// Each advisory connection is specified by a unique <see cref="STATDATA"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ns-objidl-statdata"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STATDATA
    {
        /// <summary>
        /// The FORMATETC structure for the data of interest to the advise sink.
        /// The advise sink receives notification of changes to the data specified by this <see cref="FORMATETC"/> structure.
        /// </summary>
        public FORMATETC formatetc;

        /// <summary>
        /// The <see cref="ADVF"/> enumeration value that determines when the advisory sink is notified of changes in the data.
        /// </summary>
        public ADVF advf;

        /// <summary>
        /// The pointer for the <see cref="IAdviseSink"/> interface that will receive change notifications.
        /// </summary>
        public IAdviseSink pAdvSink;

        /// <summary>
        /// The token that uniquely identifies the advisory connection.
        /// This token is returned by the method that sets up the advisory connection.
        /// </summary>
        public DWORD dwConnection;
    }
}

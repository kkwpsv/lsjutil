using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.TYMED;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a generalized global memory handle used for data transfer operations
    /// by the <see cref="IAdviseSink"/>, <see cref="IDataObject"/>, and <see cref="IOleCache"/> interfaces.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ns-objidl-ustgmedium-r1"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STGMEDIUM
    {
#pragma warning disable IDE1006
        /// <summary>
        /// The type of storage medium.
        /// The marshaling and unmarshaling routines use this value to determine which union member was used.
        /// This value must be one of the elements of the <see cref="TYMED"/> enumeration.
        /// </summary>
        public TYMED tymed;

        /// <summary>
        /// Handle, string, or interface pointer that the receiving process can use to access the data being transferred.
        /// If tymed is <see cref="TYMED_NULL"/>, the union member is undefined; otherwise, it is one of the following values.
        /// </summary>
        private STGMEDIUM_DUMMYUNIONNAME _STGMEDIUM_DUMMYUNIONNAME;

        /// <summary>
        /// Bitmap handle. The tymed member is <see cref="TYMED_GDI"/>.
        /// </summary>
        public HBITMAP hBitmap
        {
            get => _STGMEDIUM_DUMMYUNIONNAME.hBitmap;
            set => _STGMEDIUM_DUMMYUNIONNAME.hBitmap = value;
        }

        /// <summary>
        /// Metafile handle. The tymed member is <see cref="TYMED_MFPICT"/>.
        /// </summary>

        public HMETAFILEPICT hMetaFilePict
        {
            get => _STGMEDIUM_DUMMYUNIONNAME.hMetaFilePict;
            set => _STGMEDIUM_DUMMYUNIONNAME.hMetaFilePict = value;
        }

        /// <summary>
        /// Enhanced metafile handle. The tymed member is <see cref="TYMED_ENHMF"/>.
        /// </summary>
        public HENHMETAFILE hEnhMetaFile
        {
            get => _STGMEDIUM_DUMMYUNIONNAME.hEnhMetaFile;
            set => _STGMEDIUM_DUMMYUNIONNAME.hEnhMetaFile = value;
        }

        /// <summary>
        /// Global memory handle. The tymed member is <see cref="TYMED_HGLOBAL"/>.
        /// </summary>
        public HGLOBAL hGlobal
        {
            get => _STGMEDIUM_DUMMYUNIONNAME.hGlobal;
            set => _STGMEDIUM_DUMMYUNIONNAME.hGlobal = value;
        }

        /// <summary>
        /// Pointer to the path of a disk file that contains the data. The tymed member is <see cref="TYMED_FILE"/>.
        /// </summary>
        public IntPtr lpszFileName
        {
            get => _STGMEDIUM_DUMMYUNIONNAME.lpszFileName;
            set => _STGMEDIUM_DUMMYUNIONNAME.lpszFileName = value;
        }

        /// <summary>
        /// Pointer to an <see cref="IStream"/> interface. The tymed member is <see cref="TYMED_ISTREAM"/>.
        /// </summary>
        public IntPtr pstm
        {
            get => _STGMEDIUM_DUMMYUNIONNAME.pstm;
            set => _STGMEDIUM_DUMMYUNIONNAME.pstm = value;
        }

        /// <summary>
        /// Pointer to an IStorage interface. The tymed member is TYMED_ISTORAGE.
        /// </summary>
        public IntPtr pstg
        {
            get => _STGMEDIUM_DUMMYUNIONNAME.pstg;
            set => _STGMEDIUM_DUMMYUNIONNAME.pstg = value;
        }

        /// <summary>
        /// Pointer to an interface instance that allows the sending process to control the way the storage is released
        /// when the receiving process calls the <see cref="ReleaseStgMedium"/> function.
        /// If <see cref="pUnkForRelease"/> is <see cref="NULL"/>, <see cref="ReleaseStgMedium"/> uses default procedures to release the storage;
        /// otherwise, <see cref="ReleaseStgMedium"/> uses the specified <see cref="IUnknown"/> interface.
        /// </summary>
        public IntPtr pUnkForRelease;
#pragma warning restore IDE1006

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct STGMEDIUM_DUMMYUNIONNAME
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public HBITMAP hBitmap;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public HMETAFILEPICT hMetaFilePict;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public HENHMETAFILE hEnhMetaFile;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public HGLOBAL hGlobal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public IntPtr lpszFileName;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public IntPtr pstm;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public IntPtr pstg;
        }
    }
}

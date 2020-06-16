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
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ns-objidl-ustgmedium~r1
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
        private UnionStruct DUMMYUNIONNAME;

        /// <summary>
        /// Bitmap handle. The tymed member is <see cref="TYMED_GDI"/>.
        /// </summary>
        public HBITMAP hBitmap
        {
            get => DUMMYUNIONNAME.Struct1;
            set => DUMMYUNIONNAME.Struct1 = value;
        }

        /// <summary>
        /// Metafile handle. The tymed member is <see cref="TYMED_MFPICT"/>.
        /// </summary>

        public HMETAFILEPICT hMetaFilePict
        {
            get => DUMMYUNIONNAME.Struct2;
            set => DUMMYUNIONNAME.Struct2 = value;
        }

        /// <summary>
        /// Enhanced metafile handle. The tymed member is <see cref="TYMED_ENHMF"/>.
        /// </summary>
        public HENHMETAFILE hEnhMetaFile
        {
            get => DUMMYUNIONNAME.Struct3;
            set => DUMMYUNIONNAME.Struct3 = value;
        }

        /// <summary>
        /// Global memory handle. The tymed member is <see cref="TYMED_HGLOBAL"/>.
        /// </summary>
        public HGLOBAL hGlobal
        {
            get => DUMMYUNIONNAME.Struct4;
            set => DUMMYUNIONNAME.Struct4 = value;
        }

        /// <summary>
        /// Pointer to the path of a disk file that contains the data. The tymed member is <see cref="TYMED_FILE"/>.
        /// </summary>
        public string lpszFileName
        {
            get => DUMMYUNIONNAME.Struct5;
            set => DUMMYUNIONNAME.Struct5 = value;
        }

        /// <summary>
        /// Pointer to an <see cref="IStream"/> interface. The tymed member is <see cref="TYMED_ISTREAM"/>.
        /// </summary>
        public IStream pstm
        {
            get => DUMMYUNIONNAME.Struct6;
            set => DUMMYUNIONNAME.Struct6 = value;
        }

        /// <summary>
        /// Pointer to an IStorage interface. The tymed member is TYMED_ISTORAGE.
        /// </summary>
        public IStorage pstg
        {
            get => DUMMYUNIONNAME.Struct7;
            set => DUMMYUNIONNAME.Struct7 = value;
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
        private struct UnionStruct
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public HBITMAP Struct1;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public HMETAFILEPICT Struct2;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public HENHMETAFILE Struct3;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public HGLOBAL Struct4;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public string Struct5;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public IStream Struct6;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public IStorage Struct7;
        }
    }
}

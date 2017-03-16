using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    /// <summary>
    /// Version
    /// </summary>
    public struct Version
    {
        int m_major;
        int m_minor;
        int m_build;
        int m_revision;

        /// <summary>
        /// Majlr
        /// </summary>
        public int Major => m_major;
        /// <summary>
        /// Minor
        /// </summary>
        public int Minor => m_minor;
        /// <summary>
        /// Build
        /// </summary>
        public int Build => m_build;
        /// <summary>
        /// Revision
        /// </summary>
        public int Revision => m_revision;
        /// <summary>
        /// Initialize a instance
        /// </summary>
        /// <param name="major"></param>
        public Version(int major) : this(major, 0)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        public Version(int major, int minor) : this(major,minor,0)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        public Version(int major, int minor,int build) : this(major, minor, build,0)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <param name="revision"></param>
        public Version(int major, int minor, int build, int revision)
        {
            m_major = major;
            m_minor = minor;
            m_build = build;
            m_revision = revision;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString(4);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string ToString(int length)
        {
            if (length >= 4)
            {
                return $"{m_major}.{m_minor}.{m_build}.{m_revision}";
            }
            else if(length == 3)
            {
                return $"{m_major}.{m_minor}.{m_build}";
            }
            else if (length == 2)
            {
                return $"{m_major}.{m_minor}";
            }
            else
            {
                return $"{m_major}";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Version)
            {
                var o = (Version)obj;
                return (this.Major == o.Major) && (this.Minor == o.Minor) && (this.Build == o.Build) && (this.Revision == o.Revision);
            }
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator == (Version a,Version b)=>(a.Major == b.Major) && (a.Minor == b.Minor) && (a.Build == b.Build) && (a.Revision == b.Revision);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Version a, Version b) =>!(a==b);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()=> 0 | (this.Major & 15) << 28 | (this.Minor & 255) << 20 | (this.Build & 255) << 12 | (this.Revision & 4095);
    }
}
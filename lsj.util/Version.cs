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
        /// Initial a instance
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


    }
}
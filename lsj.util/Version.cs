using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    public struct Version
    {
        int m_major;
        int m_minor;
        int m_build;
        int m_revision;

        public int Major => m_major;
        public int Minor => m_minor;
        public int Build => m_build;
        public int Revision => m_revision;
        public Version(int major) : this(major, 0)
        {
        }
        public Version(int major, int minor) : this(major,minor,0)
        {
        }
        public Version(int major, int minor,int build) : this(major, minor, build,0)
        {
        }
        public Version(int major, int minor, int build, int revision)
        {
            m_major = major;
            m_minor = minor;
            m_build = build;
            m_revision = revision;
        }
        public override string ToString() => ToString(4);
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
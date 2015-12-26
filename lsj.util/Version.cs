using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    public struct Version
    {
        int m_Major;
        int m_Minor;
        int m_Build;
        int m_Revision;

        public int Major => m_Major;
        public int Minor => m_Minor;
        public int Build => m_Build;
        public int Revision => m_Revision;
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
            m_Major = major;
            m_Minor = minor;
            m_Build = build;
            m_Revision = revision;
        }

       
    }
}
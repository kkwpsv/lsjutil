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
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Version"/> struct.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        public Version(int major, int minor) : this(major, minor, 0)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Version"/> struct.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        /// <param name="build">Build.</param>
        public Version(int major, int minor, int build) : this(major, minor, build, 0)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Version"/> struct.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        /// <param name="build">Build.</param>
        /// <param name="revision">Revision.</param>
        public Version(int major, int minor, int build, int revision)
        {
            m_major = major;
            m_minor = minor;
            m_build = build;
            m_revision = revision;
        }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Lsj.Util.Version"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Lsj.Util.Version"/>.</returns>
        public override string ToString() => ToString(4);
        /// <summary>
        /// Tos the string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="length">Length.</param>
        public string ToString(int length)
        {
            if (length >= 4)
            {
                return $"{m_major}.{m_minor}.{m_build}.{m_revision}";
            }
            else if (length == 3)
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
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:Lsj.Util.Version"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:Lsj.Util.Version"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:Lsj.Util.Version"/>;
        /// otherwise, <c>false</c>.</returns>
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
        /// Determines whether a specified instance of <see cref="Lsj.Util.Version"/> is equal to another specified <see cref="Lsj.Util.Version"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Lsj.Util.Version"/> to compare.</param>
        /// <param name="b">The second <see cref="Lsj.Util.Version"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Version a, Version b) => (a.Major == b.Major) && (a.Minor == b.Minor) && (a.Build == b.Build) && (a.Revision == b.Revision);
        /// <summary>
        /// Determines whether a specified instance of <see cref="Lsj.Util.Version"/> is not equal to another specified <see cref="Lsj.Util.Version"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Lsj.Util.Version"/> to compare.</param>
        /// <param name="b">The second <see cref="Lsj.Util.Version"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Version a, Version b) => !(a == b);
        /// <summary>
        /// Serves as a hash function for a <see cref="T:Lsj.Util.Version"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode() => 0 | (this.Major & 15) << 28 | (this.Minor & 255) << 20 | (this.Build & 255) << 12 | (this.Revision & 4095);
    }
}
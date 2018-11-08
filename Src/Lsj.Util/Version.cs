namespace Lsj.Util
{
    /// <summary>
    /// Version
    /// </summary>
    public struct Version
    {

        /// <summary>
        /// Major
        /// </summary>
        public int Major { get; private set; }
        /// <summary>
        /// Minor
        /// </summary>
        public int Minor { get; private set; }
        /// <summary>
        /// Build
        /// </summary>
        public int Build { get; private set; }
        /// <summary>
        /// Revision
        /// </summary>
        public int Revision { get; private set; }
        /// <summary>
        /// Initialize a new instance of <see cref="Lsj.Util.Version"/> struct
        /// </summary>
        /// <param name="major">Major</param>
        public Version(int major) : this(major, 0)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="Lsj.Util.Version"/> struct
        /// </summary>
        /// <param name="major">Major</param>
        /// <param name="minor">Minor</param>
        public Version(int major, int minor) : this(major, minor, 0)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="Lsj.Util.Version"/> struct
        /// </summary>
        /// <param name="major">Major</param>
        /// <param name="minor">Minor</param>
        /// <param name="build">Build</param>
        public Version(int major, int minor, int build) : this(major, minor, build, 0)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="Lsj.Util.Version"/> struct
        /// </summary>
        /// <param name="major">Major</param>
        /// <param name="minor">Minor</param>
        /// <param name="build">Build</param>
        /// <param name="revision">Revision</param>
        public Version(int major, int minor, int build, int revision)
        {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }
        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString(4);
        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        /// <param name="length">Length</param>
        public string ToString(int length)
        {
            if (length >= 4)
            {
                return $"{Major}.{Minor}.{Build}.{Revision}";
            }
            else if (length == 3)
            {
                return $"{Major}.{Minor}.{Build}";
            }
            else if (length == 2)
            {
                return $"{Major}.{Minor}";
            }
            else
            {
                return $"{Major}";
            }
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Version o)
            {
                return (this.Major == o.Major) && (this.Minor == o.Minor) && (this.Build == o.Build) && (this.Revision == o.Revision);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Version a, Version b) => (a.Major == b.Major) && (a.Minor == b.Minor) && (a.Build == b.Build) && (a.Revision == b.Revision);
        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Version a, Version b) => !(a == b);
        /// <summary>
        /// Get HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => 0 | (this.Major & 15) << 28 | (this.Minor & 255) << 20 | (this.Build & 255) << 12 | (this.Revision & 4095);

        public static implicit operator System.Version(Version version) => new System.Version(version.Major, version.Minor, version.Build, version.Revision);

        public static implicit operator Version(System.Version version) => new Version(version.Major, version.Minor, version.Build, version.Revision);
    }
}
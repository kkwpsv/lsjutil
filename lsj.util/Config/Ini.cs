using System.Text;


namespace Lsj.Util.Config
{
    /// <summary>
    /// Ini Config Class
    /// </summary>
    public class Ini
    {
        string path;
        /// <summary>
        /// Initiate a New Instance With a Path
        /// <param name="path">Ini Path</param>  
        /// </summary>
        public Ini(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Write Ini File
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="Value">Value</param>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            Native.NativeMethod.WritePrivateProfileStringSafe(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Read Ini File
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder();
            Native.NativeMethod.GetPrivateProfileStringSafe(Section, Key, "Null", temp, uint.MaxValue, this.path);
            return temp.ToString();
        }






    }
}
using Lsj.Util.Text;

namespace Lsj.Util.Config
{
    /// <summary>
    /// Config Element
    /// </summary>
    public class ConfigElement
    {
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Config.ConfigElement"/> class
        /// </summary>
        public ConfigElement() => Static.DoNothing();

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Config.ConfigElement"/> class
        /// </summary>
        /// <param name="value">Value.</param>
        public ConfigElement(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Get the value
        /// </summary>
        public string Value => value.ToSafeString();

        /// <summary>
        /// Get value as string array
        /// </summary>
        public string[] StringArrayValue => Value.Split(',');

        /// <summary>
        /// Get value as bool
        /// </summary>
        public bool BoolValue => Value == "True";

        /// <summary>
        /// Get value as int
        /// </summary>
        public int IntValue => Value.ConvertToInt(0);

        /// <summary>
        /// NullConfigElemnet
        /// </summary>
        public static ConfigElement Null = new ConfigElement("");
    }
}

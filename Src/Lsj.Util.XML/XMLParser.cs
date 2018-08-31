using System.Text.RegularExpressions;

namespace Lsj.Util.XML
{
    public class XMLParser
    {
        public static XMLDocument ParseDocument(string str)
        {
            var attributeRegex = new Regex(@"^\s*<\?xml( +)(?<attribute>.*)\?>", RegexOptions.Singleline);
            var attributeMatch = attributeRegex.Match(str);
        }
        public static XMLNode Parse(string str)
        {

        }
    }
}

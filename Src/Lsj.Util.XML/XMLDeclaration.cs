using System.Text;

namespace Lsj.Util.XML
{
    public class XMLDeclaration
    {
        public Version Version { get; set; } = new Version(1, 0);
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public override string ToString() => $"<?xml version={this.Version.ToString(2)} encoding={this.Encoding.WebName}>";
    }
}

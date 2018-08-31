using System.Text;

namespace Lsj.Util.XML
{
    public class XMLDocument
    {
        public XMLDeclaration XMLDeclaration { get; set; }
        public XMLNode Root { get; set; }
        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.XMLDeclaration != null)
            {
                result.Append(this.XMLDeclaration.ToString());
            }
            if (this.Root != null)
            {
                result.Append(this.Root.ToString());
            }
            return result.ToString();
        }
    }
}

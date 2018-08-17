namespace Lsj.Util.XML
{
    public class XMLAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public override string ToString() => $"{Name}:{Value}";
    }
}

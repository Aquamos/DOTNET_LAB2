using System.Xml.Linq;

namespace Services
{
    public class EqualityComparerItem : IEqualityComparer<XElement>
    {
        public bool Equals(XElement x, XElement y)
        {
            return x.Element("Id").Value == y.Element("Id").Value;
        }

        public int GetHashCode(XElement obj)
        {
            return obj.Element("Id").Value.GetHashCode();
        }
    }
}

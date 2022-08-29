using Data;
using Models;
using System.Xml.Linq;

namespace Services.Read
{
    public class XMLReaderMethods
    {
        public XDocument GetXmlDoc(Paths path)
        {
            string file = string.Format("{0}.xml", path.Value);
            if (!File.Exists(file))
            {
                throw new FileNotFoundException($"Missing file: {file}");
            }
            XDocument xmlDoc = XDocument.Load(file);
            if (xmlDoc.Root == null)
            {
                throw new InvalidOperationException($"Missing data in: {file}");
            }
            return xmlDoc;
        }
    }
}

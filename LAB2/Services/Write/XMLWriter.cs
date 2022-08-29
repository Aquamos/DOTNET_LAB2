using Data;
using System.Xml.Linq;

namespace Services.Write
{
    public class XMLWriter
    {
        public static void AddElement<T>(Paths path, T item)
        {
            var type = item.GetType();
            var props = type.GetProperties();
            var elements = new List<XElement>();
            foreach (var prop in props)
            {
                if (prop.GetValue(item) is DateTime)
                {
                    elements.Add(new XElement(prop.Name,
                        string.Format("{0:d}", prop.GetValue(item))));
                }
                else
                {
                    elements.Add(new XElement(prop.Name,
                        prop.GetValue(item)));
                }
            }

            XDocument doc;
            XMLNames.Initialize();
            XElement element = new XElement(XMLNames.Parameters[type.Name].Value, elements);
            string file = string.Format("{0}.xml", path.Value);

            if (!File.Exists(file))
            {
                doc = new XDocument(new XElement(XMLNames.Parameters[type.Name].Value, element));
            }
            else 
            {
                doc = XDocument.Load(file);
                if (doc.Root == null)
                {
                    throw new InvalidOperationException($"Missing data in: {file}");
                }
                System.Console.WriteLine();
                doc.Root.Add(element);
            }
            doc.Save(file);
        }
    }
}

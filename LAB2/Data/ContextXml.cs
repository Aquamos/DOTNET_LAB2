using System.Xml.Linq;

namespace Data
{
    public sealed class ContextXml
    {
        private static ContextXml _context;
        private ContextXml() {
            DepartmentsXml = XDocument.Load(string.Format("{0}.xml", Paths.Departments.Value));
            GroupsXml = XDocument.Load(string.Format("{0}.xml", Paths.Groups.Value));
            PeopleXml = XDocument.Load(string.Format("{0}.xml", Paths.People.Value));
            RanksXml = XDocument.Load(string.Format("{0}.xml", Paths.Ranks.Value));
            ResourcesXml = XDocument.Load(string.Format("{0}.xml", Paths.Resources.Value));
            ResourceTypesXml = XDocument.Load(string.Format("{0}.xml", Paths.ResourceTypes.Value));
            StudentsAndResourcesXml = XDocument.Load(string.Format("{0}.xml", Paths.StudentsAndResources.Value));
            StudentsAndTeachersXml = XDocument.Load(string.Format("{0}.xml", Paths.StudentAndTeachers.Value));
        }
        public static ContextXml GetContext()
        {
            if (_context == null)
            {
                _context = new ContextXml();
            }
            return _context;
        }
        public XDocument DepartmentsXml { get; set; }
        public XDocument GroupsXml { get; set; }
        public XDocument PeopleXml { get; set; }
        public XDocument RanksXml { get; set; }
        public XDocument ResourcesXml { get; set; }
        public XDocument ResourceTypesXml { get; set; }
        public XDocument StudentsAndResourcesXml { get; set; }
        public XDocument StudentsAndTeachersXml { get; set; }
    }
}
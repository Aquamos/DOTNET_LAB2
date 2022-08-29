

namespace Data
{
    public class XMLNames : StringContainter
    {
        public static Dictionary<string, XMLNames> Parameters { get; private set; }
        private XMLNames(string value) : base(value) { }
        public static void Initialize()
        {
            Parameters = new Dictionary<string, XMLNames>()
            {
                {"Rank", new XMLNames("rank")},
                {"Department", new XMLNames("department") },
                {"Group", new XMLNames("group") },
                {"Resource",  new XMLNames("resource")},
                {"ResourceType",  new XMLNames("resourceType")},
                {"Student", new XMLNames("student")},
                {"Teacher", new XMLNames("teacher")},
                {"StudentsAndResources", new XMLNames("studentAndResource")},
                {"StudentsAndTeachers", new XMLNames("studentAndTeacher")}
            };
        }
        public XMLNames this[string index] => Parameters[index];
    }
}

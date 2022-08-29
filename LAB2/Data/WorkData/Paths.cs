

namespace Data
{
    public class Paths: StringContainter
    {
        public Paths(string value) : base(value){ }
        public static Paths Ranks { get { return new Paths("XML/Ranks"); } }
        public static Paths Departments { get { return new Paths("XML/Departments"); } }
        public static Paths Groups { get { return new Paths("XML/Groups"); } }
        public static Paths Resources { get { return new Paths("XML/Resources"); } }
        public static Paths ResourceTypes { get { return new Paths("XML/ResourceTypes"); } }
        public static Paths People { get { return new Paths("XML/People"); } }
        public static Paths StudentsAndResources { get { return new Paths("XML/StudentsAndResources"); } }
        public static Paths StudentAndTeachers { get { return new Paths("XML/StudentAndTeachers"); } }
    }
}

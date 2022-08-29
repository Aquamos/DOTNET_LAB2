using Data;
using System.Xml.Linq;

namespace Services
{
    public class Service
    {
        private ContextXml _context;
        public Service()
        {
            _context = ContextXml.GetContext();
        }

        public List<XElement> GetStudents() //1
        {
            var q = _context.PeopleXml.Element("people").Elements("student");
            return q.ToList();
        }

        public List<XElement> GetTeachers()
        {
            var q = _context.PeopleXml.Element("people").Elements("teacher");
            return q.ToList();
        }

        public List<XElement> GetStudentsFullInfo() //2
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var departments = _context.DepartmentsXml.Element("departments").Elements("department");
            var groups = _context.GroupsXml.Element("groups").Elements("group");

            var q = from student in students
                    join department in departments
                        on student.Element("DepartmentId").Value
                        equals department.Element("Id").Value
                    join _group in groups
                        on student.Element("GroupId").Value
                        equals _group.Element("Id").Value
                    select new XElement("StudentFullInfo",
                        new XElement("student", student),
                        new XElement("GroupFullName", _group.Element("FullName")),
                        new XElement("DepNameAbbreviation", department.Element("NameAbbreviation"))
                    );
            return q.ToList();
        }

        public List<XElement> GetTeacherFullInfo()
        {
            var teachers = _context.PeopleXml.Element("people").Elements("teacher");
            var departments = _context.DepartmentsXml.Element("departments").Elements("department");
            var ranks = _context.RanksXml.Element("ranks").Elements("rank");

            var q = from teacher in teachers
                    join department in departments
                        on teacher.Element("DepartmentId").Value
                        equals department.Element("Id").Value
                    join rank in ranks
                        on teacher.Element("RankId").Value 
                        equals rank.Element("Id").Value
                    select new XElement("StudentFullInfo",
                        new XElement("teacher", teacher),
                        new XElement("RankName", rank.Element("Name")),
                        new XElement("DepNameAbbreviation", department.Element("NameAbbreviation"))
                    );
            return q.ToList();
        }

        public Dictionary<string, List<XElement>> GetStudentsAndTeachersInfo() //3
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var teachers = _context.PeopleXml.Element("people").Elements("teacher");
            var studentsAndTeachers = _context.StudentsAndTeachersXml
                .Element("studentsAndTeachers")
                .Elements("studentAndTeacher");

            var satfi = from sat in studentsAndTeachers
                        join teacher in teachers
                            on sat.Element("TeacherId").Value
                            equals teacher.Element("Id").Value
                        join student in students
                            on sat.Element("StudentId").Value
                            equals student.Element("Id").Value
                        select new XElement("studentAndTeacher",
                            new XElement("student", student),
                            new XElement("teacher", teacher)
                        );

            var q = satfi.GroupBy(x => x.Element("student")
                .Element("student").Element("FullName").Value);
            return q.ToDictionary(x => x.Key, x => x.ToList());
        }

        public Dictionary<string, List<XElement>> GetTeachersAndStudentsInfo()
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var teachers = _context.PeopleXml.Element("people").Elements("teacher");
            var studentsAndTeachers = _context.StudentsAndTeachersXml.Element("studentsAndTeachers")
                .Elements("studentAndTeacher");

            var satfi = from sat in studentsAndTeachers
                        join teacher in teachers
                            on sat.Element("TeacherId").Value
                            equals teacher.Element("Id").Value
                        join student in students
                            on sat.Element("StudentId").Value
                            equals student.Element("Id").Value
                        select new XElement("studentAndTeacher",
                            new XElement("student", student),
                            new XElement("teacher", teacher)
                        );

            var q = satfi.GroupBy(x => x.Element("teacher")
            .Element("teacher").Element("FullName").Value);
            return q.ToDictionary(x => x.Key, x => x.ToList());
        }

        public List<XElement> GetResourcesFullInfo() //4
        {
            var resources = _context.ResourcesXml.Element("resources").Elements("resource");
            var resourceTypes = _context.ResourceTypesXml
                .Element("resourceTypes")
                .Elements("resourceType");

            var q = resources.Join(resourceTypes,
                     r => r.Element("ResourceTypeId").Value,
                     rt => rt.Element("Id").Value,
                     (r, rt) => new XElement("ResourceFullInfo",
                        new XElement("ResourceName", r.Element("Name")),
                        new XElement("ResourceTypeName", rt.Element("Name")))
                     );
            return q.ToList();  
        }

        public Dictionary<string, List<XElement>> GetStudentsAndResourcesInfo() //5
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var resources = _context.ResourcesXml.Element("resources").Elements("resource");
            var studentsAndResources = _context.StudentsAndResourcesXml
                .Element("studentsAndResources")
                .Elements("studentAndResource");

            var sarfi = from sar in studentsAndResources
                        join student in students
                            on sar.Element("StudentId").Value
                            equals student.Element("Id").Value
                        join resource in resources
                            on sar.Element("ResourceId").Value
                            equals resource.Element("Id").Value into lj
                        from subres in lj.DefaultIfEmpty()
                        select new XElement("studentAndResource",
                            new XElement("student", student),
                            new XElement("ResourceName", subres?.Element("Name").Value ?? String.Empty)
                        );

            var q = sarfi.GroupBy(x => x.Element("student")
            .Element("student").Element("FullName").Value);
            return q.ToDictionary(x => x.Key, x => x.ToList());
        }

        public List<XElement> GetStudentsSortedByNameThenByBirthDate() //6
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var q = students
                .OrderBy(x => x.Element("FullName").Value)
                .ThenBy(x => x.Element("BirthDate").Value);
            return q.ToList();
        }

        public List<XElement> GetStudentsSortedByDefenceDateThenByName()
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var q = students
                .OrderBy(x => x.Element("DateOfDefense").Value)
                .ThenBy(x => x.Element("FullName").Value);
            return q.ToList();
        }

        public List<XElement> GetStudentsFromDateOfDefense(DateTime dt) //7
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var q = from student in students
                    where dt <= DateTime.Parse(student.Element("DateOfDefense").Value)
                    orderby student.Element("DateOfDefense").Value
                    select student;

            return q.ToList();
        }

        public List<XElement> GetStudentsTopicsByFaculty(string name)
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var departments = _context.DepartmentsXml.Element("departments").Elements("department");

            var q = from student in students
                    join department in departments
                        on student.Element("DepartmentId").Value
                        equals department.Element("Id").Value
                    where name == department.Element("Name").Value || 
                          name == department.Element("NameAbbreviation").Value
                    select new XElement("Topic", student.Element("Topic"));

            return q.ToList();
        }

        public Dictionary<string, List<XElement>> GetGroupOfStudentsByDateOfDefense() //8
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var q = students.OrderBy(s => s.Element("DateOfDefense").Value)
                            .GroupBy(s => s.Element("DateOfDefense").Value);
            return q.ToDictionary(x => x.Key, x => x.ToList());
        }

        public List<XElement> GetTeacherWithCountStudents() //9
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var teachers = _context.PeopleXml.Element("people").Elements("teacher");
            var studentsAndTeachers = _context.StudentsAndTeachersXml.Element("studentsAndTeachers")
                .Elements("studentAndTeacher");

            var satfi = from sat in studentsAndTeachers
                        join teacher in teachers
                            on sat.Element("TeacherId").Value
                            equals teacher.Element("Id").Value
                        join student in students
                            on sat.Element("StudentId").Value
                            equals student.Element("Id").Value
                        select new XElement("teacher",
                            teacher.Element("FullName"));

            var q = from x in satfi
                    group x by x.Element("FullName").Value into g
                    select new XElement("teacherAndStudentsCount",
                        new XElement("Name", g.Key),
                        new XElement("Count", g.Count()));
            return q.ToList();  
        }

        public bool GetFaculty(string name) //10
        {
            var departments = _context.DepartmentsXml.Element("departments").Elements("department");
            return departments.Any(n => n.Element("Name").Value == name ||
                    n.Element("NameAbbreviation").Value == name);
        }

        public List<XElement> GetAverageGPAByDepartments() //11
        {
            var students = _context.PeopleXml.Element("people").Elements("student");
            var departments = _context.DepartmentsXml.Element("departments").Elements("department");

            var g = from student in students
                    join department in departments
                        on student.Element("DepartmentId").Value
                        equals department.Element("Id").Value
                    group student by department.Element("NameAbbreviation").Value;

            var q = from item in g
                     select new XElement("GPAsByDep",
                         new XElement("Department", item.Key),
                         new XElement("AverageNumber",
                            decimal.Round(item.Elements("GPA")
                                    .Average(x => (decimal)x), 2))
                         );
            return q.ToList();

        }

        public List<XElement> GetDistinctStudentsResources() //12
        {
            var studentsAndResources = _context.StudentsAndResourcesXml
                .Element("studentsAndResources").Elements("studentAndResource");
            var resources = _context.ResourcesXml.Element("resources").Elements("resource");

            var q = studentsAndResources.Join(resources,
                          shr => shr.Element("ResourceId").Value,
                          res => res.Element("Id").Value,
                          (shr, res) => new XElement(
                              "Name", res.Element("Name"))
                          ).Distinct();
            return q.ToList();
        }

        public List<XElement> GetStudentsWithTopGPAAndMoreThanInputResources(int resNum) //13
        {
            var studentsAndResources = _context.StudentsAndResourcesXml
                .Element("studentsAndResources").Elements("studentAndResource");
            var resources = _context.ResourcesXml.Element("resources").Elements("resource");
            var students = _context.PeopleXml.Element("people").Elements("student");

            var studentsResNumbers = from shr in studentsAndResources
                                     join student in students
                                        on shr.Element("StudentId").Value
                                        equals student.Element("Id").Value
                                     join resource in resources
                                        on shr.Element("ResourceId").Value
                                        equals resource.Element("Id").Value
                                     group shr by shr.Element("StudentId").Value into g
                                     select new XElement("studentsResNumbers",
                                     new XElement("StudentId", g.Key),
                                     new XElement("Number", g.Count()));

            var topResNumbers = from srn in studentsResNumbers
                                where (int)srn.Element("Number") > resNum
                                join student in students 
                                    on srn.Element("StudentId").Value
                                    equals student.Element("Id").Value
                                select student;

            var topGPAStudents = from student in students
                                 where (decimal)student.Element("GPA") > 90
                                 select student;

            var q = (topResNumbers.Intersect(topGPAStudents, new EqualityComparerItem())).ToList();
            return q;
        }

        public List<XElement> GetTopGPAStudents() //14
        {
            var students = _context.PeopleXml.Element("people").Elements("student");

            var q = students
                .OrderByDescending(p => p.Element("GPA").Value)
                .TakeWhile(p => decimal.Parse(p.Element("GPA").Value) > 95);

            return q.ToList();
        }

        public XElement MaxRankLength()
        {
            var ranks = _context.RanksXml.Element("ranks").Elements("rank");

            var q = new XElement("RankMaxLength",
                ranks.Max(x => x.Element("Name").Value.Length));

            return q;
        }

        public static int GetMaxId(IEnumerable<XElement> elements)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements), "No data in models to search maxId");
            else
                return elements.Max(x => int.Parse(x.Element("Id").Value));
        }

        public static bool CheckIfExists(IEnumerable<XElement> elements , int id)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements), "No data in models to check id");
            else
                return elements.Any(x => int.Parse(x.Element("Id").Value) == id);
        }
    }
}

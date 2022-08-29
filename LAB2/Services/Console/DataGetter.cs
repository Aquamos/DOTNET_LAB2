using Models;
using Data;
using HelperMethods;
using System.Xml.Linq;

namespace Services.Console
{
    public class DataGetter
    {
        private ContextXml _context;
        private Func<IEnumerable<XElement>, int, bool> idChecker = Service.CheckIfExists;
        private Action<string, IEnumerable<XElement>> printCollection = Helper.PrintCollectionToConsole;
        public DataGetter()
        {
            _context = ContextXml.GetContext();
        }
        public Rank GetRankFromConsole() 
        { 
            Rank rank = new Rank();

            var ranks = _context.RanksXml.Element("ranks").Elements("rank");
            rank.Id = Service.GetMaxId(ranks) + 1;

            rank.Name = Helper.GetStringFromConsole(
                "Please enter rank's name: ");

            return rank;
        }
        public Group GetGroupFromConsole()
        {
            Group group = new Group();

            group.Id = Service.GetMaxId(_context.GroupsXml.Element("groups").Elements("group")) + 1;

            group.Name = Helper.GetStringFromConsole(
                "Please enter group's name (two symbols): ", 2);

            group.Number = Helper.GetIntFromConsole(
                "Please enter group's number (two digits): ", 2);

            return group;
        }
        public Department GetDepartmentFromConsole()
        {
            Department department = new Department();

            department.Id = Service.GetMaxId(
                _context.DepartmentsXml.Element("department").Elements("departments")) + 1;

            department.NameAbbreviation = Helper.GetStringFromConsole(
                "Please enter departments's name abbreviation: ");

            department.Name = 
                Helper.GetUncheckedStringFromConsole(
                    "Please enter departments's name (or skip if u want): ");

            return department;
        }
        public Resource GetResourseFromConsole()
        {
            Resource resource = new Resource();

            resource.Id = Service.GetMaxId(
                _context.ResourcesXml.Element("resource").Elements("resources")) + 1;

            resource.Name = Helper.GetStringFromConsole(
                "Please enter resource's name: ");

            resource.ResourceTypeId = Helper.GetIntFromConsole(
                "Please enter resourceTypeId from list: ", 
                preAction: printCollection,
                preActionMessage: "Resource types",
                idChecker: idChecker,
                models: _context.ResourceTypesXml.Element("resourceTypes").Elements("resourceType")); 

            return resource;
        }
        public ResourceType GetResourseTypeFromConsole()
        {
            ResourceType resourceType = new ResourceType();

            resourceType.Id = Service.GetMaxId(
                _context.ResourceTypesXml.Element("resourceType").Elements("resourceTypes")) + 1;

            resourceType.Name = Helper.GetStringFromConsole(
                "Please enter resourceType's name: ");

            return resourceType;
        }
        public Student GetStudentFromConsole()
        {
            Student student = new Student();

            student.Id = Service.GetMaxId(
                _context.PeopleXml.Element("people").Elements()) + 1;

            student.FirstName = Helper.GetStringFromConsole(
                "Please enter student's first name: ");

            student.LastName = Helper.GetStringFromConsole(
                "Please enter student's last name: ");

            student.FullName = $"{student.FirstName} {student.LastName}";

            student.BirthDate = Helper.GetDateFromConsole(
                "Please enter student's birth date: ");

            student.DepartmentId = Helper.GetIntFromConsole(
                "Please enter student's departmentId: ",
                preAction: printCollection,
                preActionMessage: "Departments",
                idChecker: idChecker,
                models: _context.DepartmentsXml.Element("departments").Elements("department"));

            student.GPA = Helper.GetDecimalFromConsole(
                "Please enter student's GPA: ", 5);

            student.Topic = Helper.GetStringFromConsole(
                "Please enter student's topic");

            student.DateOfDefence = Helper.GetDateFromConsole(
                "Please enter student's defense date: ");

            return student;
        }
        public Teacher GetTeacherFromConsole()
        {
            Teacher teacher = new Teacher();

            teacher.Id = Service.GetMaxId(
                _context.PeopleXml.Element("people").Elements()) + 1;

            teacher.FirstName = Helper.GetStringFromConsole(
                "Please enter teacher's first name: ");

            teacher.LastName = Helper.GetStringFromConsole(
                "Please enter teacher's last name: ");

            teacher.BirthDate = Helper.GetDateFromConsole(
                "Please enter teacher's birth date: ");

            var departments = _context.DepartmentsXml.Element("departments").Elements("department");
            teacher.DepartmentId = Helper.GetIntFromConsole(
                "Please enter teacher's department's id: ",
                preAction: printCollection,
                preActionMessage: "Departments",
                idChecker: idChecker,
                models: departments);

            teacher.FullName = $"{teacher.FirstName} {teacher.LastName}";

            teacher.RankId = Helper.GetIntFromConsole(
                "Please enter teacher's rank's id: ",
                preAction: printCollection,
                preActionMessage: "Ranks",
                idChecker: idChecker,
                models: _context.RanksXml.Element("ranks").Elements("rank"));

            return teacher;
        }
        public StudentsAndResources GetSaRFromConsole()
        {
            StudentsAndResources sar = new StudentsAndResources();

            sar.Id = Service.GetMaxId(
                _context.StudentsAndResourcesXml.Element("studentsAndResources")
                .Elements("studentAndResource")) + 1;

            var students = _context.PeopleXml.Element("people").Elements("student");

            sar.StudentId = Helper.GetIntFromConsole(
                "Please enter students's id: ",
                preAction: printCollection,
                preActionMessage: "Students",
                idChecker: idChecker,
                models: students);

            sar.ResourceId = Helper.GetIntFromConsole(
                "Please enter resource's id: ",
                preAction: printCollection,
                preActionMessage: "Resources",
                idChecker: idChecker,
                models: _context.ResourcesXml.Element("resources").Elements("resource"));

            return sar;
        }
        public StudentsAndTeachers GetSaTFromConsole()
        {
            StudentsAndTeachers sat = new StudentsAndTeachers();

            sat.Id = Service.GetMaxId(
                _context.StudentsAndTeachersXml.Element("studentsAndTeachers")
                .Elements("studentAndTeacher")) + 1;

            var students = _context.PeopleXml.Element("people").Elements("student");

            sat.StudentId = Helper.GetIntFromConsole(
                "Please enter students's id: ",
                preAction: printCollection,
                preActionMessage: "Students",
                idChecker: idChecker,
                models: students);

            var teachers = _context.PeopleXml.Element("people").Elements("teacher");

            sat.TeacherId = Helper.GetIntFromConsole(
                "Please enter teacher's id: ",
                preAction: printCollection,
                preActionMessage: "Teachers",
                idChecker: idChecker,
                models: teachers);

            return sat;
        }
    }
}

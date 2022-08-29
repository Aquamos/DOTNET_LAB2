using Services.Console;
using Services.Read;
using Data;

namespace Services.Write
{
    public class WriteToXml
    {
        private DataGetter _dataGetter;
        private XMLReader _xmlReader;
        public WriteToXml()
        {
            _dataGetter = new DataGetter();
            _xmlReader = new XMLReader();
        }
        public void AddNewRank()
        {
            XMLWriter.AddElement(
            Paths.Ranks, _dataGetter.GetRankFromConsole());
            _xmlReader.ReadRanks();
        }

        public void AddNewDepartment()
        {
            XMLWriter.AddElement(
              Paths.Departments, _dataGetter.GetDepartmentFromConsole());
            _xmlReader.ReadDepartments();
        }
        public void AddNewGroup()
        {
            XMLWriter.AddElement(
              Paths.Groups, _dataGetter.GetGroupFromConsole());
            _xmlReader.ReadGroups();
        }
        public void AddNewResource()
        {
            XMLWriter.AddElement(
            Paths.Resources, _dataGetter.GetResourseFromConsole());
            _xmlReader.ReadResources();
        }
        public void AddNewResourceType()
        {
            XMLWriter.AddElement(
              Paths.ResourceTypes, _dataGetter.GetResourseTypeFromConsole());
            _xmlReader.ReadResourceTypes();
        }
        public void AddNewStudent()
        {
            XMLWriter.AddElement(
            Paths.People, _dataGetter.GetStudentFromConsole());
            _xmlReader.ReadPeople();
        }
        public void AddNewTeacher()
        {
            XMLWriter.AddElement(
              Paths.People, _dataGetter.GetTeacherFromConsole());
            _xmlReader.ReadPeople();
        }
        public void AddNewSaR()
        {
            XMLWriter.AddElement(
            Paths.StudentsAndResources, _dataGetter.GetSaRFromConsole());
            _xmlReader.ReadStudentsAndResources();
        }
        public void AddNewSaT()
        {
            XMLWriter.AddElement(
              Paths.StudentAndTeachers, _dataGetter.GetSaTFromConsole());
            _xmlReader.ReadStudentsAndTeachers();
        }
    }
}

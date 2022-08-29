using static System.Console;
using Data;
using Models;

namespace Services.Read
{
    public class XMLReader
    {
        private ContextXml _xmlContext;
        private XMLReaderMethods _readerMethods;
        public XMLReader()
        {
            _xmlContext = ContextXml.GetContext();
            _readerMethods = new XMLReaderMethods();
        }

        public void ReadAll()
        {
            try 
            {
                _xmlContext.GroupsXml = 
                    _readerMethods.GetXmlDoc(Paths.Groups);
                _xmlContext.DepartmentsXml =  
                    _readerMethods.GetXmlDoc(Paths.Departments);
                _xmlContext.RanksXml = 
                    _readerMethods.GetXmlDoc(Paths.Ranks);
                _xmlContext.ResourcesXml = 
                    _readerMethods.GetXmlDoc(Paths.Resources);
                _xmlContext.ResourceTypesXml = 
                    _readerMethods.GetXmlDoc(Paths.ResourceTypes);
                _xmlContext.PeopleXml = 
                    _readerMethods.GetXmlDoc(Paths.People);
                _xmlContext.StudentsAndResourcesXml = 
                    _readerMethods.GetXmlDoc(Paths.StudentsAndResources);
                _xmlContext.StudentsAndTeachersXml = 
                    _readerMethods.GetXmlDoc(Paths.StudentAndTeachers);
            }
            catch (FileNotFoundException ex)
            {
                WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void ReadGroups()
        {
            try
            {
                _xmlContext.GroupsXml =
                    _readerMethods.GetXmlDoc(Paths.Groups);
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void ReadDepartments()
        {
            try
            {
                _xmlContext.DepartmentsXml =
                   _readerMethods.GetXmlDoc(Paths.Departments);
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void ReadRanks()
        {
            try
            {
                _xmlContext.RanksXml = 
                    _readerMethods.GetXmlDoc(Paths.Ranks);
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void ReadResources()
        {
            try
            {
                _xmlContext.ResourcesXml =
                    _readerMethods.GetXmlDoc(Paths.Resources);
            }
            catch (FileNotFoundException ex)
            {
                WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void ReadResourceTypes()
        {
            try
            {
                _xmlContext.ResourceTypesXml =
                    _readerMethods.GetXmlDoc(Paths.ResourceTypes);
            }
            catch (FileNotFoundException ex)
            {
                WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void ReadPeople()
        {
            try
            {
                _xmlContext.PeopleXml =
                    _readerMethods.GetXmlDoc(Paths.People);
            }
            catch (FileNotFoundException ex)
            {
                WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void ReadStudentsAndResources()
        {
            try
            {
                _xmlContext.StudentsAndResourcesXml =
                    _readerMethods.GetXmlDoc(Paths.StudentsAndResources);
            }
            catch (FileNotFoundException ex)
            {
                WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public void ReadStudentsAndTeachers()
        {
            try
            {
                _xmlContext.StudentsAndTeachersXml =
                    _readerMethods.GetXmlDoc(Paths.StudentAndTeachers);
            }
            catch (FileNotFoundException ex)
            {
                WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}

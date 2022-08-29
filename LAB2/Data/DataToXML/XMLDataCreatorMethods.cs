using Data;
using Models;
using HelperMethods;
using System.Xml;

namespace LAB2
{
    public class XMLDataCreatorMethods
    {
        public void SeedRanks(List<Rank> ranks, Paths path)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };
            CheckOrCreateDirectory.CheckOrCreate(path.Value);
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", path.Value), settings))
            {
                writer.WriteStartElement("ranks");
                foreach (Rank rank in ranks)
                {
                    writer.WriteStartElement("rank");
                    writer.WriteElementString("Id", rank.Id.ToString());
                    writer.WriteElementString("Name", rank.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void SeedDepartments(List<Department> departments, Paths path)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };
            CheckOrCreateDirectory.CheckOrCreate(path.Value);
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", path.Value), settings))
            {
                writer.WriteStartElement("departments");
                foreach (Department department in departments)
                {
                    writer.WriteStartElement("department");
                    writer.WriteElementString("Id", department.Id.ToString());
                    writer.WriteElementString("Name", department.Name);
                    writer.WriteElementString("NameAbbreviation", department.NameAbbreviation);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void SeedGroups(List<Group> groups, Paths path)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };
            CheckOrCreateDirectory.CheckOrCreate(path.Value);
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", path.Value), settings))
            {
                writer.WriteStartElement("groups");
                foreach (Group group in groups)
                {
                    writer.WriteStartElement("group");
                    writer.WriteElementString("Id", group.Id.ToString());
                    writer.WriteElementString("Name", group.Name);
                    writer.WriteElementString("Number", group.Number.ToString());
                    writer.WriteElementString("FullName", $"{group.Name}-{group.Number}");
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void SeedResources(List<Resource> resources, Paths path)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };
            CheckOrCreateDirectory.CheckOrCreate(path.Value);
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", path.Value), settings))
            {
                writer.WriteStartElement("resources");
                foreach (Resource resource in resources)
                {
                    writer.WriteStartElement("resource");
                    writer.WriteElementString("Id", resource.Id.ToString());
                    writer.WriteElementString("Name", resource.Name);
                    writer.WriteElementString("ResourceTypeId", resource.ResourceTypeId.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void SeedResourceTypes(List<ResourceType> resourceTypes, Paths path)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };
            CheckOrCreateDirectory.CheckOrCreate(path.Value);
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", path.Value), settings))
            {
                writer.WriteStartElement("resourceTypes");
                foreach (ResourceType resourceType in resourceTypes)
                {
                    writer.WriteStartElement("resourceType");
                    writer.WriteElementString("Id", resourceType.Id.ToString());
                    writer.WriteElementString("Name", resourceType.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void SeedPeople(List<Person> people, Paths path)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };
            CheckOrCreateDirectory.CheckOrCreate(path.Value);
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", path.Value), settings))
            {
                writer.WriteStartElement("people");
                foreach (Person person in people)
                {
                    if (person is Student)
                    {
                        Student student = (Student)person;
                        writer.WriteStartElement("student");
                        writer.WriteElementString("Id", student.Id.ToString());
                        writer.WriteElementString("FirstName", student.FirstName);
                        writer.WriteElementString("LastName", student.LastName);
                        writer.WriteElementString("FullName", $"{student.FirstName} {student.LastName}");
                        writer.WriteElementString("BirthDate", student.BirthDate.ToShortDateString());
                        writer.WriteElementString("DepartmentId", student.DepartmentId.ToString());
                        writer.WriteElementString("GroupId", student.GroupId.ToString());
                        writer.WriteElementString("GPA", student.GPA.ToString());
                        writer.WriteElementString("Topic", student.Topic);
                        writer.WriteElementString("DateOfDefense", student.DateOfDefence.ToShortDateString());
                    }
                    else if (person is Teacher)
                    {
                        Teacher teacher = (Teacher)person;
                        writer.WriteStartElement("teacher");
                        writer.WriteElementString("Id", teacher.Id.ToString());
                        writer.WriteElementString("FirstName", teacher.FirstName);
                        writer.WriteElementString("LastName", teacher.LastName);
                        writer.WriteElementString("FullName", $"{teacher.FirstName} {teacher.LastName}");
                        writer.WriteElementString("BirthDate", teacher.BirthDate.ToShortDateString());
                        writer.WriteElementString("DepartmentId", teacher.DepartmentId.ToString());
                        writer.WriteElementString("RankId", teacher.RankId.ToString());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void SeedStudentsAndResources(List<StudentsAndResources> studentsAndResources, Paths path)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };
            CheckOrCreateDirectory.CheckOrCreate(path.Value);
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", path.Value), settings))
            {
                writer.WriteStartElement("studentsAndResources");
                foreach (StudentsAndResources sar in studentsAndResources)
                {
                    writer.WriteStartElement("studentAndResource");
                    writer.WriteElementString("Id", sar.Id.ToString());
                    writer.WriteElementString("StudentId", sar.StudentId.ToString());
                    writer.WriteElementString("ResourceId", sar.ResourceId.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        public void SeedStudentsAndTeachers(List<StudentsAndTeachers> studentsAndTeachers, Paths path)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
            };
            CheckOrCreateDirectory.CheckOrCreate(path.Value);
            using (XmlWriter writer = XmlWriter.Create(string.Format("{0}.xml", path.Value), settings))
            {
                writer.WriteStartElement("studentsAndTeachers");
                foreach (StudentsAndTeachers sat in studentsAndTeachers)
                {
                    writer.WriteStartElement("studentAndTeacher");
                    writer.WriteElementString("Id", sat.Id.ToString());
                    writer.WriteElementString("StudentId", sat.StudentId.ToString());
                    writer.WriteElementString("TeacherId", sat.TeacherId.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

    }
}

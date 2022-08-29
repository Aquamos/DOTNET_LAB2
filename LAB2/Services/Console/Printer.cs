using static System.Console;
using ConsoleTables;
using HelperMethods;
using System.Xml.Linq;

namespace Services
{
    public class Printer
    {
        private Service _service;
        public Printer()
        {
            _service = new Service();
        }
        public void PrintTeachersAndStudentsInfo()
        {
            var groupCollection = _service.GetTeachersAndStudentsInfo();
            var table = new ConsoleTable("TeacherFullName", "StudentFullName");
            foreach (var group in groupCollection)
            {
                string students = string.Empty;
                foreach (var value in group.Value)
                {
                    if (value != group.Value.Last())
                        students += $"{value.Element("student").Element("student").Element("FullName").Value}, ";
                    else
                        students += $"{value.Element("student").Element("student").Element("FullName").Value}";
                }
                table.AddRow(group.Key, students);
            }
            table.Write();
            WriteLine();
        }

        public void PrintStudentsAndTeachersInfo()
        {
            var groupCollection = _service.GetStudentsAndTeachersInfo();
            var table = new ConsoleTable("StudentFullName", "TeacherFullName");
            foreach (var group in groupCollection)
            {
                string teachers = string.Empty;
                foreach (var value in group.Value)
                {
                    if (value != group.Value.Last())
                        teachers += $"{value.Element("teacher").Element("teacher").Element("FullName").Value}, ";
                    else
                        teachers += $"{value.Element("teacher").Element("teacher").Element("FullName").Value}";
                }
                table.AddRow(group.Key, teachers);
            }
            table.Write();
            WriteLine();
        }

        public void PrintStudentsAndResourcesInfo()
        {
            var groupCollection = _service.GetStudentsAndResourcesInfo();
            var table = new ConsoleTable("StudentFullName", "ResourceName");
            foreach (var group in groupCollection)
            {
                table.AddRow(group.Key, "");
                foreach (var value in group.Value)
                {
                    table.AddRow(" ", $"{value.Element("ResourceName").Value}");
                }
            }   
            table.Write();
            WriteLine();
        }

        public void PrintStudentsFullInfo()
        {
            var collection = _service.GetStudentsFullInfo();
            var table = new ConsoleTable("Department name abbr.",
                                         "Group",
                                         "Full name",
                                         "Birth date",
                                         "GPA");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("DepNameAbbreviation").Value,
                             item.Element("GroupFullName").Value,
                             item.Element("student").Element("student")
                                .Element("FullName").Value,
                             item.Element("student").Element("student")
                                .Element("BirthDate").Value,
                             item.Element("student").Element("student")
                                .Element("GPA").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintStudentsDiplomaDefense()
        {
            var collection = _service.GetStudents();
            var table = new ConsoleTable("Full name",
                                         "Topic",
                                         "Defence date");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("FullName").Value,
                             item.Element("Topic").Value,
                             item.Element("DateOfDefence").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintTeachersFullInfo()
        {
            var collection = _service.GetTeacherFullInfo();
            var table = new ConsoleTable("Department name abbr.",
                                         "Full name",
                                         "Birth date",
                                         "Rank");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("DepNameAbbreviation").Value,
                             item.Element("teacher").Element("teacher")
                                .Element("FullName").Value,
                             item.Element("teacher").Element("teacher")
                                .Element("BirthDate").Value,
                             item.Element("RankName").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintResourcesFullInfo()
        {
            var collection = _service.GetResourcesFullInfo();
            var table = new ConsoleTable("Type",
                                         "Resource");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("ResourceTypeName").Value,
                             item.Element("ResourceName").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintStudentsSortedByNameThenByBirthDate()
        {
            var collection = _service.GetStudentsSortedByNameThenByBirthDate();
            var table = new ConsoleTable("Full name",
                                         "Birth date");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("FullName").Value,
                             item.Element("BirthDate").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintStudentsSortedByDefenceDateThenByName()
        {
            var collection = _service.GetStudentsSortedByDefenceDateThenByName();
            var table = new ConsoleTable("Date of Defense",
                                         "Full name");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("DateOfDefense").Value,
                             item.Element("FullName").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintStudentsFromDateOfDefense()
        {
            var collection = _service.GetStudentsFromDateOfDefense(Helper.GetDateFromConsole());
            var table = new ConsoleTable("Date of Defense",
                                         "Full name");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("DateOfDefense").Value,
                             item.Element("FullName").Value);
            }
            table.Write();
            WriteLine();

        }

        public void PrintGroupOfStudentsByDateOfDefense()
        {
            var groupCollection = _service.GetGroupOfStudentsByDateOfDefense();
            var table = new ConsoleTable("DateOfDefense", "StudentFullName");
            foreach (var group in groupCollection)
            {
                string students = string.Empty;
                foreach (var value in group.Value)
                {
                    if (value != group.Value.Last())
                        students += $"{value.Element("FullName").Value}, ";
                    else
                        students += $"{value.Element("FullName").Value}";
                }
                table.AddRow(group.Key, students);
            }
            table.Write();
            WriteLine();
        }

        public void PrintTeachersWithCountStudents()
        {
            var collection = _service.GetTeacherWithCountStudents();
            var table = new ConsoleTable("Teacher",
                                         "Count of students");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("Name").Value,
                             item.Element("Count").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintStudentsTopicsByFaculty()
        {
            string input;
            do
            {
                input = Helper.GetStringFromConsole("Please enter the name or name abbreviation of the department");
            } while (!_service.GetFaculty(input));

            var collection = _service.GetStudentsTopicsByFaculty(input);
            var table = new ConsoleTable("Topics");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("Topic").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintAverageGPAByDepartments()
        {
            var collection = _service.GetAverageGPAByDepartments();
            var table = new ConsoleTable("Department",
                                         "GPA");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("Department").Value,
                             item.Element("AverageNumber").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintDistinctStudentsResources()
        {
            var collection = _service.GetDistinctStudentsResources();
            var table = new ConsoleTable("Resource");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("Name").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintTopGPAStudents()
        {
            var collection = _service.GetTopGPAStudents();
            var table = new ConsoleTable("Full name",
                                         "GPA");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("FullName").Value,
                             item.Element("GPA").Value);
            }
            table.Write();
            WriteLine();
        }

        public void PrintMaxRankLength()
        {
            XElement item = _service.MaxRankLength();
            WriteLine($"Ranks' max length: {item.Value}");
            
        }

        public void PrintStudentsWithTopGPAAndMoreThanInputResources()
        {
            int num = Helper.GetIntFromConsole("Please enter number of resources: ");
            var collection = _service.GetStudentsWithTopGPAAndMoreThanInputResources(num);
            var table = new ConsoleTable("Full name",
                                         "GPA");
            foreach (var item in collection)
            {
                table.AddRow(item.Element("FullName").Value,
                             item.Element("GPA").Value);
            }
            table.Write();
            WriteLine();
        }
    }
}

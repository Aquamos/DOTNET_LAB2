using Commands.EnumCommands;

namespace Menu.Commands
{
    public class MenuSeeder
    {
        public Dictionary<MenuCommands, Menu> Menus { get; private set; }
        public MenuSeeder()
        {
            Menus = new Dictionary<MenuCommands, Menu>()
            {
                {MenuCommands.MainMenu,
                    new Menu()
                    {
                        _header = "Welcome to the LAB2. What would you like to do?",
                        Options = new string[]
                        {
                            "XML",
                            "Full info",
                            "Sorted",
                            "Search",
                            "Group",
                            "Aggregate and collection methods"
                        },
                    }
                },
                {MenuCommands.XMLMenu,
                    new Menu()
                    {
                        _header = "Welcome to the LAB2. What would you like to do?",
                        Options = new string[] {
                            "Add new rank",
                            "Add new department",
                            "Add new group",
                            "Add new resource",
                            "Add new resource's type",
                            "Add new student",
                            "Add new teacher",
                            "Add new record about student and his/her resource",
                            "Add new record about student and his/her teacher"
                        },
                    }
                },
                {MenuCommands.FullInfoMenu,
                    new Menu()
                    {
                        _header = "Welcome to the LAB2. What would you like to do?",
                        Options = new string[] {
                            "(Info) Students",
                            "(Info) Teachers",
                            "(Info) Resources",
                            "(Multiple Join) Teachers and their students",
                            "(Multiple Join) Students and their teachers",
                            "(Multiple Join. Left Join) Students and their resources",
                            "(Info) Students topics and graduation days",
                            "(Count) Teachers and count of their diploma-students",
                            "(TakeWhile) Get students with GPA > 95",
                            "(Max) Max ranks' length"
                        },
                    }
                },
                {MenuCommands.SortedMenu,
                    new Menu()
                    {
                        _header = "Welcome to the LAB2. What would you like to do?",
                        Options = new string[] {
                            "(OrderBy/ThenBy) StudentsByNameThenByBirthDate",
                            "(OrderBy/ThenBy) StudentsByDefenceDateThenByName"
                        },
                    }
                },
                {MenuCommands.SearchMenu,
                    new Menu()
                    {
                        _header = "Welcome to the LAB2. What would you like to do?",
                        Options = new string[] {
                            "(Where) Search students with date of defence after input date",
                            "(Where) Get students' topics by their department",
                        },
                    }
                },
                {MenuCommands.GroupMenu,
                    new Menu()
                    {
                        _header = "Welcome to the LAB2. What would you like to do?",
                        Options = new string[] {
                            "(GroupBy) Get groups of students by date of defense"
                        },
                    }
                },
                {MenuCommands.AggregateAndCollectionsMenu,
                    new Menu()
                    {
                        _header = "Welcome to the LAB2. What would you like to do?",
                        Options = new string[] {
                            "(Average, Max) Get department with top students' average GPA",
                            "(Distinct) Get distinct students' resources",
                            "(Intersect) Get students with gpa > 95 and resources > input"
                        },
                    }
                }
            };
        }
        public Menu this[MenuCommands index] { get { return Menus[index]; } }
    }
}

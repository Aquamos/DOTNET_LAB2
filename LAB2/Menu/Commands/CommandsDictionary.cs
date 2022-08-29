using Commands.EnumCommands;
using Services;
using Services.Write;
using Data;

namespace Menu.Commands
{
    public class CommandsDictionary
    {
        private Dictionary<MenuCommands, Func<MenuSeeder, (int, MenuCommands)>> _menuCommands;
        private Dictionary<XMlCommands, Action> _xmlCommands;
        private Dictionary<InfoCommands, Action> _InfoCommands;
        private Dictionary<SortCommands, Action> _sortCommands;
        private Dictionary<GroupCommands, Action> _groupCommands;
        private Dictionary<SearchCommands, Action> _searchCommands;
        private Dictionary<ACCommands, Action> _acCommands;

        private Printer _printer;
        private readonly ContextXml _context;
        private MenuMethods _menuMethods;
        private WriteToXml _writeToXml;
        public CommandsDictionary() {
            _printer = new Printer();
            _context = ContextXml.GetContext();

            _menuMethods = new MenuMethods();
            _writeToXml = new WriteToXml();

            _menuCommands = new Dictionary<MenuCommands, Func<MenuSeeder, (int, MenuCommands)>>()
            {
                {MenuCommands.MainMenu, _menuMethods.ShowMainMenu },
                {MenuCommands.XMLMenu, _menuMethods.ShowXmlMenu },
                {MenuCommands.FullInfoMenu, _menuMethods.ShowFullInfoMenu },
                {MenuCommands.SortedMenu, _menuMethods.ShowSortedMenu },
                {MenuCommands.SearchMenu, _menuMethods.ShowSearchMenu },
                {MenuCommands.GroupMenu, _menuMethods.ShowGroupMenu },
                {MenuCommands.AggregateAndCollectionsMenu, _menuMethods.ShowAggregateAndCollectionsMenu }
            };

            _xmlCommands = new Dictionary<XMlCommands, Action>()
            {
                {XMlCommands.AddNewRank, _writeToXml.AddNewRank},
                {XMlCommands.AddNewDepartment, _writeToXml.AddNewDepartment},
                {XMlCommands.AddNewGroup, _writeToXml.AddNewGroup},
                {XMlCommands.AddNewResource, _writeToXml.AddNewResource},
                {XMlCommands.AddNewResourceType, _writeToXml.AddNewResourceType},
                {XMlCommands.AddNewStudent, _writeToXml.AddNewStudent},
                {XMlCommands.AddNewTeacher, _writeToXml.AddNewTeacher},
                {XMlCommands.AddNewSaR, _writeToXml.AddNewSaR},
                {XMlCommands.AddNewSaT, _writeToXml.AddNewSaT},
            };

            _InfoCommands = new Dictionary<InfoCommands, Action>() 
            {
                {InfoCommands.PrintStudentsFullInfo, _printer.PrintStudentsFullInfo },
                {InfoCommands.PrintTeacherFullInfo, _printer.PrintTeachersFullInfo },
                {InfoCommands.PrintResourcesFullInfo, _printer.PrintResourcesFullInfo },
                {InfoCommands.PrintTeachersAndStudentsInfo, _printer.PrintTeachersAndStudentsInfo},
                {InfoCommands.PrintStudentsAndTeachersInfo, _printer.PrintStudentsAndTeachersInfo},
                {InfoCommands.PrintStudentsAndResourcesInfo,  _printer.PrintStudentsAndResourcesInfo},
                {InfoCommands.PrintStudentsDiplomaDefense, _printer.PrintStudentsDiplomaDefense },
                {InfoCommands.PrintTeachersWithCountStudents, _printer.PrintTeachersWithCountStudents },
                {InfoCommands.PrintTopGPAStudents, _printer.PrintTopGPAStudents },
                {InfoCommands.PrintMaxRankLength, _printer.PrintMaxRankLength },
            };

            _sortCommands = new Dictionary<SortCommands, Action>()
            {
                {SortCommands.PrintStudentsSortedByNameThenByBirthDate, _printer.PrintStudentsSortedByNameThenByBirthDate},
                {SortCommands.PrintStudentsSortedByDefenceDateThenByName, _printer.PrintStudentsSortedByDefenceDateThenByName }
            };

            _searchCommands = new Dictionary<SearchCommands, Action>()
            {
                {SearchCommands.PrintStudentsFromDateOfDefense, _printer.PrintStudentsFromDateOfDefense },
                {SearchCommands.PrintStudentsTopicsByFaculty, _printer.PrintStudentsTopicsByFaculty},
            };

            _groupCommands = new Dictionary<GroupCommands, Action>()
            {
                {GroupCommands.PrintGroupOfStudentsByDateOfDefense, _printer.PrintGroupOfStudentsByDateOfDefense }
            };

            _acCommands = new Dictionary<ACCommands, Action>()
            {
                {ACCommands.PrintMaxAverageGPAByDepartments, _printer.PrintAverageGPAByDepartments },
                {ACCommands.PrintDistinctStudentsResources, _printer.PrintDistinctStudentsResources },
                {ACCommands.PrintStudentsWithTopGPAAndMoreThanInputResources,
                _printer.PrintStudentsWithTopGPAAndMoreThanInputResources}
            };
        }
        public Func<MenuSeeder, (int, MenuCommands)> this[MenuCommands index] => _menuCommands[index];
        public Action this[XMlCommands index] => _xmlCommands[index];
        public Action this[InfoCommands index] => _InfoCommands[index];
        public Action this[SortCommands index] => _sortCommands[index];
        public Action this[SearchCommands index] => _searchCommands[index];
        public Action this[GroupCommands index] => _groupCommands[index];
        public Action this[ACCommands index] => _acCommands[index];

    }
}

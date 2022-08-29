using static System.Console;
using Commands.EnumCommands;


namespace Menu.Commands
{
    public class MenuController
    {
        private CommandsDictionary _commandsDictionary;
        private MenuSeeder _menuSeeder;
        private MenuCommands _menuCommands;
        private int _selectedIndex;
        public MenuController()
        {
            _commandsDictionary = new CommandsDictionary();
            _menuSeeder = new MenuSeeder();
        }
        public void Run()
        {
            _selectedIndex = _menuSeeder.Menus[MenuCommands.MainMenu].Run();
            while (true)
            {
                (_selectedIndex, _menuCommands) = _commandsDictionary[(MenuCommands)_selectedIndex].Invoke(_menuSeeder);
                if (_menuCommands != MenuCommands.MainMenu && _selectedIndex != -1)
                {
                    InvokeMenuCommand();
                }
            }
        }
        private void InvokeMenuCommand()
        {
            Clear();
            switch (_menuCommands)
            {
                case MenuCommands.FullInfoMenu:
                    {
                        _commandsDictionary[(InfoCommands)_selectedIndex].Invoke();
                        _selectedIndex = (int)MenuCommands.FullInfoMenu;
                        break;
                    }
                case MenuCommands.SortedMenu:
                    {
                        _commandsDictionary[(SortCommands)_selectedIndex].Invoke();
                        _selectedIndex = (int)MenuCommands.SortedMenu;
                        break;
                    }
                case MenuCommands.SearchMenu:
                    {
                        _commandsDictionary[(SearchCommands)_selectedIndex].Invoke();
                        _selectedIndex = (int)MenuCommands.SearchMenu;
                        break;
                    }
                case MenuCommands.GroupMenu:
                    {
                        _commandsDictionary[(GroupCommands)_selectedIndex].Invoke();
                        _selectedIndex = (int)MenuCommands.GroupMenu;
                        break;
                    }
                case MenuCommands.AggregateAndCollectionsMenu:
                    {
                        _commandsDictionary[(ACCommands)_selectedIndex].Invoke();
                        _selectedIndex = (int)MenuCommands.AggregateAndCollectionsMenu;
                        break;
                    }
                case MenuCommands.XMLMenu:
                    {
                        _commandsDictionary[(XMlCommands)_selectedIndex].Invoke();
                        _selectedIndex = (int)MenuCommands.XMLMenu;
                        break;
                    }
            }

            WriteLine("Press any key to return to the menu.");
            ReadKey(true);
        }
    }
}

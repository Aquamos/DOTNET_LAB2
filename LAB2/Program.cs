using Menu.Commands;
using Services.Read;

namespace LAB2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                Context context = Context.GetContext();
                DataSeeder dataSeeder = new DataSeeder(context);
                XMLDataSeeder xmlDataSeeder = new XMLDataSeeder(context);
                */

                XMLReader xmlReader = new XMLReader();
                xmlReader.ReadAll();

                MenuController menuController = new MenuController();
                menuController.Run();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
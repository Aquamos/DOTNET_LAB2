using Models.Interfaces;
using static System.Console;
using System.Globalization;
using System.Xml.Linq;

namespace HelperMethods
{
    public class Helper
    {
        public static DateTime GetDateFromConsole(
            string message = "Please enter date in format dd-MM-yyyy: ")
        {
            DateTime dt;
            string input;
            do
            {
                Clear();
                WriteLine(message);
                input = ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dt));

            return dt;
        }
        public static string GetStringFromConsole(string message, int neededSymbols = 0)
        {
            string input;
            if (neededSymbols != 0)
            {
                do
                {
                    Clear();
                    WriteLine(message);
                    input = ReadLine();
                }
                while (String.IsNullOrEmpty(input) && input.Length == neededSymbols);
            }
            else
            {
                do
                {
                    Clear();
                    WriteLine(message);
                    input = ReadLine();
                }
                while (String.IsNullOrEmpty(input));
            }
            return input;
        }
        public static int GetIntFromConsole(
            string message, 
            int neededSymbols = 0,
            Action<string, IEnumerable<XElement>> preAction = null,
            string preActionMessage = null,
            Func<IEnumerable<XElement>, int, bool> idChecker = null,
            IEnumerable<XElement> models = null)
        {
            string input;
            int result = 0;
            bool success = false;
            
            if (neededSymbols != 0)
            {
                do
                {
                    Clear();
                    preAction?.Invoke(preActionMessage, models);
                    WriteLine(message);
                    input = ReadLine();
                    if (!String.IsNullOrEmpty(input))
                    {
                        if (int.TryParse(input, out int res))
                        {
                            if (models != null)
                            {
                                if (idChecker(models, res))
                                {
                                    result = res;
                                    success = true;
                                }
                            }
                            else
                            {
                                result = res;
                                success = true;
                            }           
                        }
                    } 
                }
                while (input.Length == neededSymbols && !success);
            }
            else
            {
                do
                {
                    Clear();
                    preAction?.Invoke(preActionMessage, models);
                    WriteLine(message);
                    input = ReadLine();
                    if (!String.IsNullOrEmpty(input))
                    {
                        if (int.TryParse(input, out int res))
                        {
                            if (models != null)
                            {
                                if (idChecker(models, res))
                                {
                                    result = res;
                                    success = true;
                                }
                            }
                            else
                            {
                                result = res;
                                success = true;
                            }

                        }
                    }
                }
                while (!success);
            }
            return result;
        }
        public static decimal GetDecimalFromConsole(
            string message,
            int neededSymbols = 0,
            Action preAction = null)
        {
            string input;
            decimal result = 0;
            bool success = false;
            preAction?.Invoke();
            if (neededSymbols != 0)
            {
                do
                {
                    Clear();
                    WriteLine(message);
                    input = ReadLine();
                    if (decimal.TryParse(input, out decimal res))
                    {
                        result = res;
                        success = true;
                    }
                }
                while (String.IsNullOrEmpty(input) &&
                input.Length == neededSymbols && !success);
            }
            else
            {
                do
                {
                    Clear();
                    WriteLine(message);
                    input = ReadLine();
                    if (decimal.TryParse(input, out decimal res))
                    {
                        result = res;
                        success = true;
                    }
                }
                while (String.IsNullOrEmpty(input) && !success);
            }
            return result;
        }
        public static string GetUncheckedStringFromConsole(string message)
        {
            string input;
            Clear();
            WriteLine(message);
            input = ReadLine();
            if (string.IsNullOrEmpty(input))
                input = String.Empty;
            return input;
        }
        public static void PrintCollectionToConsole(string message, IEnumerable<XElement> models)
        {
            WriteLine(message);
            foreach (XElement model in models)
                WriteLine(model.ToString());
        }
    }
}

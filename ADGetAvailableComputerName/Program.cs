using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.InteropServices;

namespace ADGetAvailableComputerName
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryEntry de = GetDirectoryObject();
            // System.DirectoryServices.DirectoryServicesCOMException: 'The user name or password is incorrect.'

            try
            {
                Run(de);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("The user name or password is incorrect."))
                {
                    Console.WriteLine("The username or password is incorrect");
                    Main(args);
                }
                else
                {
                    Console.WriteLine(e);
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("END OF PROGRAM");
            Console.Read();

            de.Close();

            Environment.Exit(0);
        }

        private static void Run(DirectoryEntry de)
        {
            SearchForComputerTest(de.Parent);
            //Console.WriteLine(de.Parent.Path);

            //foreach (DirectoryEntry entry in de.Parent)
            //{
            //    Console.WriteLine(entry.Name);
            //}
        }

        private static List<DirectoryEntry> GetComputers(DirectoryEntry de)
        {
            List<DirectoryEntry> ComputerNames = new List<DirectoryEntry>();

            DirectorySearcher ds = new DirectorySearcher(de);
            ds.Filter = ("(objectClass=computer)");
            ds.SizeLimit = Int32.MaxValue;
            ds.PageSize = Int32.MaxValue;

            foreach (SearchResult result in ds.FindAll())
            {
                Console.CursorLeft = 0;
                Console.Write($"Searching ({ComputerNames.Count})");

                DirectoryEntry ComputerEntry = result.GetDirectoryEntry();

                ComputerNames.Add(ComputerEntry);
            }

            ds.Dispose();

            return ComputerNames;
        }

        private static void SearchForComputerTest(DirectoryEntry de, string prevPrefix = "", int prevCnt = 0, int prevLength = 0)
        {
            Console.Write($"Search for computer{(prevPrefix != "" ? $" [{prevPrefix}]" : "")}: ");
            string prefix = Console.ReadLine();

            if (string.IsNullOrEmpty(prefix))
            {
                prefix = prevPrefix;
            }

            Console.Write($"Starting number{(prevCnt != 0 ? $"[{prevCnt}]" : "")}: ");
            int cnt = GetIntFromConsoleRead();

            if (cnt == 0)
            {
                if (prevCnt == 0)
                {
                    Console.WriteLine("Defaulting to 1");
                    cnt = 1;
                }
                else
                {
                    cnt = prevCnt;
                }
            }

            Console.Write($"Number length{(prevLength != 0 ? $"[{prevLength}]" : "")}: ");
            int length = GetIntFromConsoleRead();

            GlobalCatalog gc = Forest.GetCurrentForest().FindGlobalCatalog();
            DirectorySearcher ds = gc.GetDirectorySearcher();

            List<string> openNamesList = new List<string>();

            int startingCnt = cnt;

            while (true)
            {
                string scnt = cnt.ToString();

                while (scnt.Length < length)
                    scnt = $"0{scnt}";

                ds.Filter = $"(&(ObjectCategory=computer)(name={prefix}{scnt}))";
                //DirectorySearcher ds = new DirectorySearcher(de,$"(&(ObjectCategory=computer)(name={Console.ReadLine()}))");

                SearchResultCollection resultCollection = ds.FindAll();

                if (resultCollection.Count == 0)
                {
                    openNamesList.Add($"{prefix}{scnt}");

                    if (openNamesList.Count == 10)
                        break;
                }
                cnt++;
            }
            Console.WriteLine($"Search finished in {ds.SearchRoot.Path}");
            Console.WriteLine("Available names:");
            foreach (string s in openNamesList)
            {
                Console.WriteLine($" {s}");
            }
            Console.WriteLine($"\nSearch again?");

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            if (consoleKeyInfo.Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                SearchForComputerTest(de, prefix, startingCnt, length);
            }
        }

        private static int GetIntFromConsoleRead()
        {
            try
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return 0;
                }

                return Convert.ToInt32(input);
            }
            catch
            {
                Console.Write($"Error: Not a number, numbers only from 0 to {int.MaxValue}\nInput a real number please: ");
                return GetIntFromConsoleRead();
            }
        }

        private static DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry oDE;

            Console.Write("Username: ");
            string user = Console.ReadLine();

            Console.Write("Password: ");
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    //Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
            } while (true);

            oDE = new DirectoryEntry("LDAP://SK-OPPVEKST", user, pass, AuthenticationTypes.Secure);
            return oDE;
        }
    }
}

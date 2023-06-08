using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Linq;
using Module7;

namespace Module7
{
    internal class Program
    {
        static void Main()
        {
            string path = "staff.txt";
            Repository repository = new Repository(path);
            WriteLine(repository.GetAllWorkers());
            repository.PrintToConsole();
            ReadKey();
        }
    }
}
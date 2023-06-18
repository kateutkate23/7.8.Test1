using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Linq;
using Module7;
using System.Globalization;

namespace Module7
{
    internal class Program
    {
        static int Main()
        {
            string path = "staff.txt";
            Repository repository = new Repository(path);
            WriteLine("Выберите желаемое действие: ");
            WriteLine("1 - вывод сотрудников в консоль");
            WriteLine("2 - получение сотрудника по ID");
            WriteLine("3 - удаление сотрудника по ID");
            WriteLine("4 - добавление сотрудника");
            WriteLine("5 - выход из программы");
            string ans = ReadLine();
            int id;
            switch (ans)
            {
                case "1":
                    repository.PrintToConsole();
                    break;
                case "2":
                    WriteLine("Введите ID: ");
                    id = int.Parse(ReadLine());
                    WriteLine(repository.GetWorkerById(id).Print());
                    break;
                case "3":
                    WriteLine("Введите ID: ");
                    id = int.Parse(ReadLine());
                    repository.DeleteWorker(id);
                    break;
                case "4":
                    repository.AddWorker(repository.InputWorker());
                    break;
                case "5":
                    WriteLine("Выход из программы...");
                    ReadKey();
                    return 0;
                default:
                    WriteLine("Ошибка ввода! Выход из программы...");
                    ReadKey();
                    return 0;
            }
            ReadKey();
            return 0;
        }
    }
}
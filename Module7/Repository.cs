using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Linq;

namespace Module7
{
    /// <summary>
    /// Структура для работы с сотрудниками
    /// </summary>
    class Repository
    {
        private Worker[] workers;
        private string path;
        int index;

        /// <summary>
        /// Создание репозитория сотрудников
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        public Repository(string path)
        {
            this.path = path;
            index = 0;
            workers = new Worker[1];

            GetAllWorkers();
        }

        /// <summary>
        /// Увеличение объема хранилища
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref workers, workers.Length * 2);
            }
        }
        /// <summary>
        /// Добавление сотрудника в хранилище
        /// </summary>
        /// <param name="tempWorker">Сотрудник</param>
        public void Add(Worker worker)
        {
            Resize(index >= workers.Length);
            workers[index] = worker;
            index++;
        }

        /// <summary>
        /// Получение даты из строки
        /// </summary>
        /// <param name="date">Строка с датой</param>
        /// <returns></returns>
        private DateTime ShortDate(string date)
        {
            string[] splitBirth = date.Split('.');
            double day = Double.Parse(splitBirth[0]), month = Double.Parse(splitBirth[1]), year = Double.Parse(splitBirth[2]);
            DateTime birthDate = new DateTime((int)year, (int)month, (int)day);
            return birthDate;
        }
        
        /// <summary>
        /// Получение даты и времени из строки
        /// </summary>
        /// <param name="s">Строка с датой и временем</param>
        /// <returns></returns>
        private DateTime FullDate(string s)
        {
            string[] splitTemp = s.Split('.');
            string st = splitTemp[2];
            string[] yearAndTime = st.Split(' ');
            st = yearAndTime[1];
            string[] time = st.Split(':');
            double dayT = Double.Parse(splitTemp[0]), monthT = Double.Parse(splitTemp[1]), yearT = Double.Parse(yearAndTime[0]);
            double hourT = Double.Parse(time[0]), minuteT = Double.Parse(time[1]), secondT = Double.Parse(time[2]);
            DateTime tempDate = new DateTime((int)yearT, (int)monthT, (int)dayT, (int)hourT, (int)minuteT, (int)secondT);
            return tempDate;
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="Path">Путь к файлу сохранения</param>
        public void Save(string path)
        {
            if (File.Exists(path)) { File.Delete(path); }
            for (int i = 0; i < index; i++)
            {
                string temp = $"{workers[i].Id}#{workers[i].Tempdate}#{workers[i].Fio}#" +
                    $"{workers[i].Age}#{workers[i].Height}#" +
                    $"{workers[i].Birthdate}#{workers[i].Birthcity}";
                File.AppendAllText(path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintToConsole()
        {
            for (int i = 0; i < index; i++)
            {
                WriteLine(workers[i].Print());
            }
        }

        /// <summary>
        /// Получение массива сотрудников типа Worker[]
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split('#');
                    Worker tempWorker = new Worker(FullDate(data[1]), int.Parse(data[0]), data[2], 
                        int.Parse(data[3]), int.Parse(data[4]), FullDate(data[5]), data[6]);
                    Add(tempWorker);
                }
                return workers;
            }
        }

        /// <summary>
        /// Получение сотрудника по ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split('#');
                    if (int.Parse(data[0]) == id)
                    {
                        Worker tempWorker = new Worker(FullDate(data[1]), int.Parse(data[0]), data[2], 
                            int.Parse(data[3]), int.Parse(data[4]), FullDate(data[5]), data[6]);
                        return tempWorker;
                    }
                }
                return new Worker();
            }
        }
        /// <summary>
        /// Запись всех сотрудников кроме одного
        /// </summary>
        /// <param name="id">ID удаляемого сотрудника</param>
        public void DeleteWorker(int id)
        {
            File.Copy(path, "staffCopy.txt");
            File.Delete(path);
            Repository repositoryTemp = new Repository("staffCopy.txt");
            for (int i = 0; i < index; i++)
            {
                if (id == repositoryTemp.workers[i].Id)
                {
                    continue;
                }
                else
                {
                    string temp = $"{repositoryTemp.workers[i].Id}#{repositoryTemp.workers[i].Tempdate}#{repositoryTemp.workers[i].Fio}#" +
                    $"{repositoryTemp.workers[i].Age}#{repositoryTemp.workers[i].Height}#" +
                    $"{repositoryTemp.workers[i].Birthdate}#{repositoryTemp.workers[i].Birthcity}";
                    File.AppendAllText(path, $"{temp}\n");
                }
            }
            WriteLine($"Из файла {path} был удален сотрудник с ID {id}");
            File.Delete("staffCopy.txt");
        }

        /// <summary>
        /// Ввод сотрудника и присвоение ему уникального ID
        /// </summary>
        /// <returns>Введенный сотрудник</returns>
        public Worker InputWorker()
        {
            int id;
            if (!File.Exists("staff.txt"))
            {
                id = 0;
            }
            else
            {
                string[] str = File.ReadAllLines("staff.txt");
                var lastString = str[str.Length - 1];
                id = int.Parse(lastString.Split('#')[0]);
            }
            Write("Введите ФИО сотрудника: ");
            string fullName = ReadLine();
            Write("Введите возраст сотрудника: ");
            string age = ReadLine();
            Write("Введите рост сотрудника: ");
            string height = ReadLine();
            Write("Введите дату рождения сотрудника в формате DD.MM.YYYY: ");
            string s = ReadLine() + " 0:00:00";
            DateTime birthDate = FullDate(s);
            Write("Введите место рождения сотрудника: ");
            string city = ReadLine();
            return new Worker(DateTime.Now, ++id, fullName, int.Parse(age), int.Parse(height), birthDate, city);
        }

        /// <summary>
        /// Добавление сотрудника в хранилище
        /// </summary>
        /// <param name="tempWorker">Сотрудник</param>
        public void AddWorker(Worker worker)
        {
            string temp = $"{worker.Id}#{worker.Tempdate}#{worker.Fio}#" +
                    $"{worker.Age}#{worker.Height}#" +
                    $"{worker.Birthdate}#{worker.Birthcity}";
            File.AppendAllText(path, $"{temp}\n");
            WriteLine($"В файл {path} был добавлен новый сотрудник");
        }
    }
}

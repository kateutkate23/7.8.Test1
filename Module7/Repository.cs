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
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            workers = new Worker[1];

            this.GetAllWorkers();
        }

        /// <summary>
        /// Увеличение объема хранилища
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }

        /// <summary>
        /// Добавление сотрудника в хранилище
        /// </summary>
        /// <param name="tempWorker">Сотрудник</param>
        public void Add(Worker tempWorker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = tempWorker;
            this.index++;
        }
        
        private DateTime ShortDate(string date)
        {
            string[] splitBirth = date.Split('.');
            double day = Double.Parse(splitBirth[0]), month = Double.Parse(splitBirth[1]), year = Double.Parse(splitBirth[2]);
            DateTime birthDate = new DateTime((int)year, (int)month, (int)day);
            return birthDate;
        }
        
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
        public void Save(string Path)
        {
            for (int i = 0; i < this.index; i++)
            {
                string temp = $"{this.workers[i].Id} {this.workers[i].TempDate} {this.workers[i].Fio} {this.workers[i].Age} {this.workers[i].Height} " +
                    $"{this.workers[i].Birthdate} {this.workers[i].Birthcity}";
                File.AppendAllText(Path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintToConsole()
        {
            for (int i = 0; i < index; i++)
            {
                WriteLine(this.workers[i].Print());
            }
        }

        public Worker[] GetAllWorkers()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split('#');     
                    Worker tempWorker = new Worker(FullDate(data[1]), int.Parse(data[0]), data[2], int.Parse(data[3]), int.Parse(data[4]), ShortDate(data[5]), data[6]);
                    Add(tempWorker);
                }
                return workers;
            }
        }

        //public Worker GetWorkerById(int id)
        //{

        //}
        public void DeleteWorker(int id)
        {

        }
        public void AddWorker(Worker worker)
        {

        }
        //public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        //{

        //}
    }
}

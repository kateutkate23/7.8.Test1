using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Linq;

namespace Module7
{
    struct Worker
    {
        private DateTime tempdate;
        private int id;
        private string fio;
        private int age;
        private int height;
        private DateTime birthdate;
        private string birthcity;

        /// <summary>
        /// Текущее время
        /// </summary>
        public DateTime TempDate
        {
            get { return this.tempdate; } set { this.tempdate = value; }
        }
        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get { return this.id; } set { this.id = value; }
        }
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio
        {
            get { return this.fio; } set { this.fio = value; }
        }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get { return this.age; } set { this.age = value; }
        }
        /// <summary>
        /// Рост
        /// </summary>
        public int Height
        {
            get { return this.height; } set { this.height = value; }
        }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthdate
        {
            get { return this.birthdate; } set { this.birthdate = value; }
        }
        /// <summary>
        /// Город рождения
        /// </summary>
        public string Birthcity
        {
            get { return this.birthcity; }
            set { this.birthcity = value; }
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="TempDate">Дата создания записи</param>
        /// <param name="Id">ID</param>
        /// <param name="FIO">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Height">Рост</param>
        /// <param name="BirthDate">Дата рождения</param>
        /// <param name="BirthCity">Город рождения</param>
        public Worker(DateTime TempDate, int Id, string FIO, int Age,
                      int Height, DateTime BirthDate, string BirthCity)
        {
            this.tempdate = TempDate;
            this.id = Id;
            this.fio = FIO;
            this.age = Age;
            this.height = Height;
            this.birthdate = BirthDate;
            this.birthcity = BirthCity;
        }

        /// <summary>
        /// Вывод информации о сотруднике
        /// </summary>
        /// <returns>Строка, содержащая данные о сотруднике</returns>
        public string Print()
        {
            return $"{this.id} {this.tempdate} {this.fio} {this.age} {this.height} {this.birthdate} {this.birthcity}";
        }
    }
}

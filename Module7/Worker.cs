using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Linq;

namespace Module7
{
    struct Worker
    {
        /// <summary>
        /// Текущее время
        /// </summary>
        public DateTime Tempdate { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// Город рождения
        /// </summary>
        public string Birthcity { get; set; }

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
            Tempdate = TempDate;
            this.Id = Id;
            Fio = FIO;
            this.Age = Age;
            this.Height = Height;
            Birthdate = BirthDate;
            Birthcity = BirthCity;
        }

        /// <summary>
        /// Вывод информации о сотруднике
        /// </summary>
        /// <returns>Строка, содержащая данные о сотруднике</returns>
        public string Print()
        {
            return $"{this.Id} {this.Tempdate} {this.Fio} {this.Age} " +
                $"{this.Height} {this.Birthdate} {this.Birthcity}";
        }
    }
}

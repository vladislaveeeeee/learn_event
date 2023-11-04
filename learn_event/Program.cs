using System;
using System.Collections.Generic;
using static System.Console;
namespace MyApp
{
    internal class Program
    {
        public delegate void DelExam(string vari);

        class Student
        {
            public string name { get; set; }
            public string surname { get; set; }
            public DateTime birth { get; set; }

            public int numerok { get; set; }

            public void generate_num()
            {
                numerok = (surname.Length % 2 == 0) ? 2 : 1;
            }

            public void exam(string vari)
            {
                WriteLine($"Студент {name} {surname}, номер: {surname.Length}, варінт: {numerok}, отримав {vari}");
            }
        }

        class Teacher
        {
            public event DelExam action;
            public void exam(string завдання)
            {
                if (action != null)
                {
                    action(завдання);
                }
            }
        }

        static void Main(string[] args)
        {
            List<Student> група = new List<Student>
            {
                new Student
                {
                    surname = "Рошко",
                    name = "Владислав",
                    birth = new DateTime(1997, 3, 12)
                },
                new Student
                {
                    surname = "Рошко",
                    name = "Артем",
                    birth = new DateTime(1997, 3, 12)
                },
                new Student
                {
                    surname = "Кітар",
                    name = "Павло",
                    birth = new DateTime(1997, 3, 12)
                },
                new Student
                {
                    surname = "Коханюк",
                    name = "Алла",
                    birth = new DateTime(1997, 3, 12)
                },
                new Student
                {
                    surname = "Мірош",
                    name = "Юрій",
                    birth = new DateTime(1997, 3, 12)
                },
                new Student
                {
                    surname = "Фуга",
                    name = "Андрій",
                    birth = new DateTime(1997, 3, 12)
                },
            };

            Teacher викладач = new Teacher();
            foreach (Student студент in група)
            {
                студент.generate_num();
                викладач.action += студент.exam;
            }

            викладач.exam("завдання.");
        }
    }
}
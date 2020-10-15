using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Tasks
{
    class T15_10_2020
    {
        public static string[] lessons = new string[]
        {
            "Математика",
            "Русский язык",
            "Физика",
            "Информатика",
            "Физ-ра"
        };
        public class Student
        {
            public string FirstName;
            public string LastName;
            public string Patronymic;
            public int Age;
            public DateTime Date;
            public Dictionary<string, int> Lessons;

            public Student(string firstName, string lastName, string patronymic, int age, DateTime date, int[] marks)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Patronymic = patronymic;
                this.Age = age;
                this.Date = date;

                if (marks.Length < lessons.Length) throw new Exception("Развер массива оценок меньше колличества предметов");
                this.Lessons = new Dictionary<string, int>();
                for (int i = 0; i < lessons.Length; i++) Lessons.Add(lessons[i], marks[i]);
            }
            public Student(string firstName, string lastName, int age, DateTime date, int[] marks) : this(firstName, lastName, "", age, date, marks) { }
            public Student(string firstName, string lastName, string patronymic, int age, string date, int[] marks)
                : this(firstName, lastName, patronymic, age, DateTime.Parse(date), marks) { }
            public Student(string firstName, string lastName, int age, string date, int[] marks)
                : this(firstName, lastName, "", age, DateTime.Parse(date), marks) { }

            public string FullName { get => $"{FirstName} {LastName}{(Patronymic != "" ? $" {Patronymic}" : "")}"; }

        }
        static List<Student> students = new List<Student>();

        static void RemoveStudentById(int ind) => students.RemoveAt(ind);
        static void EditStudent(int ind)
        {
            Student st = students[ind];

            Console.Clear();
            Console.WriteLine("Enter - редактировать, управление стрелками\n"); 
            
            List<helper.Param> plist = new List<helper.Param>()
            {
                new helper.Param("Имя", st.FirstName, require: true),
                new helper.Param("Фамилия", st.LastName, require: true),
                new helper.Param("Отчество", st.Patronymic),
                new helper.Param("Возраст", st.Age.ToString(), @"\D\D\D", true),
                new helper.Param("Дата рождения", st.Date.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")), @"\d\d.\d\d.\d\d\d\d", true)
            };
            for (int i = 0; i < lessons.Length; i++) plist.Add(new helper.Param($"Предмет {lessons[i]}", st.Lessons[lessons[i]].ToString(), @"\d", true));

           // helper.mb(plist.Aggregate("", (a, s) => a += $"{s.Name} = {s.Value}\n"));
            helper.EditParams(plist);
           // helper.mb(plist.Aggregate("", (a, s) => a += $"{s.Name} = {s.Value}\n"));

            st.FirstName = plist[0].Value;
            st.LastName = plist[1].Value;
            st.Patronymic = plist[2].Value;
            st.Age = int.Parse(plist[3].Value);
            st.Date = DateTime.Parse(plist[4].Value);

            for (int i = 0; i < lessons.Length; i++)
            {
                st.Lessons[lessons[i]] = int.Parse(plist[5 + i].Value);
            }
        }
        static void AddStudent()
        {
            Student st = new Student("", "", "", 18, new DateTime(2002, 12, 22), new int[] { 5, 5, 5, 5, 5 });
            students.Add(st);

            EditStudent(students.Count - 1);
        }

        public static void Main_()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter - выбрать/редактировать, del - удалить\n");

                List<string> CList = new List<string>();
                foreach (Student s in students) CList.Add(s.FullName);
                CList.Add("Добавить студента");
                int c = helper.Choice(CList.ToArray(),
                    (ConsoleKey key, int sel) =>
                    {
                        if (key == ConsoleKey.Delete)
                        {
                            RemoveStudentById(sel);
                            return -1;
                        }
                        return null;
                    }
                );
                if (c == -1) continue;
                if (c == students.Count) AddStudent();
                else EditStudent(c);
            }
        }
    }
}

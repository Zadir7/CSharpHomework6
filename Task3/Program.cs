using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        public Student(string firstName, string lastName, string university,
        string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} {university} {faculty} {department} {course} {age} {group} {city}";
        }
    }
    class Program
    {
        private static int SortStudentsAge(Student s1, Student s2)
        {
            return s1.age < s2.age ? -1 : 1;
        }
        private static int SortStudentsCourseAge(Student s1, Student s2)
        {
            if (s1.course == s2.course) { return s1.age < s2.age ? -1 : 1; }
            else return s1.course < s2.course ? -1 : 1;
        }


        static void Main(string[] args)
        {
            List<Student> studs = new List<Student>()
        {
            new Student("Саня", "Бондарев", "АлтГТУ", "ФИТ", "Приборостроение", 5, 25, 61, "Барнаул"),
            new Student("Илья", "Спирин", "АлтГТУ", "ФИТ", "Приборостроение", 2, 21, 61, "Барнаул"),
            new Student("Настя", "Андреева", "АлтГТУ", "ФИТ", "Приборостроение", 2, 21, 61, "Барнаул"),
            new Student("Петр", "Кабанов", "АлтГТУ", "ФИТ", "Приборостроение", 2, 19, 61, "Барнаул"),
            new Student("Валерия", "Сафронова", "АлтГТУ", "ФИТ", "Приборостроение", 6, 27, 61, "Барнаул"),
            new Student("Елена", "Немцова", "АлтГТУ", "ФИТ", "Приборостроение", 1, 20, 61, "Барнаул"),
        };

            int course56 = 0;
            List<int> arr = new List<int>() { 0, 0, 0, 0, 0, 0 };

            foreach (var std in studs)
            {
                if (std.course == 5 || std.course ==6) { course56++; }
                if (std.age <= 20 && std.age >= 18)
                {
                    arr[std.course - 1]++;
                }
            }
            Console.WriteLine($"На 5 и 6 курсе учится {course56} студентов.");
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine($"На курсе {i+1} учится {arr[i]} студентов от 18 до 20.");
            }
            Console.WriteLine();

            Console.WriteLine("Начальный список студентов:");
            foreach (var std in studs)
            {
                Console.WriteLine(std);
            }
            Console.WriteLine();

            studs.Sort(SortStudentsAge);
            Console.WriteLine("Список студентов после сортировки по возрасту:");
            foreach (var std in studs)
            {
                Console.WriteLine(std);
            }
            Console.WriteLine();

            Console.WriteLine("Список студентов после сортировки по курсу и возрасту:");
            studs.Sort(SortStudentsCourseAge);
            foreach (var std in studs)
            {
                Console.WriteLine(std);
            }
            Console.ReadKey();
        }
    }
}

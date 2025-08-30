using System;
using System.Collections.Generic;

namespace delegate_dat
{
    internal class Program
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double GPA { get; set; }

            public Student(int id, string name, double gpa)
            {
                Id = id;
                Name = name;
                GPA = gpa;
            }

            public override string ToString()
            {
                return "ID: " + Id + ", Name: " + Name + ", GPA: " + GPA;
            }
        }

        // Delegate dùng cho sắp xếp
        public delegate int StudentComparison(Student s1, Student s2);

        // Delegate dùng cho event
        public delegate void StudentAddedHandler();
        public class StudentList
        {
            private List<Student> students = new List<Student>();

            public event StudentAddedHandler OnStudentAdded;

            public StudentComparison CompareMethod { get; set; }

            public void AddStudent(Student student)
            {
                students.Add(student);

                if (OnStudentAdded != null)
                {
                    OnStudentAdded();
                }
            }
            public void Sort()
            {
                if (CompareMethod != null)
                {
                    students.Sort(delegate (Student s1, Student s2)
                    {
                        return CompareMethod(s1, s2);
                    });
                }
            }
            public void PrintAll()
            {
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine(students[i]);
                }
            }
        }

        static int CompareGpaAsc(Student s1, Student s2)
        {
            return s1.GPA.CompareTo(s2.GPA);
        }

        static int CompareGpaDesc(Student s1, Student s2)
        {
            return s2.GPA.CompareTo(s1.GPA);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StudentList list = new StudentList();

            //GPA tăng dần
            list.CompareMethod = new StudentComparison(CompareGpaAsc);

            // Event
            list.OnStudentAdded += new StudentAddedHandler(delegate ()
            {
                Console.WriteLine("\nThêm sinh viên");
                list.Sort();
                list.PrintAll();
            });

            list.AddStudent(new Student(1, "Huy", 3.2));
            list.AddStudent(new Student(2, "Linh", 2.8));
            list.AddStudent(new Student(3, "Cường", 3.9));

            Console.WriteLine("\n-Sắp xếp GPA giảm dần-");
            list.CompareMethod = new StudentComparison(CompareGpaDesc);

            list.AddStudent(new Student(4, "Khiêm copy", 3.5));

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace DelegateEventExample
{
    class Program
    {
        public static int CompareByGpaAsc(Student s1, Student s2)
        {
            return s1.GPA.CompareTo(s2.GPA);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StudentList list = new StudentList();

            list.AddStudent(new Student(1, "Nguyễn Văn A", 3.3));
            list.AddStudent(new Student(2, "Trần Thị B", 2.0));
            list.AddStudent(new Student(3, "Phan Văn C", 3.8));
            list.AddStudent(new Student(4, "Lưu Thị D", 3.5));
            list.CompareMethod = new StudentCompare(CompareByGpaAsc);

            list.OnStudentAdded += list.Sort;
            list.OnStudentAdded += list.Print;
        }
    }
}

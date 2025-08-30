namespace DelegateEventExample
{
    public delegate int StudentCompare(Student s1, Student s2);

    public class StudentList
    {
        private List<Student> students = new List<Student>();
        public StudentCompare CompareMethod;

        public event Action OnStudentAdded;
        public void AddStudent(Student s)
        {
            students.Add(s);

            // Gọi event
            if (OnStudentAdded != null)
            {
                OnStudentAdded();
            }
        }

        public void Sort()
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - i - 1; j++)
                {
                    if (CompareMethod(students[j], students[j + 1]) > 0)
                    {
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].Info());
            }
            Console.WriteLine("----------------------");
        }
    }
}    
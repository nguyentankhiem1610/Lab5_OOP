namespace DelegateEventExample
{

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        public Student(int id, string name, double gpa)
        {
            ID = id;
            Name = name;
            GPA = gpa;
        }

        public string Info()
        {
            return ID + " - " + Name + " - GPA: " + GPA;
        }
    }
}
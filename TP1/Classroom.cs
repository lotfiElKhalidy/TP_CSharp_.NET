using System;

class Classroom {
    static void Main(string[] args) {
        int NumberOfStudents = 0;
        Classroom Isima = new Classroom();
        List<Student> StudentList = new List<Student>();

        Console.WriteLine("Welcome !");
        Console.WriteLine("How many students are in this class ?");
        NumberOfStudents = Convert.ToInt32(Console.ReadLine());

        StudentList = Isima.CreateStudents(NumberOfStudents);

        foreach(Student s in StudentList) {
            s.SetStudentInfo();
        }

        Console.WriteLine("Do you want to display the info on the students ? If yes, type 'true'.");
        bool UserResponse = Convert.ToBoolean(Console.ReadLine());

        if (UserResponse) {
            int i = 0;
            foreach (Student s in StudentList)
            {
                i++;
                s.DisplayStudentInfo(i);
            }
        }

    }

    public List<Student> CreateStudents(int NbStudents) {
        List<Student> StudentList = new List<Student>();

        for (int i=0; i<NbStudents; i++) {
            Student s = new Student();
            StudentList.Add(s);
        }

        return StudentList;
    }
}
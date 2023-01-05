using System;
using System.Linq;

class Classroom {
    static void Main(string[] args) {
        int Choice = 0;
        Classroom Isima = new Classroom();

        Console.WriteLine("Welcome !");

        while (true) {
            Console.WriteLine("----------------------- MENU ---------------------");
            Console.WriteLine("What do you want to do ? (Enter a number)");
            Console.WriteLine("        1. Manage students");
            Console.WriteLine("        2. Manage lectures");
        
            Choice = Convert.ToInt32(Console.ReadLine());

            switch (Choice) {
                case 1:
                    Isima.manageStudents();
                    break;
                case 2:
                    Isima.manageLectures();
                    break;
                default:
                    break;
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
     
    public List<Student> SortStudents(string type, List<Student> StudentList) {
        List<string> SortedSurnames = new List<string>();
        List<Student> SortedList = new List<Student>();

        foreach (Student s in StudentList)
        {
            SortedSurnames.Add(s.Surname);
        }
        SortedSurnames.Sort();

        if (type == "ASC")
            SortedList = StudentList.OrderBy(s => SortedSurnames.IndexOf(s.Surname)).ToList();
        else if (type == "DESC")
            SortedList = StudentList.OrderByDescending(s => SortedSurnames.IndexOf(s.Surname)).ToList();

        return SortedList;
    }

    public void manageStudents() {
        int NumberOfStudents = 0;
        List<Student> StudentList = new List<Student>();
        List<Student> SortedList = new List<Student>();

        Console.WriteLine("How many students are in this class ?");
        NumberOfStudents = Convert.ToInt32(Console.ReadLine());

        StudentList = CreateStudents(NumberOfStudents);

        foreach (Student s in StudentList)
        {
            s.SetStudentInfo();
        }

        Console.WriteLine("Do you want to display the info on the students ? If yes, type 'true'.");
        bool UserResponse = Convert.ToBoolean(Console.ReadLine());

        if (UserResponse)
        {
            int i = 0;

            // Sort the students by their surname using LinQ
            Console.WriteLine("How do you want to order the students according to their surnames ? type 'ASC' or 'DESC'.");
            string UserOrderByChoice = Convert.ToString(Console.ReadLine());

            SortedList = SortStudents(UserOrderByChoice, StudentList);

            foreach (Student s in SortedList)
            {
                i++;
                s.DisplayStudentInfo(i);
            }
        }
    }

    public void manageLectures() {
        int NumberOfLectures = 0;

        Console.WriteLine("How many lectures do u want to add ?");
        NumberOfLectures = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("bla bla bla");


        List<Lecture> LectureList = new List<Lecture>();
    }
}
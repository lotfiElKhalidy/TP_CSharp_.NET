using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

class Classroom {
    static void Main(string[] args) {
        int Choice = 0;
        List<Student> StudentList = new List<Student>();
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
                    StudentList = Isima.manageStudents();
                    break;
                case 2:
                    Isima.manageLectures(StudentList);
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

    public List<Lecture> CreateLectures(int NbLectures) {
        List<Lecture> LectureList = new List<Lecture>();

        for (int i = 0; i < NbLectures; i++)
        {
            Lecture l = new Lecture();
            LectureList.Add(l);
        }

        return LectureList;
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

    public void associateStudentsToLectures(int index, List<Lecture> LectureList, List<Student> StudentList) {
        bool exit = true;

        while (exit) {
            Console.WriteLine("The student(s) exist in the database or not ?");
            bool exist = Convert.ToBoolean(Console.ReadLine());

            if (exist == true) {
                Console.WriteLine("Give the name of the student.");
                string studentName = Convert.ToString(Console.ReadLine());

                Student s = StudentList.Find(element => element.Name == studentName);

                LectureList[index - 1].StudentList.Add(s);

                Console.WriteLine("Continue ?");
                exit = Convert.ToBoolean(Console.ReadLine());
            }
            if (exist == false) {
                StudentList = manageStudents();
            }
        }
    }

    public List<Student> manageStudents() {
        int NumberOfStudents = 0;
        List<Student> StudentList = new List<Student>();
        List<Student> SortedList = new List<Student>();

        Console.WriteLine("How many students are in this class ?");
        NumberOfStudents = Convert.ToInt32(Console.ReadLine());

        StudentList = CreateStudents(NumberOfStudents);

        foreach (Student s in StudentList) {
            s.SetStudentInfo();
        }

        Console.WriteLine("Do you want to display the info on the students ? If yes, type 'true'.");
        bool UserResponse = Convert.ToBoolean(Console.ReadLine());

        if (UserResponse) {
            int i = 0;

            Console.WriteLine("How do you want to order the students according to their surnames ? type 'ASC' or 'DESC'.");
            string UserOrderByChoice = Convert.ToString(Console.ReadLine());

            // Sort the students by their surname using LinQ
            SortedList = SortStudents(UserOrderByChoice, StudentList);

            foreach (Student s in SortedList) {
                i++;
                s.DisplayStudentInfo(i);
            }
        }

        return SortedList;
    }

    public void manageLectures(List<Student> StudentList) {
        int NumberOfLectures = 0;

        Console.WriteLine("How many lectures do u want to add ?");
        NumberOfLectures = Convert.ToInt32(Console.ReadLine());

        List<Lecture> LectureList = new List<Lecture>();

        LectureList = CreateLectures(NumberOfLectures);

        foreach (Lecture l in LectureList) {
            l.SetLectureInfo();
        }

        Console.WriteLine("Do you want to add students to these lectures ? If yes, type 'true'.");
        bool UserResponseStudent = Convert.ToBoolean(Console.ReadLine());

        if (UserResponseStudent) {
            Console.WriteLine("In which lecture do u want to add students ? Type a number.");
            int indexLecture = Convert.ToInt32(Console.ReadLine());

            associateStudentsToLectures(indexLecture, LectureList, StudentList);
        }

        Console.WriteLine("Do you want to display the info on the lectures ? If yes, type 'true'.");
        bool UserResponseDisplay = Convert.ToBoolean(Console.ReadLine());

        if (UserResponseDisplay) {
            int i = 0;

            foreach (Lecture s in LectureList) {
                i++;
                s.DisplayLectureInfo(i);
            }
        }
    }
}
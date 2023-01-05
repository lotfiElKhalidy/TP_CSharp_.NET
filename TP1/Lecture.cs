using System;

class Lecture {
    public string Name { get; set; }
    public List<string> Professors { get; set; }
    public List<string> Classrooms { get; set; }
    public List<Student> StudentList { get; set; }

    public void SetLectureInfo() {
        int NbProfessors = 0;
        int NbClassrooms = 0;
        this.Professors = new List<string>();
        this.Classrooms = new List<string>();

        Console.WriteLine("-------- Enter the following informations --------");

        Console.Write("Lecture name : ");
        this.Name = Console.ReadLine();

        Console.Write("How many profesors give this lecture ?");
        NbProfessors = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < NbProfessors; i++) {
            Console.Write("Professor name : ");
            Console.Write(i);
            string ProfName = Convert.ToString(Console.ReadLine());
            this.Professors[i] = ProfName; 
        }

        Console.Write("How many classrooms ensure this lecture ?");
        NbClassrooms = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < NbClassrooms; i++) {
            Console.Write("Classroom name : ");
            this.Classrooms[i] = Convert.ToString(Console.ReadLine());
        }

        Console.WriteLine("--------------------------------------------------");
    }

    public void DisplayLectureInfo(int id) {
        int i = 0;

        Console.WriteLine("------------------ Lecture " + id + " Info ------------------");
        Console.WriteLine("Name : " + this.Name);

        foreach(string professor in this.Professors) {
            Console.WriteLine("Professor :" + professor);
        }

        foreach (string classroom in this.Classrooms) {
            Console.WriteLine("Classroom :" + classroom);
        }

        foreach (Student s in this.StudentList) {
            i++;
            s.DisplayStudentInfo(i);
        }

        Console.WriteLine("--------------------------------------------------");
    }
}
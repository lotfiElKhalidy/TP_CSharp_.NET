using System;

class Student {
    public string Name { get; set; }
    public string Surname { get; set; }

    public int Promo;
    public string BirthDate;

    public void SetStudentInfo() {
        Console.WriteLine("-------- Enter the following informations --------");

        Console.Write("Student name : ");
        this.Name = Console.ReadLine();
        
        Console.Write("Student surname : ");
        this.Surname = Console.ReadLine();
        
        Console.Write("Promo : ");
        this.Promo = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Student date of birth (DD-MM-YYYY) : ");
        this.BirthDate = Console.ReadLine();

        Console.WriteLine("--------------------------------------------------");
    }

    public void DisplayStudentInfo(int id) {
        Console.WriteLine("------------------ Student " + id + " Info ------------------");
        Console.WriteLine("Name : " + this.Name);
        Console.WriteLine("Surname : " + this.Surname);
        Console.WriteLine("Promo : " + this.Promo);
        Console.WriteLine("Birth date (DD-MM-YYYY) : " + this.BirthDate);
        Console.WriteLine("--------------------------------------------------");
    }
}
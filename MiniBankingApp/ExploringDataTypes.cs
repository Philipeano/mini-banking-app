using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    internal class ExploringDataTypes
    {
        public void Demo()
        {
            /*
             * Enrol a 100-level student in Computer Science department.
             * Create another student entry that duplicates the previous one but uses a different name and matric number.
             * Engage a lecturer to teach Software Engineering with course code of COM105, and a weight of 4 units.
             */

            // Student creation by instantiation
            var sampleStudent = new Student("Paul", "Kenneth")
            {
                MatricNumber = 100001,
                Level = UndergraduateLevel.One,
                Department = "Computer Science"
            };

            // Student creation by duplication - copying and modifying
            var secondStudent = sampleStudent with { FirstName = "Alao", LastName = "Adewuyi", MatricNumber = 100002 };

            // Lecturer creation by instantiation
            var sampleLecturer = new Lecturer("Favour", "Korede", DateTime.Now)
            {
                StaffNumber = 5001,
                BasicSalary = 250000D,
                AssignedCourse = new UniversityCourse { Code = "COM105", Title = "Software Engineering", Units = 4 }
            };

            // Print the student and lecturer records 
            Console.WriteLine($"Here is the entry for student 1: \n{sampleStudent}");
            Console.WriteLine($"Here is the entry for student 2: \n{secondStudent}");
            Console.WriteLine($"Here is the entry for lecturer: \n{sampleLecturer}");
        }
    }



    // Enumerations

    public enum UndergraduateLevel
    {
        One = 100,
        Two = 200,
        Three = 300,  
        Four = 400,
        Five = 500,
        Six = 600
    } 

    // Structure Types

    public struct UniversityCourse
    {
        public string Code { get; set; }

        public string Title { get; set; }

        public int Units { get; set; }
    }

    
    // Records

    public record Employee(string FirstName, string LastName, DateTime DateHired)
    {
        public int StaffNumber { get; set; }

        public double BasicSalary { get; set; }
    }


    public record Student(string FirstName, string LastName)
    {
        public int MatricNumber { get; set; }

        public UndergraduateLevel Level { get; set; }

        public string Department { get; set; }

    }

    // Define a record type that derives from Employee and includes a 'Course' property

    public record Lecturer : Employee
    {
        public Lecturer(string FirstName, string LastName, DateTime DateHired) : base(FirstName, LastName, DateHired)
        {

        }

        public UniversityCourse AssignedCourse { get; set; } 
    }

}

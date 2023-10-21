using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            // Create a number of car records
            var car1 = new CarWithPriceInfo("Innoson", "IVM500", 1200000);
            var car2 = new CarWithPriceInfo("Toyota", "Camry", 2500000);
            var car3 = new CarWithPriceInfo("Honda", "Accord", 2200000);
            var car4 = new CarWithPriceInfo("Nissan", "Altima", 1600000);
            var car5 = new CarWithPriceInfo("Nord", "A4", 1300000);

            // Create an array and populate it with the car records
            CarWithPriceInfo[] myCars = new CarWithPriceInfo[5] { car1, car2, car3, car4, car5 }; // Explicit declaration

            // Fetch a tuple that contains the models of the least and most expensive cars
            var carsTuple = GetLeastAndMostCostlyModels(myCars);

            // Print the returned tuple 
            Console.WriteLine($"Least expensive car model is {carsTuple.Item1} \n Most expensive model is {carsTuple.Item2}");
        }


        // Tuple
        // Given a number of cars and their prices, return a tuple containing the models of the least and most expensive cars. 
        public (string, string) GetLeastAndMostCostlyModels(CarWithPriceInfo[] cars)
        {
            (string least, string most) result = ("", "");

            // Figure out least and most expensive cars

            CarWithPriceInfo tempLeastCostlyCar = cars[0];
            CarWithPriceInfo tempMostCostlyCar = cars[0];

            foreach (var car in cars)
            {
                // Check for least expensive car and keep track of it
                if (car.price < tempLeastCostlyCar.price)
                {
                    tempLeastCostlyCar = car;
                }

                // Check for most expensive car and keep track of it
                if (car.price > tempMostCostlyCar.price)
                {
                    tempMostCostlyCar = car;
                }
            }

            result.least = tempLeastCostlyCar.model;
            result.most = tempMostCostlyCar.model;
            return result;
            // ("Camry", "IVM500")
        }



        public void ExploreArrays()
        {
            // Arrays 

            // Declare arrays and initialize them
            string[] names = new string[5] { "Paul", "Kenneth", "Ifeanyi", "Alao", "Korede" };
            double[] prices = new double[] { 7000, 2000, 1300 };
            UniversityCourse[] myCoursess = new UniversityCourse[]
            {
                new UniversityCourse(){Code = "MTH101", Title = "Algebra", Units = 2 },
                new UniversityCourse(){Code = "GNS105", Title = "Use of English", Units = 3 },
                new UniversityCourse(){Code = "COM104", Title = "Basic Programming", Units = 4 },
            };
        }


        public void ExploreKeyValuePairs()
        {
            KeyValuePair<string, string> Contact1 = new KeyValuePair<string, string>("08012345678", "Philip");
            KeyValuePair<string, string> Contact2 = new KeyValuePair<string, string>("08012345679", "Paul");

            KeyValuePair<char, string> Gender1 = new KeyValuePair<char, string>('M', "Male");
            KeyValuePair<char, string> Gender2 = new KeyValuePair<char, string>('F', "Female");

            KeyValuePair<int, string> Student1 = new KeyValuePair<int, string>(1000101, "Alao Kenneth");
            KeyValuePair<int, string> Student2 = new KeyValuePair<int, string>(1000105, "Paul Ifeanyi");


            // Array of KVPs
            var myStudents = new KeyValuePair<int, string>[2] {Student1, Student2 }; 
        }


        public void ExploreTryCatch()
        {
            // With a Try-Catch block... handles exceptions gracefully
            try
            {   // Prompt the user for 2 values, then displays the quotient of the numbers
                Console.WriteLine("Enter first number");
                int firstNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second number");
                int secondNumber = int.Parse(Console.ReadLine());

                // Without Try-Catch... prone to a run-time error
                var quotient = firstNumber / secondNumber;
                Console.WriteLine($"The quotient is: {quotient}");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No input provided! Kindly enter a numeric value.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Kindly enter a numeric value.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error occurred due to division by zero. Please try again.");
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, an error occurred. Please try again.");
            }
            finally // Always run the statements in this block, regardless of what happened above
            {
                Console.WriteLine("Operation completed. Thank you.");
            }
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

    public record CarWithPriceInfo(string manufacturer, string model, double price);

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    internal class ExploringSerialization
    {
        public void Demo()
        {
            // PART 1 - SERIALIZATION
            // To serialize means to convert .NET objects or collections into a JSON string

            // Instantiate the Worker class 
            Worker firstWorker = new Worker
            {
                StaffNumber = Guid.NewGuid(),
                FirstName = "Donald",
                LastName = "Trump",
                DateHired = new DateTime(2020, 7, 5),
                BasicSalary = 200000000,
                IsFullTimeStaff = true,
                PhoneNumber = 08021234567
            };

            Worker secondWorker = new Worker
            {
                StaffNumber = Guid.NewGuid(),
                FirstName = "Joe",
                LastName = "Biden",
                DateHired = new DateTime(2022, 2, 15),
                BasicSalary = 220000000,
                IsFullTimeStaff = false,
                PhoneNumber = 08034634567
            };

            // Serialize the object without customization (using default options)
            string firstWorkerJson1 = JsonSerializer.Serialize(firstWorker);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(firstWorkerJson1);

            // Define options to customize how we want the object serialized/deserialized
            var options = new JsonSerializerOptions()
            {
                 PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                 WriteIndented = true
            };

            // Serialize the object with customization (use preferred options)
            string firstWorkerJson2 = JsonSerializer.Serialize(firstWorker, options);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(firstWorkerJson2);
            Console.WriteLine();
            Console.WriteLine();

            // Store both instances in an array
            var workers = new Worker[] { firstWorker, secondWorker };

            // Serialize the array with customization (use preferred options)
            string workersJson = JsonSerializer.Serialize(workers, options);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(workersJson);

            // Save the JSON content in a file
            var storageDirectory = "C:\\CSharpDemo\\JsonFiles";
            var fileName1 = $"{storageDirectory}\\FirstWorkerDemo.json";
            var fileName2 = $"{storageDirectory}\\AllWorkersDemo.json";
            File.WriteAllText(fileName1, firstWorkerJson2);
            File.WriteAllText(fileName2, workersJson);


            // PART 2 - DESERIALIZATION
            // To deserialize means to extract .NET objects or collections from a given JSON string

            // Define the JSON string to deserialize
            var jsonString1 = @"{
                                  ""staffNumber"": ""8b2e0148-2df6-4ead-9731-4b81a322a9e7"",
                                  ""firstName"": ""Barrack"",
                                  ""lastName"": ""Obama"",
                                  ""dateHired"": ""2018-03-17T00:00:00"",
                                  ""basicSalary"": 150000000,
                                  ""isFullTimeStaff"": true,
                                  ""phoneNumber"": 8071234743
                                }";

            // Deserialize the string (use preferred options)
            Worker? deserializedWorker = JsonSerializer.Deserialize<Worker>(jsonString1, options);

            // Display some properties of the resulting (deserialized) object
            Console.WriteLine($"Staff Number is {deserializedWorker?.StaffNumber}");
            Console.WriteLine($"Full Name is {deserializedWorker?.FirstName} {deserializedWorker?.LastName}");
            Console.WriteLine($"Date Hired is {deserializedWorker?.DateHired}");
        }

    }



    // Define a Worker class with a few essential properties of a worker

    public class Worker
    {
        public Guid StaffNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateHired { get; set; }

        public Double BasicSalary { get; set; }

        public bool IsFullTimeStaff { get; set; }

        public long PhoneNumber { get; set; }
    }

}

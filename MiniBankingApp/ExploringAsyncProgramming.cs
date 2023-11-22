using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    internal class ExploringAsyncProgramming
    {
        public async Task Demo() 
        {
            var sumOfFirst20Numbers = await AddNumbersAsync();
            Console.WriteLine($"The sum of numbers 1 to 20 is \t {sumOfFirst20Numbers}");

            await ReadTextFileAsync();
            await GetWebContentAsync();

            await GetDataFromApiAsync();
        }

        // A method that uses a loop to add numbers 1 to 20. In each iteration, it also prints the current value of the counter, then pauses for 2 seconds
        public async Task<int> AddNumbersAsync()
        {
            int sum = 0;
            for (int i = 1; i <= 20; i++)
            {
                sum += i; 
                Console.WriteLine(i);
                await Task.Delay(2000);
            }
            return sum;
        }

        // A method that reads the contents of a text file, then returns a count of the characters it contains. (Hint: use a StreamReader object wrapped in a using block).
        public async Task ReadTextFileAsync()
        {
            // Create a character array to serve as a buffer
            char[] buffer;

            using (var reader = new StreamReader("C:\\CSharpDemo\\TextFiles\\DummyText2.txt"))
            {
                // Determine number of characters in the file
                var characterCount = reader.BaseStream.Length;

                // Initialize the buffer to have the expected capacity
                buffer = new char[characterCount];

                // Read the characters as bytes asunchronously into the buffer
                await reader.ReadAsync(buffer, 0, (int)characterCount);
            }

            Console.WriteLine("Number of characters read from text file is " + buffer.Length);
        }


        // A method that makes an HTTP request to https://thebulb.africa/community, retrieves its textual content, and displays it on the console.
        public async Task GetWebContentAsync()
        {
            // Create a disposable instance of HTTPClient 
            using (HttpClient client = new HttpClient())
            {
                var webAddress = "https://thebulb.africa/community";

                Console.WriteLine($"Making a GET request to: {webAddress}. Please wait...");
               
                // Send an asynchronous GET request to the given address
                var response = await client.GetAsync(webAddress);

                Console.WriteLine($"The web request returned a status code of: {response.StatusCode}.");

                // Check if the request was successful i.e. if the status code indicates success 
                if (response.IsSuccessStatusCode)
                {
                    // Retrieve the text content returned from the server
                    var textContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Here is the textual content returned by the server:\n");
                    Console.WriteLine(textContent);
                }
                else
                {
                    Console.WriteLine("No content to display. The request was not successful");
                }
            }
        }

        // Load employees data from an API using the address https://dummy.restapiexample.com/api/v1/employees
        public async Task GetDataFromApiAsync()
        {
            // Create a disposable instance of HTTPClient 
            using (HttpClient client = new HttpClient())
            {
                var webAddress = "https://dummy.restapiexample.com/api/v1/employees";

                Console.WriteLine($"Making a GET request to: {webAddress}. Please wait...");

                // Send an asynchronous GET request to the given address
                var response = await client.GetAsync(webAddress);

                Console.WriteLine($"The web request returned a status code of: {response.StatusCode}.");

                // Check if the request was successful i.e. if the status code indicates success 
                if (response.IsSuccessStatusCode)
                {
                    // Retrieve the JSON content returned from the server
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Here is the JSON content returned by the server:\n");
                    Console.WriteLine(jsonContent);

                    // Deserialiaze the JSON content into C# objects we can manipulate
                    JsonSerializerOptions options = new JsonSerializerOptions()
                    {
                        WriteIndented = true,
                        PropertyNameCaseInsensitive = true,
                    };

                    var deserializedApiResponse = JsonSerializer.Deserialize<EmployeeApiResponse>(jsonContent, options);

                    // Count how many employees were returned
                    var employeeCount = deserializedApiResponse?.Data?.Length;
                    Console.WriteLine("Number of employees from API: " + employeeCount);
                }
                else
                {
                    Console.WriteLine("No content to display. The request was not successful");
                }
            }
        }

        public record EmployeeInfo(int Id, string Employee_Name, double Employee_Salary, int Employee_Age, string Profile_Image);

        public record EmployeeApiResponse(string Status, EmployeeInfo[] Data, string Message);
    }
}


/*
 * An asynchronous method that uses a loop to add numbers 1 to 20. In each iteration, it also prints the current value of the counter, then pauses for 2 seconds. 
 * An asynchronous method that reads the contents of a text file, then returns a count of the characters it contains. (Hint: use a StreamReader object wrapped in a using block).
 * An asynchronous method that makes an HTTP request to https://thebulb.africa/community, retrieves its textual content, and displays it on the console.
 * An asynchronous method that makes an HTTP request to https://dummy.restapiexample.com/api/v1/employees, retrieves the JSON data, and counts the number of employee records returned.
 */
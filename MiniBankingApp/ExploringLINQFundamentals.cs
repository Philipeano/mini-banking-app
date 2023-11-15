using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    internal class ExploringLINQFundamentals
    {
        public void Demo()
        {
            // First, create an array to serve as our data source
            var states = new NigerianState[16]             
            { 
                new NigerianState("Zamfara", "Gusau", GeopoliticalZone.NorthWest, 5317793, 14),
                new NigerianState("Ogun", "Abeokuta", GeopoliticalZone.SouthWest, 5945275, 20),
                new NigerianState("Kwara", "Ilorin", GeopoliticalZone.NorthCentral, 3259613, 16),
                new NigerianState("Oyo", "Ibadan", GeopoliticalZone.SouthWest, 7512855, 33),
                new NigerianState("Bayelsa", "Yenagoa", GeopoliticalZone.SouthSouth, 2394725, 8),
                new NigerianState("Imo", "Owerri", GeopoliticalZone.SouthEast, 5167722, 27),
                new NigerianState("Kano", "Kano", GeopoliticalZone.NorthWest, 14253549, 44),
                new NigerianState("Kaduna", "Kaduna", GeopoliticalZone.NorthWest, 8324285, 23),
                new NigerianState("Katsina", "Katsina", GeopoliticalZone.NorthWest, 9300382, 34),
                new NigerianState("Benue", "Makurdi", GeopoliticalZone.NorthCentral, 5787706, 22),
                new NigerianState("Rivers", "Port Harcourt", GeopoliticalZone.SouthSouth, 7034973 , 23),
                new NigerianState("Kogi", "Lokoja", GeopoliticalZone.NorthCentral, 4153734, 21),
                new NigerianState("Enugu", "Enugu", GeopoliticalZone.SouthEast, 4396098, 17),
                new NigerianState("Lagos", "Ikeja", GeopoliticalZone.SouthWest, 12772884, 20),
                new NigerianState("Adamawa", "Yola", GeopoliticalZone.NorthEast, 4536948, 21),
                new NigerianState("Borno", "Maiduguri", GeopoliticalZone.NorthEast, 5751590, 27),
            };

            /*

            // Problem 1 - Fetch all states arranged in ascending order of state name

            // Second, define the query and store it in a variable

            // Query expression syntax
            IEnumerable<NigerianState> allStatesQuery = from state in states
                                                        orderby state.StateName ascending
                                                        select state;
            // Method-based syntax
            IEnumerable<NigerianState> allStatesQuery2 = states.OrderBy(s => s.StateName)
                                                               .Select(s => s);
            // Third, iterate over the query variable to execute the query
            Console.WriteLine("QUERY RESULTS USING EXPRESSION SYNTAX\n");

            foreach (var state in allStatesQuery)
            {
                Console.WriteLine(state.StateName + "\t\t" + state.Capital);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("QUERY RESULTS USING METHOD-BASED SYNTAX\n");
            Console.WriteLine();

            foreach (var state in allStatesQuery2)
            {
                Console.WriteLine(state.StateName + "\t\t" + state.Capital);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            */

            // Problem 2 - Fetch all states that have 20 or more LGAs, and arrange them in ascending order of NumberOfLGAs
            
            // Expression syntax
            IEnumerable<NigerianState> allStatesWith20PlusLGAsQuery = from state in states
                                                                      where state.NumberOfLGAs >= 20
                                                                      orderby state.NumberOfLGAs ascending, state.StateName ascending                                                                      
                                                                      select state;


            // Method-based syntax
            IEnumerable<NigerianState> allStatesWith20PlusLGAsQuery2 = states.Where(s => s.NumberOfLGAs >= 20)
                                                                             .OrderBy(s => s.NumberOfLGAs)
                                                                             .ThenBy(s => s.StateName)
                                                                             .Select(s => s);

            Console.WriteLine("QUERY RESULTS USING EXPRESSION SYNTAX\n");

            foreach (var state in allStatesWith20PlusLGAsQuery)
            {
                Console.WriteLine(state.StateName + "\t\t" + state.Capital + "\t\t\t" + state.NumberOfLGAs);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("QUERY RESULTS USING METHOD-BASED SYNTAX\n");
            Console.WriteLine();

            foreach (var state in allStatesWith20PlusLGAsQuery2)
            {
                Console.WriteLine(state.StateName + "\t\t" + state.Capital + "\t\t\t" + state.NumberOfLGAs);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    /* 
     * SCENARIO 1
     * Define a NigerianState class/record with properties State, Capital, Zone, EstimatedPopulation, NumberOfLGAs 
     * Create a collection of NigerianState objects, populated with some sample data
     * Using LINQ, perform the following queries:
        * Fetch all states arranged in ascending order of state name
        * Fetch all states that have 20 or more LGAs, and arrange them in ascending order of NumberOfLGAs
        * Fetch all states grouped on the basis of zone, sorted in desccending order of NumberOfLGAs    
     */

    public record NigerianState (string StateName, string Capital, GeopoliticalZone Zone, int EstimatedPopulation, int NumberOfLGAs);

    public enum GeopoliticalZone
    {
        NorthWest = 1,
        NorthCentral,
        NorthEast,
        SouthWest,
        SouthSouth,
        SouthEast,
    }



}

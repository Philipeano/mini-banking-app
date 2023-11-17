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

            // Define another array to store LGAs
            var LGAs = new StateLGA[]
            {
                new StateLGA("Ikeja", "Lagos", 15),
                new StateLGA("Alimosho", "Lagos", 30),
                new StateLGA("Oshodi-Isolo", "Lagos", 17),
                new StateLGA("Agege", "Lagos", 23),
                new StateLGA("Ifako-Ijaiye", "Lagos", 13),
                new StateLGA("Yenagoa", "Bayelsa", 10),
                new StateLGA("Brass", "Bayelsa", 8),
                new StateLGA("Ekeremor", "Bayelsa", 11),
                new StateLGA("Nembe", "Bayelsa", 12),
                new StateLGA("Aboh-Mbaise", "Imo", 14),
                new StateLGA("Orlu", "Imo", 16),
                new StateLGA("Owerri", "Imo", 20),
                new StateLGA("Mbaano", "Imo", 14),
                new StateLGA("Abeokuta", "Ogun", 30),
                new StateLGA("Sagamu", "Ogun", 20),
                new StateLGA("Remo", "Ogun", 20),
                new StateLGA("Ifo", "Ogun", 25),
                new StateLGA("Offa", "Kwara", 10),
                new StateLGA("Ilorin", "Kwara", 28),
                new StateLGA("Dekina", "Kogi", 18),
                new StateLGA("Lokoja", "Kogi", 23),
                new StateLGA("Idah", "Kogi", 12),
            };
           

            // Problem 1 - Fetch all states arranged in ascending order of state name

            // Query expression syntax
            IEnumerable<NigerianState> allStatesQuery = from state in states
                                                        orderby state.StateName ascending
                                                        select state;
            // Method-based syntax
            IEnumerable<NigerianState> allStatesQuery2 = states.OrderBy(s => s.StateName)
                                                               .Select(s => s);

            Console.WriteLine("QUERY RESULTS USING EXPRESSION SYNTAX\n");
            Console.WriteLine();

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
            Console.WriteLine();

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

            // Problem 3 - Fetch all states grouped on the basis of zone, sorted in descending order of NumberOfLGAs    

            // Expression syntax
            IEnumerable<IGrouping<GeopoliticalZone, NigerianState>> allStatesGroupedByZoneQuery = from state in states
                                                                                                  orderby state.NumberOfLGAs descending
                                                                                                  group state by state.Zone;
            // Method-based syntax
            IEnumerable<IGrouping<GeopoliticalZone, NigerianState>> allStatesGroupedByZoneQuery2 = states.OrderByDescending(s => s.NumberOfLGAs)
                                                                                                         .GroupBy(s => s.Zone);

            Console.WriteLine("QUERY RESULTS USING EXPRESSION SYNTAX\n");
            Console.WriteLine();

            foreach (var stateGroup in allStatesGroupedByZoneQuery)
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine(stateGroup.Key.ToString().ToUpper());
                Console.WriteLine("---------------------------------------------------------------------------");

                foreach (var state in stateGroup)
                {
                    Console.WriteLine(state.StateName + "\t\t" + state.Capital + "\t\t\t" + state.NumberOfLGAs);
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("QUERY RESULTS USING METHOD-BASED SYNTAX\n");
            Console.WriteLine();

            foreach (var stateGroup in allStatesGroupedByZoneQuery2)
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine(stateGroup.Key.ToString().ToUpper());
                Console.WriteLine("---------------------------------------------------------------------------");

                foreach (var state in stateGroup)
                {
                    Console.WriteLine(state.StateName + "\t\t" + state.Capital + "\t\t\t" + state.NumberOfLGAs);
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            // Problem 4 - Fetch all LGA names, along with their state and zone names, sorted by zone name, state name, then by LGA name

            // Expression syntax
            var allLGAsQuery = from LGA in LGAs
                               join state in states on LGA.State equals state.StateName
                               orderby state.Zone.ToString(), state.StateName, LGA.LgaName
                               select new
                               {
                                   LgaName = LGA.LgaName,
                                   StateName = state.StateName,
                                   ZoneName = state.Zone.ToString()
                               };

            // Method-based syntax
            var allLGAsQuery2 = LGAs.Join(states, lga => lga.State, state => state.StateName, (lga, state) => new
                                        {
                                            LgaName = lga.LgaName,
                                            StateName = state.StateName,
                                            ZoneName = state.Zone.ToString()
                                        })
                                    .OrderBy(x => x.ZoneName)
                                    .ThenBy(x => x.StateName)
                                    .ThenBy(x => x.LgaName);

            Console.WriteLine("QUERY RESULTS USING EXPRESSION SYNTAX\n");
            Console.WriteLine();

            foreach (var lgaInfo in allLGAsQuery)
            {
                {
                    Console.WriteLine(lgaInfo.ZoneName + "\t\t" + lgaInfo.StateName + "\t\t" + lgaInfo.LgaName);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("QUERY RESULTS USING METHOD-BASED SYNTAX\n");
            Console.WriteLine();

            foreach (var lgaInfo in allLGAsQuery2)
            {
                {
                    Console.WriteLine(lgaInfo.ZoneName + "\t\t" + lgaInfo.StateName + "\t\t" + lgaInfo.LgaName);
                    Console.WriteLine();
                }
            }
          
            // Problem 5 - Fetch LGAs in the SouthWest and SouthEast zones only 

            var southWestAndSouthEastLGAsQuery =   from LGA in LGAs
                                                   join state in states on LGA.State equals state.StateName
                                                   where state.Zone == GeopoliticalZone.SouthWest || state.Zone == GeopoliticalZone.SouthEast
                                                   orderby state.Zone.ToString(), state.StateName, LGA.LgaName
                                                   select new
                                                   {
                                                       LgaName = LGA.LgaName,
                                                       StateName = state.StateName,
                                                       ZoneName = state.Zone.ToString()
                                                   };

            Console.WriteLine("QUERY RESULTS USING EXPRESSION SYNTAX\n");
            Console.WriteLine();

            foreach (var lgaInfo in southWestAndSouthEastLGAsQuery)
            {
                {
                    Console.WriteLine(lgaInfo.ZoneName + "\t\t" + lgaInfo.StateName + "\t\t" + lgaInfo.LgaName);
                    Console.WriteLine();
                }
            }
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
        * Fetch all LGA names, along with their state and zone names, sorted by zone name, state name, then by LGA name
        * Fetch LGAs in the SouthWest and SouthEast zones only 
     */

    public record NigerianState (string StateName, string Capital, GeopoliticalZone Zone, int EstimatedPopulation, int NumberOfLGAs);

    public record StateLGA(string LgaName, string State, int NumberOfTowns);

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

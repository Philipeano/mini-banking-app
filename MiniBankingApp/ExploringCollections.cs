using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    internal class ExploringCollections
    {

        public void ExploreArrays()
        {
            // ARRAY
            /* Strongly typed
             * Fixed-length collection; cannot add or remove items after creation
             * Elements can be accessed by indices         
             */

            var myNumbers = new int[5] { 12, 80, 34, 0, 7 };
            var myFriends = new string[] { "Paul", "Alao", "Ifeanyi" };
            myNumbers[3] = 15; // Assigns 15 to element at index 3, replacing 0
            Console.WriteLine(myNumbers[1]); // Prints 80 to the screen
        }

        public void ExploreArrayLists()
        {
            // ARRAYLIST
            /* Loosely or dynamically typed
             * Variable-length collection; can add and remove items after creation.
             * Elements can be accessed by indices         
             */

            var myNumbers = new ArrayList();
            myNumbers.Add(12);
            myNumbers.Add(92);
            myNumbers.Add(7);
            myNumbers.Add("Paul");
            myNumbers.Add(true);
            Console.WriteLine(myNumbers[1]); // Prints 92 to the screen
        }

        public void ExploreLists()
        {
            // LIST
            /* Generic and strongly typed
             * Variable-length collection; can add and remove items after creation.
             * Elements can be accessed by indices 
             * Can be searched; has in-built aggregate functions
             */

            var myNumbers = new List<int>() {3, 0, 106, 91, 56 }; // The constructor takes in a type parameter of int within the angle brackets
            myNumbers.Add(12);
            myNumbers.Add(10);
            myNumbers.Remove(0);
            myNumbers.RemoveAt(4);
        }


        public void ExploreDictionaries() {

            // DICTIONARY
            /* Generic and strongly typed
             * Stores items as key-value pairs
             * Variable-length collection; can add and remove items after creation.
             * Elements can be accessed by indices and by keys
             */

            var myContacts = new Dictionary<long,string>(); // The constructor takes in two type parameters of long and string within the angle brackets
            myContacts.Add(08031234567, "Paul");
            myContacts.Add(08031234568, "Ifeanyi");
            myContacts.Remove(08031234567);
        }


        public void ExploreStacksAndQueues()
        {
            // STACK
            /* Generic, strongly typed
             * Allows last-in-first-out item retrieval (LIFO)
             * Variable-length collection
             * Elements can be accessed by indices         
             * Provides Push and Pop methods for adding and retrieving
             */

            var myBookTitlesStack = new Stack<string>();
            myBookTitlesStack.Push("Modern Biology");
            myBookTitlesStack.Push("New School Chemistry");
            myBookTitlesStack.Push("Engineering Mathematics");
            myBookTitlesStack.Push("Principles of Physics");
            myBookTitlesStack.Push("Oxford English Dictionary");

            myBookTitlesStack.Peek(); // Retrieve the most recently added item without removing it from the collection
            myBookTitlesStack.Pop(); // Retrieve the most recently added item and remove it from the collection


            // QUEUE
            /* Generic, strongly typed
             * Allows first-in-first-out item retrieval (FIFO)
             * Variable-length collection
             * Elements can be accessed by indices 
             * Provides Enqueue and Dequeue methods for adding and retrieving
             */
            var namesOfWaitingCustomers = new Queue<string>();
            namesOfWaitingCustomers.Enqueue("Paul");
            namesOfWaitingCustomers.Enqueue("Alao");
            namesOfWaitingCustomers.Enqueue("Ifeanyi");
            namesOfWaitingCustomers.Enqueue("Kenneth");

            namesOfWaitingCustomers.Peek(); // Retrieve the item at the front of the queue without removing it from the collection
            namesOfWaitingCustomers.Dequeue(); // Retrieve the item at the front of the queue and remove it from the collection
        }


        public void ExploreHashSets()
        {
            // HASHSET
            /* Generic, strongly typed
             * Contains only unique items; no duplicates allowed
             * Variable-length collection
             * Elements can be accessed by indices         
             */

            var emberMonths = new HashSet<string>() { "September", "October" };
            emberMonths.Add("November");
            emberMonths.Add("December");
        }
    }
}

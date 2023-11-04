using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    internal class ExploringGenerics
    {
        public void Demo()
        {
            // Create instances for AnyPhone<T>
            var phone1 = new AnyPhone<ITelephone>();
            var phone2 = new AnyPhone<IWiredPhone>();
            var phone3 = new AnyPhone<MobilePhone>();
            var phone4 = new AnyPhone<SmartPhone>();
            var phone5 = new AnyPhone<IWirelessPhone>();

            // Create instances for AnySmartPhone<T>
            var smartPhone1 = new AnySmartPhone<ISmartPhone>();
            var smartPhone2 = new AnySmartPhone<SmartPhone>();
            var smartPhone3 = new AnySmartPhone<SamsungPhone>();

            // Create instances for AnySmartPhone2<T>
            var smartPhone4 = new AnySmartPhone2<SmartPhone>();
            var smartPhone5 = new AnySmartPhone2<SamsungPhone>();

            // Create instances for AnyShape<T>
            var shape1 = new AnyShape<Shape>();
            var shape2 = new AnyShape<Rectangle>();
            var shape3 = new AnyShape<Circle>();

            // Create instances of AnyReferenceType<T>
            var refObject1 = new AnyReferenceType<string>();
            var refObject2 = new AnyReferenceType<Stack>();
            var refObject3 = new AnyReferenceType<Queue>();
            var refObject4 = new AnyReferenceType<Enum>();
            var refObject5 = new AnyReferenceType<BankAccount>();

            // Create instances of AnyValueType<T>
            var valObject1 = new AnyValueType<int>();
            var valObject2 = new AnyValueType<bool>();
            var valObject3 = new AnyValueType<long>();


            // SCENARIO 1 - Instantiate RecordKeepingService<TKey,TValue> for the lecturer's use case
            var attendanceTracker = new RecordKeepingService<string,bool>();
            
            // Insert and store entries
            attendanceTracker.AcceptItem("TBA20230001", true);
            attendanceTracker.AcceptItem("TBA20230002", false);
            attendanceTracker.AcceptItem("TBA20230003", true);

            var allStudents = attendanceTracker.Items;          // Retrieves all entries 
            var studentCount = attendanceTracker.CountItems(); // Counts the entries
            var studentSearchResult = attendanceTracker.FetchItem("TBA20230002"); // Returns a matching entry or nothing


            // SCENARIO 2 - Instantiate RecordKeepingService<TKey,TValue> for the receptionist's use case
            var visitTracker = new RecordKeepingService<DateTime, string>();

            // Insert and store entries
            visitTracker.AcceptItem(DateTime.Now, "Kachi");
            visitTracker.AcceptItem(DateTime.Now.AddMinutes(5) , "Paul");
            visitTracker.AcceptItem(DateTime.Now.AddHours(1), "Ifeanyi");

            var allVisitors = visitTracker.Items;          // Retrieves all entries 
            var visitorCount = visitTracker.CountItems(); // Counts the entries
            var visitorSearchResult = visitTracker.FetchItem(new DateTime(2023, 11, 3, 12, 15, 0)); // Returns a matching entry or nothing


            // SCENARIO 3 -  Instantiate RecordKeepingService<TKey,TValue> for the phone dealer's use case
            var inventoryTracker = new RecordKeepingService<string, IWirelessPhone>();

            // Insert and store entries
            inventoryTracker.AcceptItem("SMA33-12345-CE", new SamsungPhone());
            inventoryTracker.AcceptItem("TEC-815661-X3", new TecnoPhone());
            inventoryTracker.AcceptItem("INF-091919-1772", new InfinixPhone());

            var allProducts = inventoryTracker.Items;          // Retrieves all entries 
            var productCount = inventoryTracker.CountItems(); // Counts the entries
            var productSearchResult = inventoryTracker.FetchItem("TEC-815661-X3"); // Returns a matching entry or nothing
        }
    }


    // Define a generic class that can only work with ITelephone and its descendants

    public class AnyPhone<T> where T : ITelephone
    {
    }


    // Define a generic class that can only work with ISmartphone and its descendants
    public class AnySmartPhone<T> where T : ISmartPhone
    {
    }

    // Define a generic class that can only work with Smartphone and its derived classes
    public class AnySmartPhone2<T> where T : SmartPhone
    { 
    }

    // Define a generic class that can only work with Shape and its descendants
    public class AnyShape<T> where T : Shape
    {

    }

    // Define a generic class that can only work with reference types
    public class AnyReferenceType<T> where T : class
    {

    }

    // Define a generic class that can only work with value types
    public class AnyValueType<T> where T : struct
    {

    }


    /*
     * You are part of a team developing a multipurpose recordkeeping application. 
     * At minimum, the app MUST help users accept, store, fetch and count their items of interest. Each item must be stored as a key/value pair.
     * Propose a contract and implementation that is flexible enough to handle the following scenarios:
        - A college lecturer needs to keep track of class attendance. Each record contains a matric number along with a true (present) or false (absent) value.    
        - A receptionist needs to maintain a register of visitors to the organization. Each record contains a timestamp (arrival time) along with the visitor’s name. 
        - A mobile phone dealer needs to keep an inventory of phones in stock. Each record contains a unique serial number and the phone itself.   
        - Staff No, Employee object or Employee name        
     */


    // Define an appropriate abstraction/interface
    public interface IRecordKeepingService<TKey, TValue> where TKey : notnull
    {
        public Dictionary<TKey, TValue> Items { get; }

        public void AcceptItem(TKey itemKey, TValue itemValue);

        public KeyValuePair<TKey, TValue>? FetchItem(TKey itemKey);

        public int CountItems();
    }

    // Define an implementation
    public class RecordKeepingService<TKey, TValue> : IRecordKeepingService<TKey, TValue> where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _items;

        public RecordKeepingService()
        {
            _items = new Dictionary<TKey, TValue>() { };
        }

        public Dictionary<TKey, TValue> Items 
        { 
            get => _items; 
        }

        public void AcceptItem(TKey itemKey, TValue itemValue)
        {
            _items.Add(itemKey, itemValue);
        }

        public int CountItems()
        {
            return _items.Count;
        }

        public KeyValuePair<TKey, TValue>? FetchItem(TKey itemKey)
        {
            if (_items.ContainsKey(itemKey))
                return _items.First(x => x.Key.ToString() == itemKey.ToString());

            return null;
        }
    }

}

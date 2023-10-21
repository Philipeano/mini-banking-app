using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    internal class ExploringInterfaces
    {
        // Attempt to create an instance of IVehicle
        IVehicle sampleVehicle = new Car();

        Car sampleVehicle2 = new Car();

    }



    // Define an interface for motor vehicles
    public interface IVehicle
    {
        // List out the expected behaviours/methods without implementing them
        public void Start();

        public void Stop();
        
        public void Move();
        
        public void ChangeSpeed();

        // List out the expected properties without assigning them
        public int NumberOfWheels { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int NumberOfSeats { get; set; }
    }

    // Define a class that implements the IVehicle interface
    public class Car : IVehicle
    {
        public int NumberOfWheels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Manufacturer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NumberOfSeats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ChangeSpeed()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }


}

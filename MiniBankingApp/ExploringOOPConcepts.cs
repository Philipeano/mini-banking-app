using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    internal class ExploringOOPConcepts
    {
        public void Demo()
        {
            var myShape1 = new Rectangle();
            var myShape2 = new Circle();

            var myCalculator = new Calculator();
            var sum1 = myCalculator.AddNumbers(4, 9);
            var sum2 = myCalculator.AddNumbers(24.7567, 19322.857);
            var sum3 = myCalculator.AddNumbers(17, 22, 57);

            // Because of inheritance, any parent class or interface from which a child class derives can be used as a declaration type
            var myPhone = new SamsungPhone();
            ITelephone myPhone2 = new SamsungPhone();
            IWirelessPhone myPhone3 = new SamsungPhone();
            ISmartPhone myPhone4 = new SamsungPhone();
            MobilePhone myPhone5 = new SamsungPhone();
            SmartPhone myPhone6 = new SamsungPhone();
            SamsungPhone samsungPhone = new SamsungPhone();
        }

    }



    // This is an abstract class. It can contain both abstract and concrete members.
    // It is meant to serve as a base class, and not to be instantiated directly.
    public abstract class Shape
    {
        public abstract float CalculateArea(); // This is an abstract method. Leave implementation to be added/handled by child classes

        public virtual void DisplayNameOfShape() // This is a concrete method. It provides a default implementation to be inherited by child classes
        {
            Console.WriteLine("This is a SHAPE.");
        } 
    }


    public class Rectangle : Shape
    {

        public override float CalculateArea()
        {
            // Add logic to prompt user for length and breadth, then compute and return area
            return 0;
        }

        public override void DisplayNameOfShape()
        {
            Console.WriteLine("This is a RECTANGLE.");
            base.DisplayNameOfShape();
        }


    }

    public class Circle : Shape
    {
        public override float CalculateArea()
        {
            // Add logic to prompt user for radius, then compute area and return area
            return 0;
        }

        public double CalculateCircumference()
        {
            var radius = 15;
            var pi = Math.PI;
            var circumference = 2 * pi * radius; // 2 * Pi * R

            return circumference;
        }
    }



    public sealed class Calculator
    {
        // Method for two adding integers
        public int AddNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        // Method for three adding integers
        public int AddNumbers(int number1, int number2, int number3)
        {
            return number1 + number2 + number3;
        }

        // Method for adding two floating-point numbers
        public double AddNumbers(double number1, double number2)
        {
            return number1 + number2;
        }
    }


    /*     
     Telephones are all around us, and they make our lives much easier. 
     We once had only wired phones which could only make and receive calls. 
     Next, wireless mobile phones were invented, which allowed us make and receive calls, as well as send and receive text messages. 
     Today, smartphones are everywhere. Asides calls and SMS, they are used for emails, surfing the web, and many other web-based functions. 
     Every phone, whatever the category, has a manufacturer and a model. 
     Every mobile phone has a unique IMEI number. Every phone has a keypad, whether physical or virtual.   
     */


    public interface ITelephone
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public object Keypad { get; }

        public void MakeCall();

        public void ReceiveCall();
    }

    public interface IWiredPhone : ITelephone
    {

    }

    public interface IWirelessPhone : ITelephone
    {
        public string IMEI { get; set; }

        public void SendSMS();

        public void ReceiveSMS();
    }

    public interface ISmartPhone : IWirelessPhone
    {
        public void SendEmail();

        public void ReceiveEmail();

        public void SurfWeb();

        public void PerformOtherWebFunction();
    }

    public abstract class MobilePhone : IWirelessPhone
    {
        public string IMEI { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Manufacturer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Keypad => throw new NotImplementedException();

        public void MakeCall()
        {
            throw new NotImplementedException();
        }

        public void ReceiveCall()
        {
            throw new NotImplementedException();
        }

        public void ReceiveSMS()
        {
            throw new NotImplementedException();
        }

        public void SendSMS()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class SmartPhone : MobilePhone, ISmartPhone
    {
        public void PerformOtherWebFunction()
        {
            throw new NotImplementedException();
        }

        public void ReceiveEmail()
        {
            throw new NotImplementedException();
        }

        public void SendEmail()
        {
            throw new NotImplementedException();
        }

        public void SurfWeb()
        {
            throw new NotImplementedException();
        }
    }

    public class SamsungPhone : SmartPhone, ISmartPhone, IWirelessPhone, ITelephone
    {
        // Add any additional props or methods specific to Samsung
    }

    public class InfinixPhone : SmartPhone, ISmartPhone, IWirelessPhone, ITelephone
    {
        // Add any additional props or methods specific to Infinix
    }

    public class TecnoPhone : SmartPhone, ISmartPhone, IWirelessPhone, ITelephone
    {
        // Add any additional props or methods specific to Tecno
    }

}

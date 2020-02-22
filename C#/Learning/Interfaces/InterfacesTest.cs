using System;

namespace Learning.Interfaces
{
    public class InterfacesTest
    {
        public void Process()
        {
            var batCave = new BatCave();
            batCave.Start();
            (batCave as IHome).Start();
            (batCave as IOffice).Start();

            Console.WriteLine();

            var privateBatCave = new SpecificBehaviorBatCave();

            (privateBatCave as IHome).Start();
            (privateBatCave as IOffice).Start();
        }
    }

    public class BatCave : IHome, IOffice
    {
        //public method, can be only one
        public void Start()
        {
            Console.WriteLine("Hi");
        }
    }

    public interface IHome { void Start(); }

    public interface IOffice { void Start(); }

    public class SpecificBehaviorBatCave : IHome, IOffice
    {
        //When you have two interfaces with different behaviors,
        //you must have a method without modifier and you specify the interface name 
        void IHome.Start()
        {
            Console.WriteLine("Home start");
        }

        void IOffice.Start()
        {
            Console.WriteLine("Office start");
        }
    }
}

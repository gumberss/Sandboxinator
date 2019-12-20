using DesignPatterns._1___AbstractFactory;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ContinentFactory factory = new AmericaFactory();
            AnimalWorld animalWorld = new AnimalWorld(factory);
            animalWorld.RunFoodChain();

            ContinentFactory factory2 = new AfricaFactory();
            AnimalWorld animalWorld2 = new AnimalWorld(factory2);
            animalWorld2.RunFoodChain();

            Console.ReadKey();
        }
    }
}

using DesignPatterns._1___AbstractFactory;
using DesignPatterns._2__Factory_Method.Example;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ContinentFactory factory = new AmericaFactory();
            AnimalWorld animalWorld = new AnimalWorld(factory);
            animalWorld.RunFoodChain();

            ContinentFactory factory2 = new AfricaFactory();
            AnimalWorld animalWorld2 = new AnimalWorld(factory2);
            animalWorld2.RunFoodChain();
            */

            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }

            Console.ReadKey();
        }
    }
}

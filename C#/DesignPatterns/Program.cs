using DesignPatterns._1___AbstractFactory;
using DesignPatterns._2__Factory_Method.Example;
using DesignPatterns._2__Factory_Method.RealExample;
using DesignPatterns._3___Adapter;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new Executor().Process();



            /*
            ContinentFactory factory = new AmericaFactory();
            AnimalWorld animalWorld = new AnimalWorld(factory);
            animalWorld.RunFoodChain();

            ContinentFactory factory2 = new AfricaFactory();
            AnimalWorld animalWorld2 = new AnimalWorld(factory2);
            animalWorld2.RunFoodChain();
            */

            /*
              Creator[] creators = new Creator[2];

             creators[0] = new ConcreteCreatorA();
             creators[1] = new ConcreteCreatorB();

             foreach (Creator creator in creators)
             {
                 Product product = creator.FactoryMethod();
                 Console.WriteLine("Created {0}",
                   product.GetType().Name);
             }

              */


            //Document[] documents = new Document[2];

            //documents[0] = new Resume();
            //documents[1] = new Report();


            //foreach (Document document in documents)
            //{
            //    Console.WriteLine("\n" + document.GetType().Name + "--");
            //    foreach (Page page in document.Pages)
            //    {
            //        Console.WriteLine(" " + page.GetType().Name);
            //    }
            //}



            Console.ReadKey();

        }
    }
}

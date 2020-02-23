using System;
using System.Collections.Generic;

namespace Learning.Reflection.MySerializers
{
    public class AppService
    {
        public void Process()
        {
            var hero1 = new Hero()
            {
                Age = 30,
                Name = "Batman",
                Power = "Money",
                Equipments = new List<Equipment>
                {
                    new Equipment(){ Name = "Car", Price = 100000, Useful = true },
                    new Equipment(){ Name = "Cave", Price = 10000000, Useful = true }
                },
                Friend = new Hero
                {
                    Age = 2500,
                    Name = "Thor",
                    Power = "Thunder",
                    Equipments = new List<Equipment>
                    {
                        new Equipment(){ Name = "Mjolnir", Price = 1000000000, Useful = true },
                        new Equipment(){ Name = "Stormbreaker", Price = 10000000000000, Useful = true }
                    },
                }
            };

            var serialized = new MySerializer().Serialize(hero1, new MyXmlSerializer());
            var serialized2 = new MySerializer().Serialize(hero1, new MyJsonSerialize());

            Console.WriteLine(serialized);
            Console.WriteLine(serialized2);
        }

    }
}

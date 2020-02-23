using System;
using System.Collections.Generic;
using System.Text;

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

            var serialized = new MyXmlSerializer().Serialize(hero1);

            Console.WriteLine(serialized);
        }

    }
}

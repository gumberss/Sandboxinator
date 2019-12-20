using System;

namespace DesignPatterns._1___AbstractFactory
{
    public class Lion : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"I'm a lion and I eat {herbivore.GetType().Name}");
        }
    }
}

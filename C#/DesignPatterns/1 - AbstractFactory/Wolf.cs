using System;

namespace DesignPatterns._1___AbstractFactory
{
    public class Wolf : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"I'm a wolf and I eat {herbivore.GetType().Name}");
        }
    }
}

namespace DesignPatterns._1___AbstractFactory
{
    public abstract class ContinentFactory 
    {
        public abstract Herbivore CreateHerbivore();

        public abstract Carnivore CreateCarnivore();
    }
}

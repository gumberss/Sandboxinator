namespace DesignPatterns._1___AbstractFactory
{
    public class AnimalWorld
    {
        private Carnivore _carnivore;
        private Herbivore _herbivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}

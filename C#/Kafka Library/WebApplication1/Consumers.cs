using WebApplication1.Models;

namespace WebApplication1
{
    public class Consumers
    {
        public void ConsumeBanana(Banana? banana)
        {
            Console.WriteLine("I'm consumming a banana" + banana?.Id);
        }
    }
}

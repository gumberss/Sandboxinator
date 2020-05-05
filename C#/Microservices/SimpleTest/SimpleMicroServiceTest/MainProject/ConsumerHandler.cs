using System;
using System.Threading.Tasks;
using Infra.Rebus.Messages;
using Rebus.Handlers;

namespace Consumer
{
    public class ConsumerHandler : IHandleMessages<String>, IHandleMessages<Batman>
    {
        public async Task Handle(String batman)
        {
            Console.WriteLine(batman);
        }

        public async Task Handle(Batman message)
        {
            Console.WriteLine("Batman" + message.Message);
        }
    }
}

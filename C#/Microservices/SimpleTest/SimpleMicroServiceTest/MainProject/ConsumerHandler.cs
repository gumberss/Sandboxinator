using System;
using System.Net.Http;
using System.Threading.Tasks;
using Infra.Rebus.Messages;
using Rebus.Bus;
using Rebus.Handlers;

namespace Consumer
{
    public class ConsumerHandler : IHandleMessages<String>, IHandleMessages<Batman>
    {
        readonly IBus _bus;

        public ConsumerHandler(IBus bus)
        {
            _bus = bus;
        }

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

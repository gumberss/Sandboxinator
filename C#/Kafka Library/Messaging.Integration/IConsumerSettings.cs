using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Integration
{
    public interface IConsumerSettings
    {
        public String Topic { get; }

        public Action<String> Consume { get; }
    }
}

using System;
using System.Collections.Generic;

namespace Learning.Events
{
    public class Newspaper
    {
        public List<Central> Centrals;

        public Newspaper(List<Central> centrals)
        {
            Centrals = centrals;

            Centrals.ForEach(central => central.Observable += OmgOneNotice);
        }

        private void OmgOneNotice(object sender, EventArgs e)
        {
            var centralArgs = (CentralArgs)e;

            Console.WriteLine("Newspaper: " + centralArgs.Message);
        }

        public void Close()
        {
            Centrals.ForEach(x => x.Observable -= OmgOneNotice);
        }
    }
}

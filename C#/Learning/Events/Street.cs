using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning.Events
{
    public class Street
    {

        public void NightRound()
        {
            var officers = new List<Officer>
            {
                new Officer("Batman"),
                new Officer("Iron Main"),
                new Officer("A nice guy")
            };

            var central1 = new Central(officers);

            var officers2 = new List<Officer>
            {
                new Officer("Black Window"),
                new Officer("Sharon Rogers"),
                new Officer("Hulk")
            };

            var central2 = new Central(officers2);

            var newspapper = new Newspaper(new List<Central>
            {
                central1,
                central2
            });

            var newspapper2 = new Newspaper(new List<Central>
            {
                central1,
                central2
            });

            var newspapper3 = new Newspaper(new List<Central>
            {
                central1,
                central2
            });
            var bandits = new[] { "Joker", "A bad guy", "Other bad guy", "you don't belive in it, another bad guy!" };

            officers
                .Concat(officers2)
                .ToList()
                .ForEach(officer => 
                    officer.Captured(bandits[new Random().Next(0, bandits.Length)]));

            newspapper2.Close();
            newspapper3.Close();

            officers
                .Concat(officers2)
                .ToList()
                .ForEach(officer =>
                    officer.Captured(bandits[new Random().Next(0, bandits.Length)]));

            Console.ReadKey();
        }
    }
}

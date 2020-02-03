using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Events
{
    public class Central
    {
        public EventHandler Observable;

        public List<Officer> FieldOfficers { get; set; }

        public Central(List<Officer> fieldOfficers)
        {
            FieldOfficers = fieldOfficers;

            FieldOfficers.ForEach(officer => officer.Observable += LessOne);
        }

        private void LessOne(object sender, EventArgs e)
        {
            var officerEvent = (OfficerArgs)e;

            Console.WriteLine($"My friend {officerEvent.PoliceName} got {officerEvent.BanditName}");

            Observable?.Invoke(this, new CentralArgs($"One less in the streat. The element name is: {officerEvent.BanditName}"));
        }
    }

    public class CentralArgs : EventArgs
    {
        public CentralArgs(string message)
        {
            Message = message;
        }

        public String Message { get; set; }
    }
}

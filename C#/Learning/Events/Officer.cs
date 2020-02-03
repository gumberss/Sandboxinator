using System;

namespace Learning.Events
{
    /// <summary>
    /// Observable???  Hummmm...
    /// </summary>
    public class Officer
    {
        public event EventHandler Observable;

        public Officer(string name)
        {
            Name = name;
        }

        public String Name { get; set; }

        public String Captured(String banditName)
        {
            Observable?.Invoke(this, new OfficerArgs(Name, banditName));

            return "I can't help it!!!";
        }
    }

    public class OfficerArgs : EventArgs
    {
        public OfficerArgs(string policeName, string banditName)
        {
            PoliceName = policeName;
            BanditName = banditName;
        }

        public String PoliceName { get; set; }

        public String BanditName { get; set; }
    }
}

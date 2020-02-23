using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Reflection.MySerializers
{
    public class Hero
    {
        public String Name { get; set; }

        public String Power { get; set; }

        public long Age { get; set; }

        public List<Equipment> Equipments { get; set; }

        public Hero Friend { get; set; }
    }

    public class Equipment
    {
        public String Name { get; set; }

        public decimal Price { get; set; }

        public bool Useful { get; set; }
    }
}

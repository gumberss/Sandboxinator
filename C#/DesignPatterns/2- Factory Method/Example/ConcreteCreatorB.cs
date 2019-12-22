﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns._2__Factory_Method.Example
{
    public class ConcreteCreatorB : Creator

    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}

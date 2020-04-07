using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.ObjectLifeCycle
{
    public class MyOtherDisposable
    {
        public void Process()
        {

            var dispo = new Dispo();

            

        }
    }


    public class Dispo : IDisposable
    {
        void IDisposable.Dispose()
        {
            //dispose
        }
    }
}

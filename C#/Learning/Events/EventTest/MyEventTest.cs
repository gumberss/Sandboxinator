using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Learning.Events.EventTest
{
    //https://stackoverflow.com/questions/18385967/c-sharp-event-keyword-advantages
    public class MyEventTest
    {
        
        public void Process()
        {
            var a = new MyHappyEvent();

            a.myEvent += b;
            a.myEvent2 += b;
            a.myEvent3 += c;
            a.PropertyChanging += d;

            a.myEvent2.Invoke(this, new MyEventArgs("myEvent2"));
            a.myEvent3.Invoke(this, new MyEventArgs("myEvent3"));

            //Events can't be invoked outside of their classes
            //a.myEvent.Invoke(this, new MyEventArgs(myEvent));
            //a.PropertyChanging.Invoke(this, new PropertyChangingEventArgs("PropertyChanging"));
            a.InvokeEvents("AHHHHHHHHHHHHHHHh");

        }

        private void b(object sender, EventArgs e)
        {
            Console.WriteLine($"EventArgs: {((MyEventArgs)e).Text}");
        }

        private void c(object sender, MyEventArgs e)
        {
            Console.WriteLine($"MyEventArgs: {e.Text}");
        }

        private void d(object sender, PropertyChangingEventArgs e)
        {
            Console.WriteLine($"PropertyChangingEventArgs: {e.PropertyName}");
        }
    }

    
}

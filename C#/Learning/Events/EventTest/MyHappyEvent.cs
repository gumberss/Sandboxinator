using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Learning.Events.EventTest
{
    public class MyHappyEvent : INotifyPropertyChanging
    {
        public event EventHandler myEvent;
        public EventHandler myEvent2;
        public EventHandler<MyEventArgs> myEvent3;

        public event PropertyChangingEventHandler PropertyChanging;

        public void InvokeEvents(String message)
        {
            myEvent.Invoke(this, new MyEventArgs($"Event: {message}"));
            PropertyChanging.Invoke(this, new PropertyChangingEventArgs($"Event: {message}"));
        }
    }


    public class MyEventArgs : EventArgs
    {
        public string Text { get; set; }

        public MyEventArgs(String text)
        {
            Text = text;
        }
    }
}

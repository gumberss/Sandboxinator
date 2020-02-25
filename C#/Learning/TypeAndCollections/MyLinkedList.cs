using System;
using System.Collections.Generic;

namespace Learning.TypeAndCollections
{
    public class MyLinkedList
    {

        public void Process()
        {
            LinkedList<String> weekDays = new LinkedList<string>();

            var d4 = weekDays.AddFirst("Wednesday");
            var d2 = weekDays.AddBefore(d4, "Monday");
            weekDays.AddAfter(d2, "Tuesday");
            var d6 = weekDays.AddAfter(d4, "Friday");
            weekDays.AddAfter(d6, "Saturday");
            weekDays.AddBefore(d6, "Thursday");
            weekDays.AddBefore(d2, "Sunday");

            foreach (var day in weekDays)
            {
                Console.WriteLine(day);
            }


        }
    }
}

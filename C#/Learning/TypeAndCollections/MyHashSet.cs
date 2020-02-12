using System;
using System.Collections.Generic;
using System.Linq;

namespace Learning.TypeAndCollections
{
    public class MyHashSet
    {
        public void Process()
        {
            var even = new List<int> { 0, 2, 4, 6, 8, 10 };
            var odd = new List<int> { 1, 3, 5, 7, 9 };
            var primes = new List<int> { 1, 2, 3, 5, 7 };

            ISet<int> join = new HashSet<int>(); // It never can be repeated because it is a HashSet

            even.ForEach(x => join.Add(x));
            odd.ForEach(x => join.Add(x));
            primes.ForEach(x => join.Add(x));

            foreach (var item in join)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in even.Union(odd).Union(primes))// It can be repeated because it is a list
            {
                Console.WriteLine(item);
            }
        }

    }
}

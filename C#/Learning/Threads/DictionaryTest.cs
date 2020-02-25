using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Learning.Threads
{
    public class DictionaryTest
    {
        public void Process()
        {
            ConcurrentDictionary<int, int> dictionary = new ConcurrentDictionary<int, int>();

            for (int i = 0; i < 50; i++)
            {
                dictionary[i] = 0;
            }

            Thread t = new Thread(() => ChangeDictionary(dictionary));
            t.Start();

            Thread t1 = new Thread(() => ChangeDictionary(dictionary));
            t1.Start();

            t.Join();
            t1.Join();

            for (int i = 0; i < dictionary.Count; i++)
            {
                Console.WriteLine($"{i} - {dictionary[i]}");
            }
        }

        public void ChangeDictionary(ConcurrentDictionary<int, int> dictionary)
        {
            for (int i = 0; i < 50; i++)
            {
                int existentValue;

                do
                {
                    existentValue = dictionary[i];

                } while (!dictionary.TryUpdate(i, existentValue + 1, existentValue));

                Thread.Sleep(i);
            }
        }
    }
}

using System.Threading;

namespace Learning.Threads
{
    public class Block
    {
        private object _lock = new object();

        public void Process()
        {
            lock (_lock)
            {
                //object locked
            }

            Monitor.Enter(_lock);
            //object locked
            Monitor.Exit(_lock);

            if (Monitor.TryEnter(_lock))
            {
                //object locked
            }
            else
            {
                //the object couldn't be locked
            }

            int integer = 0;

            Interlocked.Add(ref integer, 1);
            //integer == 1;
        }

    }
}

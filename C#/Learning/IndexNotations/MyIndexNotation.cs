using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning.IndexNotations
{
    public class MyIndexNotation
    {
        public void Process()
        {
            var notation = new MyNotation();

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(notation[i]);
            }
        }
    }

    public class MyNotation
    {
        private List<int> _integers;

        public MyNotation()
        {
            _integers = Enumerable.Range(50, 100).ToList();
        }

        public int this[int index]
        {
            get
            {
                return _integers[index];
            }
            set
            {
                _integers[index] = value;
            }
        }
    }
}

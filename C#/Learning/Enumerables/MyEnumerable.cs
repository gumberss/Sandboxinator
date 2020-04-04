using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Learning.Enumerables
{
    public class MyEnumerable
    {
        public void Process()
        {

        }

    }

    public class MyFunnyEnumerable : IEnumerable<int>
    {
        private List<int> _list;

        public MyFunnyEnumerable()
        {
            _list = new List<int>();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

    }
}

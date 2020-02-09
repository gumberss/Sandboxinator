using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro.antes
{
    class TiposDeValor : IAulaItem
    {
        public void Executar()
        {

        }

        public class Batman
        {

            private IList<int> MyInt { get; set; }

            public int this[int index]
            {
                get
                {
                    return MyInt[index];
                }
                set
                {
                    MyInt[index] = value;
                }
            }
        }
    }
}

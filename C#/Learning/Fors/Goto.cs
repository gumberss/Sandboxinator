using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning.Fors
{
    public class Goto
    {
        public void Process()
        {
            var matrix = new int[10, 10, 10];

            CSharp7(matrix);

            //MyGoTo(matrix);
        }

        //Here you don't need goto anymore
        private static void CSharp7(int[,,] matrix)
        {
            int Work()
            {
                var result = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); i++)
                        for (int k = 0; k < matrix.GetLength(2); i++)
                        {
                            result = 1;
                            return result;
                        }
                }

                return result;
            }

            var result = Work();

            if (result == 1)
                Console.WriteLine(1);
            else
                Console.WriteLine(2);
        }

        private static void MyGoTo(int[,,] matrix)
        {
            var result = 0;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); i++)
                    for (int k = 0; k < matrix.GetLength(2); i++)
                    {
                        result = 1;
                        goto EndSearch;
                    }
            }


        EndSearch:
            if (result == 1)
                Console.WriteLine(1);
            else
                Console.WriteLine(2);
        }

    }
}

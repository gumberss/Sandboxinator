using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Learning.Transactions
{
    public class MyTransactions
    {
        private int a;

        public void Process()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                DoSomething();

                //If scope2 use Supress as transaction scope option, This code works
                //If you change Supress to require, an AbortedException is thrown
                using (TransactionScope scope2 = new TransactionScope(TransactionScopeOption.Suppress))
                {
                    try
                    {
                        AProblem();
                    }
                    catch (Exception ex)
                    {
                        //an error
                    }
                }

                scope.Complete();
            }

            Console.WriteLine(a);
        }
        public void DoSomething()
        {
            a = 10;
        }

        public void AProblem()
        {
            throw new Exception();
        }

    }
}

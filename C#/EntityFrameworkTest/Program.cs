using Learning;
using Learning.Threads.BusinessRules;
using System;

namespace EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MyContext())
            {
                var movieRules = new MovieRules();

                movieRules.Medium();
            }
        }
    }
}

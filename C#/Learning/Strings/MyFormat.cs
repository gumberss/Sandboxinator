using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Learning.Strings
{
    public class MyFormat
    {

        public void Process()
        {
            Console.WriteLine(String.Format("{0:dd/MM/yyyy}", DateTime.Now));
            Console.WriteLine(String.Format("{0:d}", DateTime.Now));
            Console.WriteLine(String.Format($"{DateTime.Now:dd/MM/yyyy}"));
            Console.WriteLine(String.Format($"{DateTime.Now:D}"));
            Console.WriteLine(String.Format(new CultureInfo("pt-BR").DateTimeFormat, "{0:D}", DateTime.Now));
            Console.WriteLine();
            Console.WriteLine(String.Format($"{DateTime.Now:hh:mm:ss}"));//12h
            Console.WriteLine(String.Format($"{DateTime.Now:HH:mm:ss}"));//24h
            Console.WriteLine(String.Format($"{DateTime.Now:T}"));
            Console.WriteLine(String.Format($"{DateTime.Now:t}"));
            Console.WriteLine();
            Console.WriteLine(String.Format($"{500:c}"));
            Console.WriteLine(String.Format($"{500:c0}"));
            Console.WriteLine(String.Format($"{500:c4}"));
            Console.WriteLine();
            Console.WriteLine(String.Format($"{30:N2}"));
            Console.WriteLine(String.Format($"{30:N3}"));
            Console.WriteLine();
            Console.WriteLine(String.Format($"{3:###0}"));
            Console.WriteLine(String.Format($"{30:###0}"));
            Console.WriteLine(String.Format($"{300:###0}"));
            Console.WriteLine(String.Format($"{3000:###0}"));
            Console.WriteLine(String.Format($"{30000:###0}"));
            Console.WriteLine(String.Format($"{0:###0}"));



        }
    }
}

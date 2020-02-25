using System;
using System.Collections.Generic;
using System.Reflection;

namespace Learning.Reflection
{
    public class MyAttribute
    {
        [Detailed("{0} - {1}")]
        [Summary("{0}")]
        public void Process()
        {
            MethodBase method = MethodBase.GetCurrentMethod();

            var methodSummary = Attribute.GetCustomAttribute(method, typeof(SummaryAttribute));
            var methodDetailed = method.GetCustomAttribute(typeof(DetailedAttribute), true);

            Console.WriteLine((methodSummary as SummaryAttribute).Format, "First way to get attributes from a method");
            Console.WriteLine((methodDetailed as DetailedAttribute).Format, "Second way to get attributes from a method", "That is fun");

            List<Sell> sells = new List<Sell>()
            {
                new Sell{ City = "City", Date = DateTime.Now, Name = "James", PaymentType = "Money", Price = 500, Product = "Flowers" },
                new Sell{ City = "City2", Date = DateTime.Now, Name = "Thanos", PaymentType = "Half the universe of Marvel", Price = 1500, Product = "Bubbles" }
            };

            Attribute attr = Attribute.GetCustomAttribute(typeof(Sell), typeof(SummaryAttribute));

            String format = (attr as SummaryAttribute).Format;

            foreach (var sell in sells)
            {
                Console.WriteLine(String.Format(format, sell.Date, sell.Product, sell.Price, sell.PaymentType));
            }

            Console.WriteLine();

            Attribute attr2 = Attribute.GetCustomAttribute(typeof(Sell), typeof(DetailedAttribute));

            String format2 = (attr2 as DetailedAttribute).Format;

            foreach (var sell in sells)
            {
                Console.WriteLine(String.Format(format2, sell.Date, sell.Product, sell.Price, sell.PaymentType, sell.Name, sell.City));
            }
        }
    }


    [Detailed("{0,-16}    {1,-12}    {2,12}    {3,-30}     {4,-20}    {5,-20}")]
    [Summary("{0,-16}    {1,-12}    {2,12:C}    {3,-30}")]
    public class Sell
    {
        public DateTime Date { get; set; }
        public String Product { get; set; }
        public decimal Price { get; set; }
        public String PaymentType { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
    }

    public class DetailedAttribute : Attribute
    {
        public DetailedAttribute(String format)
        {
            Format = format;
        }

        public String Format { get; set; }
    }

    public class SummaryAttribute : Attribute
    {
        public SummaryAttribute(String format)
        {
            Format = format;
        }

        public String Format { get; set; }
    }
}

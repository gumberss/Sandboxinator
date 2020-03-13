using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns._4___Composite
{
    public class CompositeExecutor
    {
        public void Process()
        {
            //Simple
            ISell product = new Product("Ball", 10);
            ISell product2 = new Product("Pillow", 15);

            ISell box = new Box(new[] { product, product2 }.ToList(), 1.50M);

            Console.WriteLine("The price of the box is: {0}", box.TotalValue());

            //Complex

            ISell product3 = new Product("Toy", 4.50M);
            ISell product4 = new Product("Door", 56.20M);
            ISell product5 = new Product("Mouse", 16.25M);

            ISell box2 = new Box(new[] { product3, product4 }.ToList(), 2.50M);

            ISell pallet = new Pallet(new[] { box, product5 }.ToList(), 13.60M);
            ISell pallet2 = new Pallet(new[] { (ISell)new Product("A little house", 540.99M) }.ToList(), 50.00M);

            ISell shopping = new Shopping(new[] { box2, pallet, pallet2}.ToList());

            Console.WriteLine("The total value of your shopping is: {0}", shopping.TotalValue());
        }
    }

    public interface ISell
    {
        decimal TotalValue();
    }

    public class Box : ISell
    {
        private readonly List<ISell> _products;

        public decimal BoxPrice { get; private set; }

        public Box(List<ISell> products, decimal price)
        {
            _products = products;

            BoxPrice = price;
        }

        public decimal TotalValue()
        {
            return _products.Sum(x => x.TotalValue()) + BoxPrice;
        }
    }

    public class Pallet : ISell
    {
        private readonly List<ISell> _products;

        public decimal PalletPrice { get; private set; }

        public Pallet(List<ISell> products, decimal palletPrice)
        {
            _products = products;
            PalletPrice = palletPrice;
        }

        public decimal TotalValue()
        {
            return _products.Sum(x => x.TotalValue()) + PalletPrice;
        }
    }

    public class Product : ISell
    {
        public Product(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public String Name { get; private set; }

        public decimal Value { get; private set; }

        public decimal TotalValue()
        {
            return Value;
        }
    }

    public class Shopping : ISell
    {
        private readonly List<ISell> _sells;

        public Shopping(List<ISell> sells)
        {
            _sells = sells;
        }

        public decimal TotalValue()
        {
            return _sells.Sum(x => x.TotalValue());
        }
    }
}

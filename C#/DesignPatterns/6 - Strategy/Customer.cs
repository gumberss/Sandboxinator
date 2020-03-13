
namespace DesignPatterns._6___Strategy
{
    public class Customer : IPayer
    {
        public Customer(double balance, double limit)
        {
            Balance = balance;
            Limit = limit;
        }

        public double Balance { get; private set; }

        public double Limit { get; private set; }

        public bool CanPay(double valueToPay) => Balance + Limit >= valueToPay;

        public double Pay(double value) => Balance -= value;

        public double CashBack(double value) => Balance += value;
    }
}


namespace DesignPatterns._6___Strategy
{
    public class Store : IReceiver
    {
        public Store(double balance)
        {
            Balance = balance;
        }

        public double Balance { get; private set; }

        public double ReceiveMoney(double value) => Balance += value;

        public double PayOperationTax(double value) => Balance -= value;
    }
}

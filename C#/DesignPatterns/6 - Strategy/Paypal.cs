
namespace DesignPatterns._6___Strategy
{
    public class Paypal : IPayment
    {
        public bool ProcessPayment(IPayer payer, IReceiver receiver, double value)
        {
            if (!payer.CanPay(value)) return false;

            payer.Pay(value);

            var operationTax = value * 0.001;

            receiver.ReceiveMoney(operationTax);

            var cashBack = value <= 100 ? value * 0.010 : 10;

            payer.CashBack(cashBack);

            return true;
        }
    }
}

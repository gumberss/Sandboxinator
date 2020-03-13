
namespace DesignPatterns._6___Strategy
{
    public class DebitCard : IPayment
    {
        public bool ProcessPayment(IPayer payer, IReceiver receiver, double value)
        {
            if (!payer.CanPay(value)) return false;

            payer.Pay(value);

            receiver.ReceiveMoney(value);

            return true;
        }
    }
}

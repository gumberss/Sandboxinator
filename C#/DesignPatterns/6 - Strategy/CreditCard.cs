
namespace DesignPatterns._6___Strategy
{
    public class CreditCard : IPayment
    {
        public bool ProcessPayment(IPayer payer, IReceiver receiver, double value)
        {
            var interest = value * 0.021;

            var totalValueToPay = value + interest;

            if (payer.CanPay(totalValueToPay))
            {
                payer.Pay(totalValueToPay);

                receiver.ReceiveMoney(value);

                var operationTax = interest / 4;

                receiver.PayOperationTax(operationTax);

                return true;
            }

            return false;
        }
    }
}

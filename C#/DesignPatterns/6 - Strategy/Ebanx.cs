
namespace DesignPatterns._6___Strategy
{
    public class Ebanx
    {
        public IPayment Payment { get; private set; }

        public double Balance { get; private set; }

        public Ebanx With(IPayment paymentMethod)
        {
            Payment = paymentMethod;

            return this;
        }

        public bool ProcessPurchase(IPayer payer, IReceiver receiver, double purchaseValue)
        {
            var ebanxTaxToProcess = purchaseValue * 0.0005;

            var processStatus = Payment.ProcessPayment(payer, receiver, purchaseValue);

            receiver.PayOperationTax(ebanxTaxToProcess);

            Balance += ebanxTaxToProcess;

            return processStatus;
        }
    }
}

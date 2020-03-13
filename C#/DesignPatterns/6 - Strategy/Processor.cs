
namespace DesignPatterns._6___Strategy
{
    public class Processor
    {
        public void Process()
        {
            var payer = new Customer(1000, 100);
            var receiver = new Store(1000);

            var ebanx = new Ebanx();

            ebanx.With(new CreditCard()).ProcessPurchase(payer, receiver, 100);
            ebanx.With(new DebitCard()).ProcessPurchase(payer, receiver, 200);
            ebanx.With(new Paypal()).ProcessPurchase(payer, receiver, 300);
        }
    }
}


namespace DesignPatterns._6___Strategy
{
    public interface IPayment
    {
        bool ProcessPayment(IPayer payer, IReceiver receiver, double value);
    }
}

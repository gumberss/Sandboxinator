
namespace DesignPatterns._6___Strategy
{
    public interface IReceiver
    {
        /// <summary>
        /// Receive money and add it to balance
        /// </summary>
        /// <param name="value">the value they receive</param>
        /// <returns>new balance</returns>
        double ReceiveMoney(double value);

        double PayOperationTax(double value);
    }
}

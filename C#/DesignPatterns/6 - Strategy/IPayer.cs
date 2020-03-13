using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns._6___Strategy
{
    public interface IPayer
    {
        /// <summary>
        /// Receive the value tha they have to pay and return the remaining balance 
        /// </summary>
        /// <param name="value">value that they have to pay</param>
        /// <returns>remaining money</returns>
        double Pay(double value);

        bool CanPay(double valueToPay);

        double CashBack(double value);
    }
}

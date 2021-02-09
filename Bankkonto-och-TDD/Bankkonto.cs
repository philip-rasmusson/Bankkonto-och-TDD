using System;
using System.Collections.Generic;
using System.Text;

namespace Bankkonto_och_TDD
{
    public class Bankkonto
    {
        public double credit { get; set; }
        public double saldo { get; set; }
        public double swishLimit { get; set; }
        public double swishAmount { get; set; }


        public bool IsDepositCorrect(double amount)
        {

            if (amount > 0)
            {

                return true;
            }

            return false;
        }

        public bool IsWithdrawlCorrect(double amount)
        {

            if (amount <= saldo + credit)
            {

                return true;
            }

            return false;
        }

        public bool SwishTransaction(double amount)
        {
            var tempValue = swishAmount + amount;

            if (tempValue <= swishLimit)
            {
                    swishAmount = tempValue;
                    return true;                
            }

            return false;
        }

        public bool Transaction(double amount)
        {

            return false;
        }
    }
}

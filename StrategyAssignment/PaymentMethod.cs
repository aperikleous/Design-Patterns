using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAssignment
{
    abstract class PaymentMethod
    {
        public abstract bool Pay(decimal amount);
    }

    class CreditCard : PaymentMethod
    {
        public override bool Pay(decimal amount)
        {
            if (amount <= 0m || amount > 100000)
            {
                Console.WriteLine($"Paying {amount} using Credit Card declined");
                return false;
            }
            else
            {
                Console.WriteLine($"Paying {amount} using Credit Card");
                return true;
            }
        }
    }

    class BankTransfer : PaymentMethod
    {
        public override bool Pay(decimal amount)
        {
            if (amount <= 0m || amount > 1000)
            {
                Console.WriteLine($"Paying {amount} using PayPal declined");
                return false;
            }
            else
            {
                Console.WriteLine($"Paying {amount} using PayPal");
                return true;
            }
        }
    }

    class Cash : PaymentMethod
    {
        public override bool Pay(decimal amount)
        {
            Console.WriteLine("Payment with cash declined due to COVID-19");
            return false;
        }
    }
}

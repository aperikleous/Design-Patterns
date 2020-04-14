using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAssignment
{
    class EShopBasket
    {
        private PaymentMethod _paymentMethod;
        private decimal _dueAmount;
        private IEnumerable<Variation> _variations;
        public void SelectPaymentMethod(PaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void SetDueAmount(decimal amount)
        {
            _dueAmount = amount;
        }

        public void SetVariations(IEnumerable<Variation> variations)
        {
            _variations = variations;
        }

        public bool Pay()
        {
            return _paymentMethod.Pay(_dueAmount);
        }

        public void CalculatePrice(TShirt tshirt)
        {
            foreach (var variation in _variations)
            {
                Console.WriteLine($"Applying {variation.GetType().Name}");
                variation.Cost(tshirt);
                Console.WriteLine($"TShirt cost after applying {variation.GetType().Name} is: {tshirt.Price}");
            }
        }
    }

    class Eshop
    {
        public static void EShopInterface()
        {

            Console.WriteLine("Welcome to the T-Shirt E-shop");

            TShirt tshirt = CreateTShirt();
            List<Variation> variations = new List<Variation>();
            ColorVariation c = new ColorVariation();
            SizeVariation s = new SizeVariation();
            FabricVariation f = new FabricVariation();
            variations.Add(c);
            variations.Add(s);
            variations.Add(f);
            
            var basket = new EShopBasket();
            basket.SetVariations(variations);
            basket.CalculatePrice(tshirt);
            basket.SetDueAmount(tshirt.Price);

            Console.Write("How would you like to pay? 1) CreditCard, 2) Bank Transfer, 3) Cash: ");
            var paymentType = int.Parse(Console.ReadLine().Trim());

            var payments = new Payments();
            bool success = payments.PayBasket(basket, paymentType);

            Console.WriteLine(success);
            Console.Read();
        }


        public static TShirt CreateTShirt()
        {
            Console.WriteLine("Please choose the color of your t-shirt out of the following options");
            var colors = Enum.GetValues(typeof(Color));
            int counter = 0;
            foreach (var color in colors)
            {
                Console.WriteLine("{0}      -{1}", ++counter, color);
            }
            Color tshirtColor = (Color)int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Please choose the size of your t-shirt out of the following options");
            var sizes = Enum.GetValues(typeof(Size));
            counter = 0;
            foreach (var size in sizes)
            {
                Console.WriteLine("{0}      -{1}", ++counter, size);
            }
            Size tshirtSize = (Size)int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Please choose the fabric of your t-shirt out of the following options");
            var fabrics = Enum.GetValues(typeof(Fabric));
            counter = 0;
            foreach (var fabric in fabrics)
            {
                Console.WriteLine("{0}      -{1}", ++counter, fabric);
            }
            Fabric tshirtFabric = (Fabric)int.Parse(Console.ReadLine().Trim());

            TShirt tshirt = new TShirt(tshirtColor, tshirtSize, tshirtFabric);
            return tshirt;
        }
    }
    class Payments
    {
        public bool PayBasket(EShopBasket basket, int paymentMethod)
        {
            switch (paymentMethod)
            {
                case 1:
                    basket.SelectPaymentMethod(new CreditCard());
                    break;

                case 2:
                    basket.SelectPaymentMethod(new BankTransfer());
                    break;

                case 3:
                    basket.SelectPaymentMethod(new Cash());
                    break;

                default:
                    basket.SelectPaymentMethod(new CreditCard());
                    break;

            }
            var success = basket.Pay();
            return success;
        }
    }

}


using System.Collections.Generic;

namespace StrategyAssignment
{
    abstract class Variation
    {
        public abstract decimal Cost(TShirt tshirt);
    }

    //abstract class Variation<T>
    //{
    //    public abstract decimal Cost<T>(T item);
    //}

    class ColorVariation : Variation
    {
        public override decimal Cost(TShirt tshirt)
        {
            switch (tshirt.Color)
            {
                case Color.BLUE:
                    tshirt.Price += 0.5m;
                    break;

                case Color.GREEN:
                    tshirt.Price += 0.75m;
                    break;

                case Color.INDIGO:
                    tshirt.Price += 1m;
                    break;

                case Color.ORANGE:
                    tshirt.Price += 1.25m;
                    break;

                case Color.RED:
                    tshirt.Price += 1.5m;
                    break;

                case Color.VIOLET:
                    tshirt.Price += 1.75m;
                    break;

                case Color.YELLOW:
                    tshirt.Price += 2m;
                    break;

                default:
                    tshirt.Price += 0m;
                    break;
            }

            return tshirt.Price;
        }
    }

    class SizeVariation : Variation
    {
        private static Dictionary<Size, decimal> _sizeCosts;

        static SizeVariation()
        {
            _sizeCosts = new Dictionary<Size, decimal>()
            {
                { Size.XS, 2m },
                { Size.S, 4m },
                { Size.M, 6m },
                { Size.L, 8m },
                { Size.XL, 10m },
                { Size.XXL, 12m },
                { Size.XXXL, 14m }
            };
        }

        public override decimal Cost(TShirt tshirt)
        {
            tshirt.Price += _sizeCosts[tshirt.Size];
            return tshirt.Price;
        }
    }

    class FabricVariation : Variation
    {
        private static Dictionary<Fabric, decimal> _fabricVariations;

        static FabricVariation()
        {
            _fabricVariations = new Dictionary<Fabric, decimal>()
            {
                { Fabric.CASHMERE, 15m },
                { Fabric.COTTON, 5m },
                { Fabric.LINEN, 9m },
                { Fabric.POLYESTER, 6m },
                { Fabric.RAYON, 8m },
                { Fabric.SILK, 22m },
                { Fabric.WOOL, 12m }
            };
        }

        public override decimal Cost(TShirt tshirt)
        {
            tshirt.Price += _fabricVariations[tshirt.Fabric];
            return tshirt.Price;
        }
    }
}

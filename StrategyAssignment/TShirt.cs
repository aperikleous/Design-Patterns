using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAssignment
{
    class TShirt
    {
        public readonly Color Color;
        public readonly Size Size;
        public readonly Fabric Fabric;

        public decimal Price { get; set; }

        public TShirt(Color color, Size size, Fabric fabric)
        {
            Color = color;
            Size = size;
            Fabric = fabric;
        }
    }

    enum Color
    {
        BLUE = 1,
        GREEN,
        INDIGO,
        ORANGE,
        RED,
        VIOLET,
        YELLOW
    }

    enum Size
    {
        XS = 1,
        S,
        M,
        L,
        XL,
        XXL,
        XXXL
    }

    enum Fabric
    {
        CASHMERE = 1,
        COTTON,
        LINEN,
        POLYESTER,
        RAYON,
        SILK,
        WOOL
    }
}

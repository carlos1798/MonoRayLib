using monoos.src.Game.Interfaces;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.PropertiesTypes
{
    public class UtilityProperty : PropertyLocation, IProperty
    {
        public UtilityProperty(string name, int square) : base(name, square)
        {
        }

        public override void BuyProperty(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Execute(Player player)
        {
            throw new NotImplementedException();
        }

        public override void LocationRender(Board board)
        {
            Console.WriteLine("Utility");
        }

        public override void PayRent(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
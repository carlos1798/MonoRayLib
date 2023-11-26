using monoos.src.Game.Interfaces;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.PropertiesTypes
{
    internal class RailRoadProperty : PropertyLocation, IProperty
    {
        public RailRoadProperty(string name, Image sprite, int square) : base(name, sprite, square)
        {
        }

        public void BuyProperty(Player player)
        {
            throw new NotImplementedException();
        }

        public void Execute(Player player)
        {
            throw new NotImplementedException();
        }

        public void PayRent(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
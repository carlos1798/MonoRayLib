using monoos.src.Game.Interfaces;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.PropertiesTypes
{
    public class RailRoadProperty : PropertyLocation, IProperty
    {
        public int RentFullSet;
        public int Rent2;
        public int Rent3;

        public RailRoadProperty(string name, int square, int price, bool mortgaged, int rent) : base(name, square, price, mortgaged, rent)
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
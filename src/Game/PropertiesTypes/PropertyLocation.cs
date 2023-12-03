using monoos.src.Game.Interfaces;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.PropertiesTypes
{
    public abstract class PropertyLocation : Location, IProperty
    {
        private Player? owner;
        private int price;
        private bool purcharsed;
        private bool mortgaged;
        private int rent;
        private int housecost;
        private List<Building> Buildings = new();

        public PropertyLocation(string name, Image sprite, int square) : base(name, sprite, square)
        {
            this.name = name; this.sprite = sprite; this.square = square;
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

        private void mortgagedProperty()
        {
        }
    }
}
using monoos.src.Game.Interfaces;
using Newtonsoft.Json;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.PropertiesTypes
{
    public abstract class PropertyLocation : Location
    {
        public Player? owner;
        private int price;
        private bool mortgaged;
        private int rent;

        public PropertyLocation(string name, int square) : base(name, square)
        {
        }

        protected PropertyLocation(string name, int square, int price, bool mortgaged, int rent) : base(name, square)
        {
            this.name = name;
            this.square = square;
            this.price = price;
            this.mortgaged = mortgaged;
            this.rent = rent;
        }

        public int Price { get => price; set => price = value; }
        public bool Mortgaged { get => mortgaged; set => mortgaged = value; }
        public int Rent { get => rent; set => rent = value; }

        public abstract void BuyProperty(Player player);

        public abstract void Execute(Player player);

        public abstract void PayRent(Player player);
    }
}
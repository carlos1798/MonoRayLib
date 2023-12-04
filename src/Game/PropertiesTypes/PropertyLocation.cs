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
        private int mortgagedValue;
        private int rent;

        protected PropertyLocation(string name, int square) : base(name, square)
        {
            this.name = name;
            this.square = square;
        }

        public int Price { get => price; set => price = value; }
        public int Rent { get => rent; set => rent = value; }
        public int MortgagedValue { get => mortgagedValue; set => mortgagedValue = value; }

        public abstract void BuyProperty(Player player);

        public abstract void Execute(Player player);

        public abstract void PayRent(Player player);
    }
}
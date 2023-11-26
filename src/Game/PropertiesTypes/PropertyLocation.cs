using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.PropertiesTypes
{
    internal abstract class PropertyLocation : Location
    {
        private Player? owner;
        private int price;
        private bool purcharsed;
        private bool mortgaged;

        protected PropertyLocation(string name, Image sprite, int square) : base(name, sprite, square)
        {
        }

        private void mortgagedProperty()
        {
        }
    }
}
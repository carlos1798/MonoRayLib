using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game
{
    internal abstract class Location
    {
        protected string name;
        protected Image sprite;
        protected int square;

        protected Location(string name, Image sprite, int square)
        {
            this.name = name;
            this.sprite = sprite;
            this.square = square;
        }
    }
}
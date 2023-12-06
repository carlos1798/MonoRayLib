﻿using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game
{
    public abstract class Location
    {
        public string name;

        //protected Image sprite;
        public int square;

        protected Location(string name, int square)
        {
            this.name = name;
            //   this.sprite = sprite;
            this.square = square;
        }

        public abstract void LocationRender(Board board);
    }
}
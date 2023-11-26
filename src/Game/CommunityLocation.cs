using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game
{
    internal class CommunityLocation : EventLocation
    {
        public CommunityLocation(string name, Image sprite, int square) : base(name, sprite, square)
        {
        }
    }
}
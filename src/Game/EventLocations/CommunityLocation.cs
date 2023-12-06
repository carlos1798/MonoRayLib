using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.EventLocations
{
    public class CommunityLocation : EventLocation
    {
        public CommunityLocation(string name, int square) : base(name, square)
        {
        }

        public override void ExecuteEvent(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
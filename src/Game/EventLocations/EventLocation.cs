using monoos.src.Game.Interfaces;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.EventLocations
{
    public abstract class EventLocation : Location, IEvent
    {
        public EventLocation(string name, int square) : base(name, square)
        {
        }

        public abstract void ExecuteEvent(Player player);
    }
}
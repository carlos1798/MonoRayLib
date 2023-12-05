using monoos.src.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.EventLocations
{
    internal class TaxLocation : EventLocation, IEvent
    {
        public TaxLocation(string name, int square) : base(name, square)
        {
        }

        public override void ExecuteEvent(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
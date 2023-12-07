using monoos.src.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.EventLocations
{
    public class TaxLocation : EventLocation, IEvent
    {
        private int amount;

        public TaxLocation(string name, int square) : base(name, square)
        {
        }

        public int Amount { get => amount; set => amount = value; }

        public override void ExecuteEvent(Player player)
        {
            throw new NotImplementedException();
        }

        public override void LocationRender(Board board)
        {
            Console.WriteLine("Tax1");
        }
    }
}
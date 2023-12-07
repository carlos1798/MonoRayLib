using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.EventLocations.BigSquareLocations
{
    public class GoToJailLocation : EventLocation
    {
        public GoToJailLocation(string name, int square) : base(name, square)
        {
        }

        public override void ExecuteEvent(Player player)
        {
            throw new NotImplementedException();
        }

        public override void LocationRender(Board board)
        {
            Console.WriteLine("gtojail");
        }
    }
}
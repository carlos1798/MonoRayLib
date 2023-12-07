using monoos.src.Render.LocationRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.EventLocations.BigSquareLocations
{
    public class StartLocation : EventLocation
    {
        public int collection;

        public StartLocation(string name, int square) : base(name, square)
        {
        }

        public override void ExecuteEvent(Player player)
        {
            throw new NotImplementedException();
        }

        public override void LocationRender(Board board)
        {
            new StartLocationRender(this, board.render.Squares[square], board.textures).RenderLocation();
        }
    }
}
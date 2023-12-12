using monoos.src.Game.Interfaces;
using monoos.src.Render.LocationRenderers;

namespace monoos.src.Game.EventLocations
{
    public class ChanceLocation : EventLocation, IEvent
    {
        public ChanceLocation(string name, int square) : base(name, square)
        {
            this.name = name;
            this.square = square;
        }

        public override void ExecuteEvent(Player player)
        {
            throw new NotImplementedException();
        }

        public override void LocationRender(Board board)
        {
            new ChanceLocationRender(this, board.render.Squares[square], board.textures).RenderLocation();
        }
    }
}
using monoos.src.Render.LocationRenderers;

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
            new GoToJailLocationRender(this, board.render.Squares[square], board.textures).RenderLocation();
        }
    }
}
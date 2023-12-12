using monoos.src.Render.LocationRenderers;
using Raylib_cs;

namespace monoos.src.Game.EventLocations
{
    public class CommunityLocation : EventLocation
    {
        private Texture2D chestTex;

        public CommunityLocation(string name, int square) : base(name, square)
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
            new CommunityChestRender(this, board.render.Squares[square], board.textures).RenderLocation();
        }
    }
}
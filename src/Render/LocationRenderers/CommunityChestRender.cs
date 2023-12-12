using monoos.src.Game.EventLocations;
using monoos.src.Render.BaseRenders;
using Raylib_cs;

namespace monoos.src.Render.LocationRenderers
{
    internal class CommunityChestRender(CommunityLocation location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<CommunityLocation>(location, br, textures)
    {
        public override void RenderLocation()
        {
            RenderLocationTitle(locationInfo.square, locationInfo.name);
            LoadMainTexture(locationInfo.square, "CommunityChest");
        }
    }
}
using monoos.src.Game.EventLocations;
using monoos.src.Render.BaseRenders;
using Raylib_cs;

namespace monoos.src.Render.LocationRenderers
{
    internal class ChanceLocationRender(ChanceLocation location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<ChanceLocation>(location, br, textures)
    {
        public override void RenderLocation()
        {
            RenderLocationTitle(locationInfo.square, locationInfo.name);
            if (locationInfo.square == 7)
            {
                LoadMainTexture(locationInfo.square, "Chance1");
            }
            else if (locationInfo.square == 22)
            {
                LoadMainTexture(locationInfo.square, "Chance2");
            }
            else
            {
                LoadMainTexture(locationInfo.square, "Chance3");
            }
        }
    }
}
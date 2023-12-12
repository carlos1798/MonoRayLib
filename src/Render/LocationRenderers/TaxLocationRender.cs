using monoos.src.Game.EventLocations;
using monoos.src.Render.BaseRenders;
using Raylib_cs;

namespace monoos.src.Render.LocationRenderers
{
    public class TaxLocationRender(TaxLocation location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<TaxLocation>(location, br, textures)
    {
        public override void RenderLocation()
        {
            if (location.square == 38)
            {
                LoadMainTexture(locationInfo.square, "SuperTax");
            }
            else
            {
                LoadMainTexture(locationInfo.square, "IncomeTax");
            }
            RenderLocationTitle(locationInfo.square, locationInfo.name);

            RenderLocationPrice(locationInfo.square, locationInfo.Amount);
        }
    }
}
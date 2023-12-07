using monoos.src.Game.PropertiesTypes;
using monoos.src.Render.BaseRenders;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.LocationRenderers
{
    public class UtilityLocationRender(UtilityProperty location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<UtilityProperty>(location, br, textures)
    {
        public override void RenderLocation()
        {
            RenderLocationTitle(locationInfo.square, locationInfo.name);
            if (locationInfo.square == 12)
            {
                LoadMainTexture(locationInfo.square, "Electric");
            }
            else
            {
                LoadMainTexture(locationInfo.square, "Water");
            }
        }
    }
}
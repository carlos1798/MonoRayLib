﻿using monoos.src.Game.PropertiesTypes;
using monoos.src.Render.BaseRenders;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.LocationRenderers
{
    internal class RailRoadPropertyRender(RailRoadProperty locationInfo, BoardRectangle locationRender, Dictionary<string, Texture2D> textures) : ConcreteRender<RailRoadProperty>(locationInfo, locationRender, textures)
    {
        public override void RenderLocation()
        {
            RenderLocationTitle(locationInfo.square, locationInfo.name);
            LoadMainTexture(locationInfo.square, "Train");
            RenderLocationPrice(locationInfo.square, locationInfo.Price);
        }
    }
}
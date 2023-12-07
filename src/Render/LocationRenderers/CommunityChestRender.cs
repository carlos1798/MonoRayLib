﻿using monoos.src.Game.EventLocations;
using monoos.src.Render.BaseRenders;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.LocationRenderers
{
    internal class CommunityChestRender(CommunityLocation location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<CommunityLocation>(location, br, textures)
    {
        public override void RenderLocation()
        {
            LoadMainTexture(locationInfo.square, "CommunityChest");
        }
    }
}
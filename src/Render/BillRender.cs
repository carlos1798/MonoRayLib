using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render
{
    public class BillRender
    {
        public BillRender()
        {
        }

        public void renderBill(Dictionary<String, Texture2D> textures)
        {
            var textKey = "100Bill";
            var texture = textures[textKey];

            float destinyX = 0;
            float destinyY = 0;
            float destinyWidth = 0;
            float destinyHeight = 0;

            int rotation = 0;
            int frameWidth = texture.Width;
            int frameHeight = texture.Height;

            Rectangle textureParms = new(0.0f, 0.0f, frameWidth, frameHeight);

            destinyX = 100;
            destinyY = 100;
            destinyWidth = frameWidth;
            destinyHeight = frameHeight;

            Rectangle textureDestination = new(destinyX, destinyY, destinyWidth, destinyHeight);
            Raylib.DrawTexturePro(texture, textureParms, textureDestination, new Vector2()
            {
                X = 0,
                Y = 0
            }, rotation, Color.WHITE);
        }
    }
}
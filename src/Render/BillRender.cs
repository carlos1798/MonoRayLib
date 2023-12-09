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
        private float billWidth = 250;
        private float billHeight = 150;

        public BillRender()
        {
        }

        public void renderBill(Dictionary<String, Texture2D> textures, string bill, float x, float y, int rotation)
        {
            var texture = textures[bill];
            int frameWidth = texture.Width;
            int frameHeight = texture.Height;
            Rectangle textureParms = new(0.0f, 0.0f, frameWidth, frameHeight);
            Rectangle textureDestination = new(x, y, billWidth, billHeight);
            Raylib.DrawTexturePro(texture, textureParms, textureDestination, new Vector2()
            {
                X = 0,
                Y = 0
            }, rotation, Color.WHITE);
        }
    }
}
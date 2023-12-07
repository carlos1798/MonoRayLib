using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace monoos.src.Render.BaseRenders
{
    public abstract class ConcreteRender<T>
    {
        public T locationInfo;
        public BoardRectangle locationRender;
        public Texture2D texture;

        protected ConcreteRender(T location, BoardRectangle br)
        {
            this.locationInfo = location;
            this.locationRender = br;
        }

        public abstract void RenderLocation();

        public void LoadTexture(int square)
        {
            int rotation = 0;
            int frameWidth = text.Width;
            int frameHeight = text.Height;

            Rectangle textureParms = new(0.0f, 0.0f, frameWidth, frameHeight);

            Rectangle textureDestination = new(locationRender.x / 2, locationRender.y / 2, locationRender.width, locationRender.height);

            Raylib.DrawTexturePro(text, textureParms, textureDestination, new Vector2()
            {
                X = locationRender.width,
                Y = locationRender.height
            }, 0, Color.SKYBLUE);
        }

        public string FormatName(string input)
        {
            var regex = new Regex(@"\b[a-zA-Z]+\b");
            input = input.Replace(" ", "\n");
            var result = regex.Replace(input, m =>
            {
                var word = m.Value;
                if (word.Length > 8)
                {
                    return word.Insert(word.Length - (word.Length - 7), "-\n");
                }
                else
                {
                    return word;
                }
            });
            return result;
        }
    }
}
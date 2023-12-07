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
        public Dictionary<String, Texture2D> textures;
        public Texture2D texture;

        protected ConcreteRender(T location, BoardRectangle br, Dictionary<string, Texture2D> textures)
        {
            this.locationInfo = location;
            this.locationRender = br;
            this.textures = textures;
        }

        public abstract void RenderLocation();

        public void LoadMainTexture(int square, string textKey)
        {
            var texture = textures[textKey];
            float destinyX = 0;
            float destinyY = 0;
            float destinyWidth = 0;
            float destinyHeight = 0;

            int rotation = 0;
            int frameWidth = texture.Width;
            int frameHeight = texture.Height;

            Rectangle textureParms = new(0.0f, 0.0f, frameWidth, frameHeight);

            destinyWidth = locationRender.width / 2;
            destinyHeight = locationRender.height / 2;

            if (square > 0 && square <= 9)
            {
                destinyX = (locationRender.x + locationRender.width) + (locationRender.width / 4);
                destinyY = (locationRender.y + locationRender.height) + (locationRender.height / 2) - (locationRender.Outline * 5);
                rotation = 0;
            }
            else if (square > 10 && square <= 19)
            {
                destinyX = locationRender.x + locationRender.Outline * 2;

                destinyY = locationRender.y + locationRender.height + (locationRender.Outline * 9);
                destinyWidth = locationRender.height / 2;
                destinyHeight = locationRender.width / 2;

                rotation = 90;
            }
            else if (square > 20 && square <= 29)
            {
                destinyX = locationRender.x - (locationRender.Outline * 3);
                destinyY = (locationRender.y - locationRender.height) + (locationRender.height / 2) + (locationRender.Outline * 5);
                rotation = 180;
            }
            else if (square > 30 && square <= 39)
            {
                destinyX = (locationRender.x + locationRender.width) - (locationRender.Outline);
                destinyY = locationRender.y - locationRender.height / 2 - (locationRender.Outline * 3);
                destinyWidth = locationRender.height / 2;
                destinyHeight = locationRender.width / 2;
                rotation = 270;
            }

            Rectangle textureDestination = new(destinyX, destinyY, destinyWidth, destinyHeight);
            Raylib.DrawTexturePro(texture, textureParms, textureDestination, new Vector2()
            {
                X = locationRender.width,
                Y = locationRender.height
            }, rotation, Color.WHITE);
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
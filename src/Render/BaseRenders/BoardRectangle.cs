using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.BaseRenders
{
    public class BoardRectangle()
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public Color color;
        public int Outline = 0;

        public BoardRectangle(int x, int y, int width, int height, Color color, int outline) : this()
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
            Outline = outline;
        }

        public void RenderRec()
        {
            if (Outline != 0)
            {
                Raylib.DrawRectangle(x, y, width, height, Color.BLACK);
            }

            Raylib.DrawRectangle(x + Outline / 2, y + Outline / 2, width - Outline, height - Outline, color);
        }
    };
}
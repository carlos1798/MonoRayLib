using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.Interface
{
    public class PlayerScore
    {
        public PlayerScore()
        {
        }

        public void DrawPlayerMoney()
        {
            Rectangle rec = new Rectangle(100, 100, 200, 100);

            Raylib.DrawRectangleRounded(rec, 0.09f, 1, new Color(100, 100, 100, 180));
            Raylib.DrawRectangleRoundedLines(rec, 0.1f, 1, 10, Color.DARKGREEN);
        }
    }
}
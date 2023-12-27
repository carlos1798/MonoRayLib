using monoos.src.Game;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render
{
    public class PlayerUIRender
    {
        private Player player;
        private Settings settings;

        public Rectangle RollDicesRec;
        public Rectangle BuyPropRec;

        public PlayerUIRender(Player player, Settings settings)
        {
            this.player = player;
            this.settings = settings;
            RollDicesRec = new(settings.ScreenWidth / 2 - 100, 850, 200, 100);
            BuyPropRec = new(100, 850, 200, 100);
        }

        public void RenderMoney()
        {
            Raylib.DrawText($"Current Player:{player.name}", 1200, 200, 20, Color.RED);
            Raylib.DrawText($"Current Square:{player.render.CurrentSquare}", 1200, 100, 20, Color.RED);
            Raylib.DrawText($"Dice  :{player.dices.DiceNumber1} Dice  : {player.dices.DiceNumber2}", 1200, 150, 20, Color.RED);
        }

        public void RenderRollDices()
        {
            Raylib.DrawRectangleRec(RollDicesRec, Color.LIGHTGRAY);
            Raylib.DrawRectangleLinesEx(RollDicesRec, 5, Color.RED);
            Raylib.DrawText($"ROLL DICES", (int)(RollDicesRec.X + 40), (int)(RollDicesRec.Y + RollDicesRec.Height / 2 - 10), 20, Color.RED);
        }

        public void RenderBuyRec()
        {
            Raylib.DrawRectangleRec(BuyPropRec, Color.LIGHTGRAY);
            Raylib.DrawRectangleLinesEx(BuyPropRec, 5, Color.RED);
            Raylib.DrawText($"BUY PROPERTY", (int)(BuyPropRec.X + 20), (int)(BuyPropRec.Y + BuyPropRec.Height / 2 - 10), 20, Color.RED);
        }
    }
}
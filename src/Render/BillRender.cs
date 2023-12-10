using monoos.src.Game;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render
{
    public class BillRender
    {
        private float billWidth = 250;
        private float billHeight = 150;
        private bool canHold = true;
        private Bill holdedBill;

        public BillRender()
        {
        }

        public void renderAllBills(List<Player> players, Dictionary<String, Texture2D> textures)
        {
            int rotation = 0;
            foreach (Player p in players)
            {
                foreach (Bill bill in p.wallet)
                {
                    renderBill(textures, bill, rotation);
                }
                rotation += 90;
            }
        }

        public void renderBill(Dictionary<String, Texture2D> textures, Bill bill, int rotation)
        {
            var texture = textures[bill.spriteName];
            int frameWidth = texture.Width;
            int frameHeight = texture.Height;
            Rectangle textureParms = new(0.0f, 0.0f, frameWidth, frameHeight);
            Raylib.DrawTexturePro(texture, textureParms, bill.rec, new Vector2()
            {
                X = 0,
                Y = 0
            }, rotation, Color.WHITE);
        }

        public void HoldBill(Bill bill, Camera2D camera)
        {
            Vector2 mousePosition = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), camera);
            if (Raylib.CheckCollisionPointRec(mousePosition, bill.rec) && Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                if (holdedBill is null)
                {
                    holdedBill = bill;
                }

                if (bill != holdedBill)
                {
                    return;
                }

                bill.moveStartPoint = true;
            }
            else if (Raylib.CheckCollisionPointRec(mousePosition, bill.rec) && Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                if (holdedBill is null)
                {
                    holdedBill = bill;
                }

                bill.moveEndPoint = true;
            }
            if (bill.moveStartPoint)
            {
                bill.startPoint = mousePosition;
                if (Raylib.IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    bill.moveStartPoint = false;
                    holdedBill = null;
                }
                bill.rec.X = bill.startPoint.X;
                bill.rec.Y = bill.startPoint.Y;
            }

            if (bill.moveEndPoint)
            {
                bill.endPoint = mousePosition;
                if (Raylib.IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    bill.moveEndPoint = false;
                    holdedBill = null;
                }
                bill.rec.X = bill.endPoint.X;
                bill.rec.Y = bill.endPoint.Y;
            }
        }

        public void SpawnStartingBills(List<Player> players)
        {
            int deviation = 50;
            foreach (Player player in players)
            {
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.ONE, player, 100, 100 + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.ONE, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.ONE, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.ONE, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.ONE, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));

                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE, player, 500, 500));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));

                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TEN, player, 600, 600));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TEN, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TEN, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TEN, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TEN, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));

                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TWENTY, player, 700, 600));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TWENTY, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TWENTY, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TWENTY, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.TWENTY, player, player.wallet.Last().position.X + 100, player.wallet.Last().position.Y + deviation));
            }
        }
    }
}
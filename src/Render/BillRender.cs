using monoos.src.Game;
using Raylib_cs;
using System.Numerics;

namespace monoos.src.Render
{
    public class BillRender
    {
        private float billWidth = 250;
        private float billHeight = 150;
        private bool canHold = true;
        public Bill holdedBill;
        private Board board;

        public BillRender(Board board)
        {
        }

        public void renderAllBills(List<Player> players, Dictionary<String, Texture2D> textures)
        {
            int rotation = 0;
            foreach (Player p in players)
            {
                foreach (Bill bill in p.wallet)
                {
                    if (p.position == Player.PlayerPosition.BOTTOM || p.position == Player.PlayerPosition.TOP)
                    {
                        renderBill(textures, bill, 0);
                    }
                    else
                    {
                        renderBill(textures, bill, rotation);
                    }
                }
            }
        }

        public void renderBill(Dictionary<String, Texture2D> textures, Bill bill, int rotation)
        {
            var texture = textures[bill.spriteName];
            int frameWidth = texture.Width;
            int frameHeight = texture.Height;
            Rectangle textureParms = new(0.0f, 0.0f, frameWidth, frameHeight);
            //            Raylib.DrawTexturePro(texture, textureParms, bill.rec, new Vector2()
            //            {
            //                X = 0,
            //                Y = 0
            //            }, rotation, Color.WHITE);

            Raylib.DrawTextureRec(texture, bill.rec, new Vector2() { X = bill.rec.X, Y = bill.rec.Y, }, Color.WHITE);
        }

        public void HoldBill(Bill bill, Camera2D camera, Player player)
        {
            Vector2 mousePosition = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), camera);
            if (Raylib.CheckCollisionPointRec(mousePosition, bill.rec) && Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                if (holdedBill is null)
                {
                    holdedBill = bill;
                    player.wallet.Remove(bill);
                    player.wallet.Add(bill);
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
                    player.wallet.Remove(bill);
                    player.wallet.Add(bill);
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
                player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.ONE, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                for (int i = 0; i < 5; i++)
                {
                    if (player.position == Player.PlayerPosition.BOTTOM)
                    {
                        player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE_HUNDRED, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                    }
                    else if (player.position == Player.PlayerPosition.RIGHT)
                    {
                        player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE_HUNDRED, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                    }
                    else if (player.position == Player.PlayerPosition.LEFT)
                    {
                        player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE_HUNDRED, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                    }
                    else if (player.position == Player.PlayerPosition.TOP)
                    {
                        player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE_HUNDRED, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                    }
                }
                //                for (int i = 0; i < 5; i++)k
                //                {
                //                    player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE_HUNDRED, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                //                }
                //                for (int i = 0; i < 5; i++)
                //                {
                //                    player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE_HUNDRED, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                //                }
                //                for (int i = 0; i < 5; i++)
                //                {
                //                    player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE_HUNDRED, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                //                }
                //                for (int i = 0; i < 5; i++)
                //                {
                //                    player.wallet.Add(new(Raylib.GetRandomValue(0, 1000), Bill.BillType.FIVE_HUNDRED, player, player.PlayerSpace.X, player.PlayerSpace.Y));
                //                }
            }
        }
    }
}
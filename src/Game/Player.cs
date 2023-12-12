using monoos.src.Game.Interfaces;
using monoos.src.Render;
using Raylib_cs;
using System.Numerics;

namespace monoos.src.Game
{
    public class Player
    {
        public enum PlayerAction
        {
            BUY_PROPERTY,
            ROLL_DICE,
            BUY_BUILDING
        }

        public enum PlayerPosition
        {
            TOP = 180,
            RIGHT = 270,
            LEFT = 90,
            BOTTOM = 0
        }

        public string name;
        private double money;
        public List<IProperty> properties;
        public PlayerRender render;
        public bool isTurn = false;
        public Dices dices;
        public bool Bankrupt = false;
        public List<Bill> wallet = new();
        public PlayerPosition position;
        private Camera2D camera;
        private Board board;
        private Settings settings;

        private Color color;

        public Player(string name, double money, PlayerPosition position, Board board, Settings settings)
        {
            this.name = name;
            this.money = 1500;
            this.properties = new();
            properties = new();
            this.position = position;
            this.board = board;
            this.settings = settings;
            render = new(settings, board.render);
            camera = ConfigPlayerCam();
        }

        public void SetPlayerCamera(ref Camera2D mainCam)
        {
            mainCam = camera;
        }

        public Camera2D ConfigPlayerCam()
        {
            Camera2D camera = new Camera2D();
            camera.Target = new Vector2() { X = board.render.Xcenter + settings.OutlineSize * 2, Y = board.render.Ycenter + settings.OutlineSize * 4 };
            camera.Offset = new Vector2() { X = settings.ScreenWidth / 2.0f, Y = settings.ScreenHeight / 2.0f };
            camera.Rotation = (float)position;
            camera.Zoom = 1.0f;
            return camera;
        }

        public bool Turn(PlayerAction action, Board board, ref Camera2D camera)
        {
            if (!this.isTurn)
            {
                return false;
            }
            else
            {
                SetPlayerCamera(ref camera);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_COMMA))
            {
                dices.RollDices();
                this.render.SetDiceResult(dices.DiceNumber1 + dices.DiceNumber2);

                isTurn = false;
                return true;
            }
            return false;
            //            switch (action)
            //            {
            //                case PlayerAction.BUY_PROPERTY:
            //
            //                    if (board.GetLocationBySquare(render.CurrentSquare) is PropertyLocation)
            //                    {
            //                        var Property = (PropertyLocation)board.GetLocationBySquare(render.CurrentSquare);
            //                        if (Property.owner is null)
            //                        {
            //                            Console.WriteLine("comprable");
            //                            Property.BuyProperty(this);
            //                        }
            //                    }; break;
            //
            //                default:
            //                    break;
            //            }
        }
    }
}
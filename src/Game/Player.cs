using monoos.src.Game.Interfaces;
using monoos.src.Render;
using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;

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
        private bool moving = false;
        private bool ActionPerformed = false;

        public Color color;

        public Player(string name, double money, PlayerPosition position, Board board, Settings settings, Color color)
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
            dices = new(settings);
            this.color = color;
        }

        public void SetPlayerCamera(ref Camera2D mainCam)
        {
            mainCam = camera;
            followPlayer(ref mainCam);
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

        public void followPlayer(ref Camera2D camera)
        {
            if (!this.render.isInTargetSquare() && this.isTurn)
            {
                camera.Target = this.render.Position;
            }
        }

        public bool isPlayerMoving()
        {
            return !this.render.isInTargetSquare();
        }

        public bool Turn(PlayerAction action, Board board, ref Camera2D camera, ref GameFlow game)
        {
            if (!this.isTurn)
            {
                return false;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                dices.RollDices();
                this.render.SetDiceResult(dices.DiceNumber1 + dices.DiceNumber2);
                ActionPerformed = true;
            }

            if (isPlayerMoving() && ActionPerformed)
            {
                this.followPlayer(ref camera);
                return false;
            }
            else
            {
                if (ActionPerformed)
                {
                    game.setTurn();
                    ActionPerformed = false;
                    return true;
                }
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
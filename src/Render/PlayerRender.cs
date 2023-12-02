using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render
{
    internal class PlayerRender
    {
        private Settings settings;
        private BoardRenderer board;

        public int CurrentSquare = 0;

        public int TargetSquare = 0;

        private Vector2 Speed = new() { X = 5, Y = 5 };

        public Vector2 Position;

        public PlayerRender(Settings settings, BoardRenderer board)
        {
            this.settings = settings;
            this.board = board;
        }

        public void RenderPlayer()
        {
            Raylib.DrawCircleV(Position, 11, Color.BLACK);
        }

        public void GetPosition()
        {
            Position = new Vector2() { X = board.Squares[CurrentSquare].x + board.Squares[CurrentSquare].width / 2, Y = board.Squares[CurrentSquare].y + board.Squares[CurrentSquare].width / 2 };
        }

        public void MoveOneLeft()
        {
            Vector2 newPosition = new Vector2() { X = board.Squares[CurrentSquare + 1].x + board.Squares[CurrentSquare + 1].width / 2, Y = board.Squares[CurrentSquare + 1].y + board.Squares[CurrentSquare + 1].width / 2 };
            if (newPosition.X >= Position.X)
            {
                CurrentSquare += 1;
                return;
            }
            Position = new Vector2() { X = Position.X - Speed.X, Y = Position.Y };
        }

        public void MoveOneRight()
        {
            Vector2 newPosition = new Vector2() { X = board.Squares[CurrentSquare + 1].x + board.Squares[CurrentSquare + 1].width / 2, Y = board.Squares[CurrentSquare + 1].y + board.Squares[CurrentSquare + 1].width / 2 };
            Raylib.DrawCircleV(newPosition, 11, Color.VIOLET);
            if (newPosition.X <= Position.X)
            {
                CurrentSquare += 1;
                return;
            }
            Position = new Vector2() { X = Position.X + Speed.X, Y = Position.Y };
        }

        public void MoveOneUp()
        {
            Vector2 newPosition = new Vector2() { X = board.Squares[CurrentSquare + 1].x + board.Squares[CurrentSquare + 1].width / 2, Y = board.Squares[CurrentSquare + 1].y + board.Squares[CurrentSquare + 1].height / 2 };
            Raylib.DrawCircleV(newPosition, 11, Color.BLUE);
            if (newPosition.Y >= Position.Y)
            {
                CurrentSquare += 1;
                return;
            }
            Position = new Vector2() { X = Position.X, Y = Position.Y - Speed.Y };
        }

        public void MoveOneDown()
        {
            Vector2 newPosition = new Vector2() { X = board.Squares[CurrentSquare + 1].x + board.Squares[CurrentSquare + 1].width / 2, Y = board.Squares[CurrentSquare + 1].y + board.Squares[CurrentSquare + 1].height / 2 };

            Raylib.DrawCircleV(newPosition, 11, Color.ORANGE);
            if (newPosition.Y < Position.Y)
            {
                CurrentSquare += 1;
                return;
            }
            Position.Y = Position.Y + Speed.Y;
        }

        public void GoToTargetSquare()

        {
            if (CurrentSquare != TargetSquare)
            {
                if (CurrentSquare >= 10 && CurrentSquare <= 19)
                {
                    MoveOneUp();
                }
                else if (CurrentSquare <= 10)
                {
                    MoveOneLeft();
                }
                else if (CurrentSquare >= 20 && CurrentSquare <= 29)
                {
                    MoveOneRight();
                }
                else if (CurrentSquare >= 30 && CurrentSquare < 39)
                {
                    MoveOneDown();
                }

                if (CurrentSquare == 39)
                {
                    GoToStart();
                }
            }
        }

        public void GoToStart()
        {
            Vector2 newPosition = new Vector2() { X = board.Squares[1].x + board.Squares[1].width / 2, Y = board.Squares[1].y + board.Squares[1].height / 2 };

            Raylib.DrawCircleV(newPosition, 11, Color.BLACK);
            if (newPosition.Y < Position.Y)
            {
                CurrentSquare = 0;
                return;
            }
            Position.Y = Position.Y + Speed.Y;
        }
    }
}
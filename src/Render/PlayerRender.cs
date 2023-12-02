using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render
{
    internal class PlayerRender
    {
        private Settings settings;
        private BoardRenderer board;

        public int CurrentSquare = 1;
        public int TargetSquare = 1;

        private Vector2 Speed = new() { X = 10, Y = 10 };

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

            if (newPosition.X >= Position.X)
            {
                CurrentSquare += 1;
                return;
            }
            Position = new Vector2() { X = Position.X + Speed.X, Y = Position.Y };
        }

        public void MoveOneUp()
        {
            Vector2 newPosition = new Vector2() { X = board.Squares[CurrentSquare + 1].x + board.Squares[CurrentSquare + 1].width / 2, Y = board.Squares[CurrentSquare + 1].y + board.Squares[CurrentSquare + 1].height / 2 };

            Raylib.DrawCircleV(newPosition, 11, Color.BLACK);
            if (newPosition.Y >= Position.Y)
            {
                CurrentSquare += 1;
                return;
            }
            Position = new Vector2() { X = Position.X, Y = Position.Y - Speed.Y };
        }

        public void MoveOneDown()
        {
            Vector2 newPosition = new Vector2() { X = board.Squares[CurrentSquare + 1].x + board.Squares[CurrentSquare + 1].width / 2, Y = board.Squares[CurrentSquare + 1].y + board.Squares[CurrentSquare + 1].width / 2 };
            if (newPosition.Y >= Position.Y)
            {
                CurrentSquare += 1;
                return;
            }
            Position = new Vector2() { X = Position.X, Y = Position.Y + Speed.Y };
        }

        public void GoToTargetSquare()
        {
            if (CurrentSquare != TargetSquare)
            {
                if (CurrentSquare >= 9 && CurrentSquare < 18)
                {
                    MoveOneUp();
                }
                else if (CurrentSquare <= 9)
                {
                    MoveOneLeft();
                }
                else if (CurrentSquare >= 18 && CurrentSquare < 32)
                {
                    MoveOneRight();
                }
                else if (CurrentSquare >= 32 && CurrentSquare < 42)
                {
                    MoveOneDown();
                }
            }
        }
    }
}
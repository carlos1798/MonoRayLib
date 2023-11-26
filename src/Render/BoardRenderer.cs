using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using monoos.src.Render;
using Raylib_cs;

namespace monoos;

public class BoardRenderer
{
    private Settings setting;

    private int BoardHeight;
    private int BoardWidth;
    private int BoardPosX;
    private int BoardPosY;

    private const int RoadWidth = 250; //px

    private int DivRoadWidth = RoadWidth / 2;

    public BoardRectangle mainBoard;
    public BoardRectangle roadBoard;
    public BoardRectangle ParkingSquare;
    public BoardRectangle GoToJailSquare;
    public BoardRectangle StartSquare;
    public BoardRectangle JailSquare;

    public record BoardRectangle(int x, int y, int width, int height, Color color, int Outline = 0)
    {
        public void RenderRec()
        {
            if (Outline != 0)
            {
                Raylib.DrawRectangle(x, y, width, height, Color.BLACK);
            }

            Raylib.DrawRectangle(x + Outline / 2, y + Outline / 2, width - Outline, height - Outline, color);
        }
    };

    public BoardRenderer(Settings setting)
    {
        this.setting = setting;
    }

    public void SetBoardParams()
    {
        int smallDimmension = Math.Min(setting.CenterX, setting.CenterY);

        BoardHeight = setting.BoardHeight;
        BoardWidth = setting.BoardWidth;

        BoardPosX = setting.CenterX - BoardHeight / 2;
        BoardPosY = setting.CenterY - BoardHeight / 2;

        mainBoard = new(BoardPosX,
                        BoardPosY,
                        BoardWidth,
                        BoardHeight,
                        Color.WHITE,
                        setting.OutlineSize);

        roadBoard = new(mainBoard.x + DivRoadWidth,
                        mainBoard.y + DivRoadWidth,
                        mainBoard.width - RoadWidth,
                        mainBoard.height - RoadWidth,
                        Color.YELLOW,
                        setting.OutlineSize);

        ParkingSquare = new(mainBoard.x,
                            mainBoard.y,
                            DivRoadWidth + setting.OutlineSize / 2,
                            DivRoadWidth + setting.OutlineSize / 2,
                            Color.LIME,
                            setting.OutlineSize);

        GoToJailSquare = new(roadBoard.x + roadBoard.width - setting.OutlineSize / 2,
                             mainBoard.y,
                             DivRoadWidth + setting.OutlineSize / 2,
                             DivRoadWidth + setting.OutlineSize / 2,
                             Color.RED,
                             setting.OutlineSize);

        StartSquare = new(roadBoard.x + roadBoard.width - setting.OutlineSize / 2,
                             roadBoard.y + roadBoard.height - setting.OutlineSize / 2,
                             DivRoadWidth + setting.OutlineSize / 2,
                             DivRoadWidth + setting.OutlineSize / 2,
                             Color.BLUE,
                             setting.OutlineSize);
        JailSquare = new(mainBoard.x,
                            roadBoard.y + roadBoard.height - setting.OutlineSize / 2,
                            DivRoadWidth + setting.OutlineSize / 2,
                            DivRoadWidth + setting.OutlineSize / 2,
                            Color.ORANGE,
                            setting.OutlineSize);
    }

    internal void Draw()
    {
        SetBoardParams();

        mainBoard.RenderRec();

        roadBoard.RenderRec();
        ParkingSquare.RenderRec();
        GoToJailSquare.RenderRec();
        StartSquare.RenderRec();
        JailSquare.RenderRec();
        DrawTopLocations();
        DrawBottomLocations();
        DrawLeftLocations();
        DrawRightLocations();
    }

    internal void SetBigSquaresParams()
    {
        //BoardRectangle fi = new BoardRectangle();
    }

    internal void DrawTopLocations()
    {
        int propertyPos = roadBoard.width / 9 - setting.OutlineSize / 2 + 2;
        int NewPos = roadBoard.x + propertyPos + (setting.OutlineSize / 2);

        for (int i = 1; i < 9; i++)
        {
            if (i == 4)
            {
                propertyPos += 3;
            }
            {
                new BoardRectangle(NewPos, roadBoard.y + roadBoard.height - setting.OutlineSize / 2, propertyPos + setting.OutlineSize / 2, DivRoadWidth + setting.OutlineSize / 2, Color.WHITE, setting.OutlineSize).RenderRec();

                NewPos += propertyPos;
            }

            //   Raylib.DrawCircle(mainBoard.x + mainBoard.width, roadBoard.y + roadBoard.height + RoadWidth / 2, 5, Color.PURPLE);
            //   Raylib.DrawCircle(mainBoard.x + mainBoard.width, roadBoard.y + roadBoard.height, 5, Color.RED);
        }
    }

    internal void DrawBottomLocations()
    {
        int propertyPos = roadBoard.width / 9 - setting.OutlineSize / 2 + 2;
        int NewPos = roadBoard.x + propertyPos + (setting.OutlineSize / 2);

        for (int i = 1; i < 9; i++)
        {
            if (i == 4)
            {
                propertyPos += 3;
            }
            {
                new BoardRectangle(NewPos, mainBoard.y, propertyPos + setting.OutlineSize / 2, DivRoadWidth + setting.OutlineSize / 2, Color.WHITE, setting.OutlineSize).RenderRec();

                NewPos += propertyPos;
            }

            //   Raylib.DrawCircle(mainBoard.x + mainBoard.width, roadBoard.y + roadBoard.height + RoadWidth / 2, 5, Color.PURPLE);
            //   Raylib.DrawCircle(mainBoard.x + mainBoard.width, roadBoard.y + roadBoard.height, 5, Color.RED);
        }
    }

    internal void DrawLeftLocations()
    {
        int propertyPos = roadBoard.width / 9 - setting.OutlineSize / 2 + 2;
        int NewPos = roadBoard.y + propertyPos + (setting.OutlineSize / 2);

        for (int i = 1; i < 9; i++)
        {
            if (i == 4)
            {
                propertyPos += 3;
            }
            {
                new BoardRectangle(mainBoard.x,
                                   NewPos,
                                   DivRoadWidth + setting.OutlineSize / 2,
                                   propertyPos + setting.OutlineSize / 2,
                                   Color.WHITE,
                                   setting.OutlineSize).RenderRec();

                NewPos += propertyPos;
            }

            //   Raylib.DrawCircle(mainBoard.x + mainBoard.width, roadBoard.y + roadBoard.height + RoadWidth / 2, 5, Color.PURPLE);
            //   Raylib.DrawCircle(mainBoard.x + mainBoard.width, roadBoard.y + roadBoard.height, 5, Color.RED);
        }
    }

    internal void DrawRightLocations()
    {
        int propertyPos = roadBoard.width / 9 - setting.OutlineSize / 2 + 2;
        int NewPos = roadBoard.y + propertyPos + (setting.OutlineSize / 2);

        for (int i = 1; i < 9; i++)
        {
            if (i == 4)
            {
                propertyPos += 3;
            }
            {
                new BoardRectangle(roadBoard.x + roadBoard.width - setting.OutlineSize / 2,
                                   NewPos,
                                   DivRoadWidth + setting.OutlineSize / 2,
                                   propertyPos + setting.OutlineSize / 2,
                                   Color.WHITE,
                                   setting.OutlineSize).RenderRec();

                NewPos += propertyPos;
            }

            //   Raylib.DrawCircle(mainBoard.x + mainBoard.width, roadBoard.y + roadBoard.height + RoadWidth / 2, 5, Color.PURPLE);
            //   Raylib.DrawCircle(mainBoard.x + mainBoard.width, roadBoard.y + roadBoard.height, 5, Color.RED);
        }
    }
}
using System.ComponentModel.Design;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using monoos.src.Render;
using monoos.src.Render.LocationRenderers;
using Raylib_cs;
using Color = Raylib_cs.Color;

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
    private Color mainColor = new Color(204, 233, 209, 255);

    public BoardRectangle mainBoard;
    public BoardRectangle roadBoard;
    public BoardRectangle ParkingSquare;
    public BoardRectangle GoToJailSquare;
    public BoardRectangle StartSquare;
    public BoardRectangle JailSquare;
    public Dictionary<int, BoardRectangle> Squares = new();
    public float Xcenter;
    public float Ycenter;

    public BoardRenderer(Settings setting)
    {
        this.setting = setting;
    }

    public void SetBoardParams()
    {
        BoardHeight = setting.BoardHeight;
        BoardWidth = setting.BoardWidth;

        BoardPosX = 30;// setting.CenterX - BoardHeight / 2;
        BoardPosY = 50;// setting.CenterY - BoardHeight / 2;

        mainBoard = new(BoardPosX,
                       BoardPosY,
                       BoardWidth,
                       BoardHeight,
                       mainColor,
                       setting.OutlineSize);

        roadBoard = new(mainBoard.x + DivRoadWidth,
                              mainBoard.y + DivRoadWidth,
                              mainBoard.width - RoadWidth,
                              mainBoard.height - RoadWidth,
                             mainColor,
                              setting.OutlineSize);

        Squares.Add(20, ParkingSquare = new(mainBoard.x,
                              mainBoard.y,
                              DivRoadWidth + setting.OutlineSize / 2,
                              DivRoadWidth + setting.OutlineSize / 2,
                              Color.LIME,
                              setting.OutlineSize));

        Squares.Add(30, GoToJailSquare = new(roadBoard.x + roadBoard.width - setting.OutlineSize / 2,
                              mainBoard.y,
                              DivRoadWidth + setting.OutlineSize / 2,
                              DivRoadWidth + setting.OutlineSize / 2,
                              Color.RED,
                              setting.OutlineSize));

        Squares.Add(0, StartSquare = new(roadBoard.x + roadBoard.width - setting.OutlineSize / 2,
                                    roadBoard.y + roadBoard.height - setting.OutlineSize / 2,
                                    DivRoadWidth + setting.OutlineSize / 2,
                                    DivRoadWidth + setting.OutlineSize / 2,
                                    Color.BLUE,
                                    setting.OutlineSize));
        Squares.Add(10, JailSquare = new(mainBoard.x,
                              roadBoard.y + roadBoard.height - setting.OutlineSize / 2,
                              DivRoadWidth + setting.OutlineSize / 2,
                              DivRoadWidth + setting.OutlineSize / 2,
                              Color.ORANGE,
                              setting.OutlineSize));

        CalculateAllSquares();
        Xcenter = mainBoard.width / 2;
        Ycenter = mainBoard.height / 2;
    }

    internal void Draw()
    {
        mainBoard.RenderRec();
        roadBoard.RenderRec();

        foreach (KeyValuePair<int, BoardRectangle> Square in Squares)
        {
            if (Square.Value == JailSquare)
            {
            }

            Square.Value.RenderRec();
        }
        Squares[10].RenderRec();
        Squares[0].RenderRec();
        Squares[20].RenderRec();
    }

    private void CalculateAllSquares()
    {
        CalculateBottomLocations();
        CalculateLeftLocations();
        CalculateTopLocations();
        CalculateRightLocations();
    }

    internal void CalculateBottomLocations()
    {
        int propertyPos = roadBoard.width / 9 - setting.OutlineSize / 2 + 2;
        int NewPos = roadBoard.x + propertyPos + (setting.OutlineSize / 2);

        int firstPosition = JailSquare.x + JailSquare.width - setting.OutlineSize / 2;
        for (int i = 1; i < 10; i++)
        {
            if (i == 4)
            {
                propertyPos += 3;
            }
            if (i == 1)
            {
                NewPos = firstPosition;
            }

            {
                Squares.Add(10 - i, new BoardRectangle(NewPos,
                                               roadBoard.y + roadBoard.height - setting.OutlineSize / 2,
                                               propertyPos + setting.OutlineSize / 2,
                                               DivRoadWidth + setting.OutlineSize / 2,
                                                mainColor,
                                               setting.OutlineSize));

                NewPos += propertyPos;
            }
        }
    }

    internal void CalculateTopLocations()
    {
        int propertyPos = roadBoard.width / 9 - setting.OutlineSize / 2 + 2;
        int NewPos = roadBoard.x + propertyPos + (setting.OutlineSize / 2);
        int firstPosition = ParkingSquare.x + ParkingSquare.width - setting.OutlineSize / 2;
        for (int i = 1; i < 10; i++)
        {
            if (i == 4)
            {
                propertyPos += 3;
            }
            if (i == 1)
            {
                NewPos = firstPosition;
            }

            {
                Squares.Add(20 + i, new BoardRectangle(NewPos,
                                                  mainBoard.y,
                                                  propertyPos + setting.OutlineSize / 2,
                                                  DivRoadWidth + setting.OutlineSize / 2,
                                                  mainColor,
                                                  setting.OutlineSize));

                NewPos += propertyPos;
            }
        }
    }

    internal void CalculateLeftLocations()
    {
        int propertyPos = roadBoard.width / 9 - setting.OutlineSize / 2 + 2;
        int NewPos = roadBoard.y + propertyPos + (setting.OutlineSize / 2);
        int firstPosition = ParkingSquare.y + ParkingSquare.height - setting.OutlineSize / 2;

        for (int i = 1; i < 10; i++)
        {
            if (i == 5)
            {
                propertyPos += 4;
            }
            if (i == 1)
            {
                NewPos = firstPosition;
            }

            {
                Squares.Add(20 - i, new BoardRectangle(mainBoard.x,
                                   NewPos,
                                   DivRoadWidth + setting.OutlineSize / 2,
                                   propertyPos + setting.OutlineSize / 2,
                                   mainColor,
                                   setting.OutlineSize));

                NewPos += propertyPos;
            }
        }
    }

    internal void CalculateRightLocations()
    {
        int propertyPos = roadBoard.width / 9 - setting.OutlineSize / 2 + 2;
        int NewPos = roadBoard.y + propertyPos + (setting.OutlineSize / 2);
        int firstPosition = GoToJailSquare.y + GoToJailSquare.height - setting.OutlineSize / 2;

        for (int i = 1; i < 10; i++)
        {
            if (i == 4)
            {
                propertyPos += 3;
            }
            if (i == 1)
            {
                NewPos = firstPosition;
            }

            {
                Squares.Add(30 + i, new BoardRectangle(roadBoard.x + roadBoard.width - setting.OutlineSize / 2,
                                   NewPos,
                                   DivRoadWidth + setting.OutlineSize / 2,
                                   propertyPos + setting.OutlineSize / 2,
                                   mainColor,
                                   setting.OutlineSize));

                NewPos += propertyPos;
            }
        }
    }
}
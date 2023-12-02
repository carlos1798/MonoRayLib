using monoos.src.Render;
using Raylib_cs;
using System.Numerics;

namespace monoos;

public class MainRender
{
    public Settings setting;
    private BoardRenderer board;
    private List<PlayerRender> players = new();
    private bool firstTime = true;

    public MainRender(Settings settings)
    {
        this.setting = settings;
        this.board = new(setting);
    }

    public void init()
    {
        board.SetBoardParams();
        players.Add(new(setting, board));

        Raylib.InitWindow(setting.ScreenWidth, setting.ScreenHeight, "Monooo");

        mainLoop();
    }

    public void mainLoop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.SetTargetFPS(30);

            Raylib.ClearBackground(Color.WHITE);
            board.Draw();

            foreach (KeyValuePair<int, BoardRenderer.BoardRectangle> square in board.Squares)
            {
                Raylib.DrawCircleV(new Vector2() { X = square.Value.x + square.Value.width / 2, Y = square.Value.y + square.Value.height / 2 }, 10, Color.GREEN);
            }
            foreach (PlayerRender p in players)
            {
                if (firstTime)
                {
                    p.GetPosition();
                    firstTime = false;
                }

                p.TargetSquare = 30;
                p.GoToTargetSquare();

                p.RenderPlayer();
            }

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
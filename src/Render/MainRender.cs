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
        int rand = 0;
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.SetTargetFPS(60);

            Raylib.ClearBackground(Color.WHITE);
            board.Draw();

            foreach (PlayerRender p in players)
            {
                Raylib.DrawText($"CurrentSquare:{p.CurrentSquare}", 1200, 500, 20, Color.BLUE);
                if (firstTime)
                {
                    p.GetPosition();
                    firstTime = false;
                }
                else
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        Random rnd = new();
                        rand = rnd.Next(1, 12);
                        p.TargetSquare += rand;
                    }

                    Raylib.DrawText($"{rand}", 100, 100, 200, Color.BLUE);
                }
                p.GoToTargetSquare();

                p.RenderPlayer();
            }

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
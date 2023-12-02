using monoos.src.Game;
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
    private Dices dices;

    public MainRender(Settings settings)
    {
        this.setting = settings;
        this.board = new(setting);
    }

    public void init()
    {
        board.SetBoardParams();
        dices = new(setting);
        players.Add(new(setting, board));
        Raylib.InitWindow(setting.ScreenWidth, setting.ScreenHeight, "Monooo");

        mainLoop();
    }

    public void mainLoop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.SetTargetFPS(60);

            Raylib.ClearBackground(Color.WHITE);
            board.Draw();

            foreach (PlayerRender p in players)
            {
                Raylib.DrawText($"Current Square:{p.CurrentSquare}", 1200, 500, 20, Color.BLUE);
                Raylib.DrawText($"Dice  :{dices.DiceNumber1} Dice  : {dices.DiceNumber2}", 1200, 700, 20, Color.BLUE);
                if (firstTime)
                {
                    p.GetPosition();
                    firstTime = false;
                }
                else
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        dices.RollDices();
                        p.SetDiceResult(dices.DiceNumber1 + dices.DiceNumber2);
                    }
                }
                p.GoToTargetSquare();

                p.RenderPlayer();
            }

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
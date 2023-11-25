using Raylib_cs;

namespace monoos;

public class MainRender
{
    public Settings setting;
    private BoardRenderer board;

    public MainRender(Settings settings)
    {
        this.setting = settings;
        this.board = new(setting);
    }

    public void init()
    {
        Raylib.InitWindow(setting.ScreenWidth, setting.ScreenHeight, "Monooo");
        mainLoop();
    }

    public void mainLoop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.WHITE);
            board.Draw();
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
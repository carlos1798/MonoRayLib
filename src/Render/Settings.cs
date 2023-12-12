namespace monoos.src.Render;

public class Settings
{
    private int screenWidth;
    private int screenHeight;

    public int OutlineSize = 8;

    public int NumberOfPlayers = 2;

    public int CenterY;
    public int CenterX;

    public const int fontSize = 10;

    public const int BoardWidth = 1200;
    public const int BoardHeight = 1200;

    public string TexturePath = "\\src\\Resources\\Default\\Textures";
    public const char currency = '$';

    public int ScreenWidth { get => screenWidth; set => screenWidth = value; }
    public int ScreenHeight { get => screenHeight; set => screenHeight = value; }

    public Settings()
    {
        SetDefaultValues();
    }

    private void SetDefaultValues()
    {
        ScreenHeight = 1000;
        ScreenWidth = 1500;
        CenterY = ScreenHeight / 2;
        CenterX = ScreenWidth / 2;
    }
}
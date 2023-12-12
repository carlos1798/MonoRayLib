using monoos.src.Render;

namespace monoos;

internal class Program
{
    private static void Main(string[] args)
    {
        Settings setting = new();
        MainRender main = new(setting);
        main.init();
    }
}
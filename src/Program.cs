using System.Reflection.Metadata;
using monoos.src.Render;
using Raylib_cs;

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
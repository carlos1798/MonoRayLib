using System.Reflection.Metadata;
using Raylib_cs;

namespace monoos;

class Program
{
    static void Main(string[] args)
    {
        Settings setting = new();
        MainRender main = new(setting);
        main.init();

    }
}

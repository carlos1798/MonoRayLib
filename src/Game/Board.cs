using monoos.src;
using monoos.src.Game;
using monoos.src.Render;
using monoos.src.Render.BaseRenders;
using monoos.src.Render.LocationRenderers;
using Raylib_cs;
using System.Runtime.Versioning;

public class Board
{
    public BoardRenderer render;
    public List<Location> locations;
    public Dictionary<String, Texture2D> textures;
    public Loader loader;
    public Settings settings;

    public Board(Settings settings)
    {
        locations = new();
        render = new(settings);
        loader = new(settings);
    }

    public void LoadTextures()
    {
        textures = loader.GetTextures();
    }

    public void LoadLocationInfo()
    {
        locations = loader.LoadBoardInformation();
    }

    public Location GetLocationBySquare(int square)
    {
        return locations[square];
    }

    public void RenderLocations()
    {
        foreach (Location location in locations)
        {
            location.LocationRender(this);
        }
    }
}
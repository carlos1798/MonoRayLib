﻿using Raylib_cs;

namespace monoos.src.Render;

public class Settings
{
    private int screenWidth;
    private int screenHeight;

    public int OutlineSize = 8;

    public int CenterY;
    public int CenterX;

    public int BoardWidth = 894;
    public int BoardHeight = 894;

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
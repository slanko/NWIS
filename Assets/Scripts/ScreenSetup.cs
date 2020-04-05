using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenSetup
{
    public static ScreenPosition[] onePlayer = new ScreenPosition[] { new ScreenPosition(0f, 0f, 1f, 1f) };
    public static ScreenPosition[] twoPlayer = new ScreenPosition[] { new ScreenPosition(0f, 0.5f, 1f, 0.5f), new ScreenPosition(0f, 0f, 1f, 0.5f) };
    public static ScreenPosition[] threePlayer = new ScreenPosition[] { new ScreenPosition(0f, 0.5f, 0.5f, 0.5f), new ScreenPosition(0.5f, 0.5f, 0.5f, 0.5f), new ScreenPosition(0f, 0f, 0.5f, 0.5f) };
    public static ScreenPosition[] fourPlayer = new ScreenPosition[] { new ScreenPosition(0f, 0.5f, 0.5f, 0.5f), new ScreenPosition(0.5f, 0.5f, 0.5f, 0.5f), new ScreenPosition(0f, 0f, 0.5f, 0.5f), new ScreenPosition(0.5f, 0f, 0.5f, 0.5f) };

    public static ScreenPosition[][] playerScreens = new ScreenPosition[][]
    {
        onePlayer,twoPlayer,threePlayer,fourPlayer
    };
}

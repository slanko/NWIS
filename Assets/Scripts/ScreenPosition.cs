using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPosition
{
    public Vector2 position;
    public Vector2 size;

    public ScreenPosition(float xPos,float yPos,float xSize,float ySize)
    {
        position = new Vector2(xPos, yPos);
        size = new Vector2(xSize, ySize);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraSetup : MonoBehaviour
{
    Camera cam;
    public int playerNum;
    void Start()
    {
        if (PlayerData.players.Count > 0)
        {
            ScreenPosition[] positions = ScreenSetup.playerScreens[PlayerData.players.Count - 1];
            ScreenPosition pos = positions[playerNum - 1];
            Rect rect = new Rect(pos.position, pos.size);
            cam = GetComponent<Camera>();
            cam.rect = rect;
        }
    }
}

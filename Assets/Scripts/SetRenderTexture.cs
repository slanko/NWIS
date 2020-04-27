using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderTexture : MonoBehaviour
{
    RenderTexture texture;
    [SerializeField] PixellationLevels pixellationLevels;
    [SerializeField] Material mat;
    [SerializeField] CameraClearFlags off;
    [SerializeField] CameraClearFlags on;
    Camera cam;
    void Awake()
    {
        cam = GetComponent<Camera>();
        Activate();
    }
    public RenderTexture Activate()
    {
        cam.clearFlags = on;
        RenderTexture tempTexture = null;
        if (cam?.targetTexture != null)
            tempTexture = cam.targetTexture;


        int level = PlayerPrefs.GetInt("PixellationLevel", 3);
        if (level > 0)
        {
            texture = new RenderTexture((int)pixellationLevels.levels[level - 1].x, (int)pixellationLevels.levels[level - 1].y, 16, RenderTextureFormat.ARGB32);
        }
        else
        {
            texture = new RenderTexture(Screen.width, Screen.height, 16, RenderTextureFormat.ARGB32);
        }
        texture.filterMode = FilterMode.Point;
        texture.Create();
        cam.targetTexture = texture;
        mat.mainTexture = cam.targetTexture;
        tempTexture?.Release();
        return texture;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PixellationControl : MonoBehaviour
{
    [SerializeField] SetRenderTexture[] cams;
    [SerializeField] RawImage[] images;
    private void Start()
    {
        Activate();
    }
    public void Activate()
    {
            for(int i = 0; i <cams.Length; i++)
            {
                images[i].texture = cams[i].Activate();
                images[i].enabled = true;
            }
    }
}

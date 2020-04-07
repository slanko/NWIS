using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamResize : MonoBehaviour
{
    public Camera mainCam;
    Camera meCam;

    // Start is called before the first frame update
    void Start()
    {
        meCam = gameObject.GetComponent<Camera>();
        meCam.rect = mainCam.rect;
    }
}

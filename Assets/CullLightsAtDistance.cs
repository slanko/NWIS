using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullLightsAtDistance : MonoBehaviour
{
    Camera cam;
    [SerializeField] float distance;
    private void Start()
    {
        cam = GetComponent<Camera>();
        float[] cullDistances = cam.layerCullDistances;
        cullDistances[12] = distance;
        cam.layerCullDistances = cullDistances;
    }
}

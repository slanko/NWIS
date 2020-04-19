using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] Transform cam;

    private void Update()
    {
        transform.LookAt(cam);
    }
}

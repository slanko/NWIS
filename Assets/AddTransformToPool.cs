using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTransformToPool : MonoBehaviour
{
    private void Start()
    {
        CameraTransforms.transforms.Add(transform);
    }
}

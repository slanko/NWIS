using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLodBias : MonoBehaviour
{
    public void Set(float bias)
    {
        QualitySettings.lodBias = bias;
        Debug.LogWarning("setLOD bias to: " + bias);
    }
}

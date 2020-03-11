using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustWeightOnHeight : MonoBehaviour
{
    [SerializeField] TrackSection section;
    private void Start()
    {
        if (TrackGenerator.height > 0)
        {
            section.weight = 100;
        }
        else
        {
            section.weight = 1;
        }
    }
}

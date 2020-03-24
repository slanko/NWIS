using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWalls : MonoBehaviour
{
    private void Start()
    {
        TrackStatus.trackComplete += EnableColliders;
    }

    private void OnDestroy()
    {
        TrackStatus.trackComplete -= EnableColliders;
    }
    public void EnableColliders()
    {
        GetComponent<MeshCollider>().enabled = true;
    }
}

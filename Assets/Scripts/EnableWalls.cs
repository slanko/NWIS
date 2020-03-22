using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWalls : MonoBehaviour
{
    private void Start()
    {
        TrackCompleted.complete += EnableColliders;
    }

    private void OnDestroy()
    {
        TrackCompleted.complete -= EnableColliders;
    }
    public void EnableColliders()
    {
        GetComponent<MeshCollider>().enabled = true;
    }
}

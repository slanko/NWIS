using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPillars : MonoBehaviour
{
    [SerializeField] Transform[] buildPoints;
    [SerializeField] GameObject pillar;

    public void Start()
    {
        TrackCompleted.complete += TrackComplete; 
    }

    private void OnDestroy()
    {
        TrackCompleted.complete -= TrackComplete;
    }
    public void TrackComplete()
    {
        foreach(Transform t in buildPoints)
        {
            if (Physics.BoxCast(t.position, new Vector3(1, 1), Vector3.down * 100))
            {
            }
            else
            {
                Instantiate(pillar, t.position, t.rotation);
            }
            
        }
    }
}

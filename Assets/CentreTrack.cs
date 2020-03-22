using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreTrack : MonoBehaviour
{
    [SerializeField] TrackGenerator trackGen;
    Vector3 targetPos;
    bool completed = false;
    [SerializeField] TrackFollow cam;
    [SerializeField] Transform buildingPos;
    [SerializeField] Transform finishedPos;
    private void Start()
    {
        cam.target = buildingPos;
        TrackCompleted.complete += Finished;
    }
    private void OnDestroy()
    {
        TrackCompleted.complete -= Finished;
    }
    private void Update()
    {
        transform.position = targetPos;
        if(!completed)
            Step();
    }
    void Step()
    {
        targetPos = trackGen.buildPoints[trackGen.buildPoints.Count - 1].transform.position;
    }
    private void Finished()
    {
        cam.target = finishedPos;
        completed = true;
        targetPos = Vector3.zero;
        if (trackGen.buildPoints.Count > 0)
        {
            foreach (GameObject g in trackGen.buildPoints)
            {
                targetPos += g.transform.position;
            }
            targetPos = targetPos / trackGen.buildPoints.Count;   
        }
    }
}

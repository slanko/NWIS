using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public int pieceCount = 20;
    int stepsBack = 0;
    public TrackSection[] sections;
    GameObject origin;
    List<GameObject> buildPoints = new List<GameObject>(); 
    private void Start()
    {
        origin = gameObject;
        StartCoroutine(BuildTrack());
    }
    IEnumerator BuildTrack()
    {
        while (pieceCount>0)
        {
            bool success = false;
            for(int reattempt = 6; reattempt > 0; reattempt--) //Need to put in alternative if fails every time;
            {
                yield return new WaitForSeconds(0.01f);
                int pick = Random.Range(0, sections.Length);
                GameObject oldOrigin = origin;
                origin = sections[pick].CreateSection(origin);
                if (origin != oldOrigin)
                {
                    SuccessfulPlacement();
                    success = true;
                    break;
                }        
            }
            if (!success)
            { 
                StepBack();
            }
        }
    }

    void SuccessfulPlacement()
    {
        if (stepsBack > 0)
            stepsBack--;
        buildPoints.Add(origin);
    }

    void StepBack()
    {
        stepsBack += 2;
        for (int i = stepsBack; i>0; i--)
        {
            GameObject old = buildPoints[buildPoints.Count - 1];
            buildPoints.Remove(old);
            Destroy(old.transform.parent.gameObject);
            origin = buildPoints[buildPoints.Count - 1];
        }
    }
}

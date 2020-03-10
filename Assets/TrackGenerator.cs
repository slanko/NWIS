using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public int pieceCount = 20;
    int stepsBack = 0;
    int stepBackAmount = 0;
    int lastCount = 0;
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
        while (pieceCount > 0)
        {
            bool success = false;
            for (int reattempt = 6; reattempt > 0; reattempt--) //Need to put in alternative if fails every time;
            {
                yield return new WaitForSeconds(0.0001f);
                //int pick = Random.Range(0, sections.Length);
                GameObject oldOrigin = origin;


                origin = GetRandomSection().CreateSection(origin);
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

    public TrackSection GetRandomSection()
    {
        float random = Random.Range(0f, 1f);
        float totalWeight = 0;
        float currentWeight = 0;
        foreach (TrackSection t in sections)
        {
            totalWeight += t.weight;
        }

        foreach (TrackSection t in sections)
        {
            float upper = currentWeight + (t.weight / totalWeight);
            float floor = currentWeight;

            if (random >= floor && random < upper)
            {
                return t;
            }
            currentWeight += t.weight / totalWeight;
        }
        Debug.Log("failed to select a section");
        return null;
    }

    
    void SuccessfulPlacement()
    {
        buildPoints.Add(origin);
        pieceCount--;
        if(lastCount <buildPoints.Count)
        {
            lastCount = buildPoints.Count;
            stepBackAmount = 0;
        }
    }

    void StepBack()
    {
        int dif = (lastCount - buildPoints.Count);
        stepBackAmount+=1;
        int stepsBack = stepBackAmount - dif;
        for (int i = stepsBack; i>0; i--)
        {
            GameObject old = buildPoints[buildPoints.Count - 1];
            buildPoints.Remove(old);
            Destroy(old.transform.parent.gameObject);
            origin = buildPoints[buildPoints.Count - 1];
        }
    }
}

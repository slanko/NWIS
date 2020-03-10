using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public static int height = 0;
    public int pieceCount = 20;
    int stepsBack = 0;
    int stepBackAmount = 0;
    int lastCount = 0;
    public List<TrackSection> sections = new List<TrackSection>();
    public List<TrackSection> escapeSections = new List<TrackSection>();
    public TrackSection start;
    public TrackSection end;
    GameObject origin;
    List<GameObject> buildPoints = new List<GameObject>();
    bool success = false;
    private void Start()
    {
        origin = gameObject;
        Place(start);
        StartCoroutine(BuildTrack());
    }

    IEnumerator BuildTrack()
    {
        while (pieceCount > 0)
        {
            for (int reattempt = 6; reattempt > 0; reattempt--) //Need to put in alternative if fails every time;
            {
                yield return new WaitForSeconds(0.0001f);
                TrackSection sectionToPlace = GetRandomSection();
                success = Place(sectionToPlace);
                if (success)
                {
                    SuccessfulPlacement();
                    break;
                }
            }
            if (!success)
            {
                StepBack();
            }
        }
        Place(end);
    }

    public bool Place(TrackSection piece)
    {
        GameObject oldOrigin = origin;
        origin = piece.CreateSection(origin);
        return origin != oldOrigin ? true : false;
    }

    public TrackSection GetRandomSection()
    {
        List<TrackSection> sectionsToChooseFrom = new List<TrackSection>();
        if(success)
        {
            sectionsToChooseFrom.AddRange(sections);
        }
        else
        {
            sectionsToChooseFrom.AddRange(sections);
            sectionsToChooseFrom.AddRange(escapeSections);
        }

        float random = Random.Range(0f, 1f);
        float totalWeight = 0;
        float currentWeight = 0;
        foreach (TrackSection t in sectionsToChooseFrom)
        {
            totalWeight += t.weight;
        }

        foreach (TrackSection t in sectionsToChooseFrom)
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
            pieceCount++;
            origin = buildPoints[buildPoints.Count - 1];
        }
    }
}

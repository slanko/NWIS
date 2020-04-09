using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TrackGenerator : MonoBehaviour
{
    public AnimationCurve difficulty;
    public static int height = 0;
    public static float progress = 0;
    public int totalSections;
    int pieceCount;
    int stepBackAmount = 0;
    int lastCount = 0;
    public List<TrackSection> sections = new List<TrackSection>();
    public List<TrackSection> upSections = new List<TrackSection>();
    public List<TrackSection> downSections = new List<TrackSection>();
    public TrackSection start;
    public TrackSection end;
    GameObject origin;
    public List<GameObject> buildPoints = new List<GameObject>();
    List<TrackSection> placedSections = new List<TrackSection>();
    bool success = false;
    private void Start()
    {
        pieceCount = totalSections;
        height = 0;
        progress = 0;
        origin = gameObject;
        TrackStatus.readyToGenerate += Begin;
    }
    public void Begin()
    {
        StartCoroutine(BuildTrack());
    }
    private void OnDestroy()
    {
        TrackStatus.readyToGenerate -= Begin;
    }
    IEnumerator BuildTrack()
    {
        while (pieceCount > 0)
        {
            for (int reattempt = 6; reattempt > 0; reattempt--)
            {
                yield return new WaitForSeconds(0.0001f);
                TrackSection sectionToPlace;
                if (pieceCount == 1)
                {
                    sectionToPlace = end;
                }
                else
                {
                    sectionToPlace = GetRandomSection();
                }
                success = Place(sectionToPlace);
                if (success)
                {
                    SuccessfulPlacement(sectionToPlace);
                    break;
                }
            }
            if (!success)
            {
                StepBack();
            }
        }
        TrackStatus.trackComplete();
    }
    public bool Place(TrackSection piece)
    {
        GameObject oldOrigin = origin;
        origin = piece.CreateSection(origin);
        return origin != oldOrigin ? true : false;
    }
    public TrackSection GetRandomSection()
    {
        float currentDifficulty = difficulty.Evaluate((totalSections - pieceCount) / (float)totalSections);
        List<TrackSection> sectionsToChooseFrom = new List<TrackSection>();
        sectionsToChooseFrom.AddRange(sections);
        if (height < 2)
        {
            sectionsToChooseFrom.AddRange(upSections);
        }
        if (height > 0)
        {
            sectionsToChooseFrom.AddRange(downSections);

        }
        float random = Random.Range(0f, 1f);
        float totalWeight = 0;
        float currentWeight = 0;
        foreach (TrackSection t in sectionsToChooseFrom)
        {
            t.likelihood = 1 - Mathf.Abs(t.difficulty - currentDifficulty);
            totalWeight += t.weight * t.likelihood;
        }

        foreach (TrackSection t in sectionsToChooseFrom)
        {
            float upper = currentWeight + (t.weight * t.likelihood / totalWeight);
            float floor = currentWeight;

            if (random >= floor && random < upper)
            {
                return t;
            }
            currentWeight += t.weight * t.likelihood / totalWeight;
        }
        Debug.Log("failed to select a section");
        return null;
    }
    void SuccessfulPlacement(TrackSection section)
    {
        placedSections.Add(section);
        buildPoints.Add(origin);
        pieceCount--;
        if (lastCount < buildPoints.Count)
        {
            lastCount = buildPoints.Count;
            stepBackAmount = 0;
        }
        UpdateProgress();
    }
    void UpdateProgress()
    {
        progress = (float)placedSections.Count / (float)totalSections;
    }
    void StepBack()
    {
        int dif = (lastCount - buildPoints.Count);
        stepBackAmount = Mathf.Clamp(stepBackAmount + 1, 0, 10);
        int stepsBack = stepBackAmount - dif;
        for (int i = stepsBack; i > 0; i--)
        {
            height -= placedSections[placedSections.Count - 1].heightChange;
            placedSections.RemoveAt(placedSections.Count - 1);
            GameObject old = buildPoints[buildPoints.Count - 1];
            buildPoints.Remove(old);
            Destroy(old.transform.parent.gameObject);
            pieceCount++;
            origin = buildPoints[buildPoints.Count - 1];
        }
        UpdateProgress();
    }
}

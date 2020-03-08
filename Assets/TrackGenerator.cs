using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public int iterations = 20;
    public TrackSection[] sections;
    GameObject origin;
    void Start()
    {
        origin = gameObject;   
        for(int i = iterations; i >0; i--)
        {
            for(int reattempt = 8; reattempt > 0; reattempt--) //Need to put in alternative if fails every time;
            {
                int pick = Random.Range(0, sections.Length);
                GameObject oldOrigin = origin;
                origin = sections[pick].CreateSection(origin);
                if (origin != oldOrigin)
                    continue;
            }
            
        }
    }
}

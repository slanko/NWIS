using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public int iterations = 20;
    public TrackSection[] sections;
    GameObject origin;

    private void Start()
    {
        origin = gameObject;
        StartCoroutine(BuildTrack());
    }
    IEnumerator BuildTrack()
    {
        for(int i = iterations; i >0; i--)
        {
            bool success = false;
            for(int reattempt = 8; reattempt > 0; reattempt--) //Need to put in alternative if fails every time;
            {
                yield return new WaitForSeconds(0.1f);
                int pick = Random.Range(0, sections.Length);
                Debug.Log(pick);
                GameObject oldOrigin = origin;
                origin = sections[pick].CreateSection(origin);
                if (origin != oldOrigin)
                {
                    Debug.Log("Built");
                    success = true;
                    break;
                }
                    
            }
            if (!success)
            {
                GameObject parent = origin.transform.parent.gameObject;
                origin = new GameObject();
                origin.transform.position = parent.transform.position;
                origin.transform.rotation = parent.transform.rotation;
                Destroy(parent);
            }
            
        }
    }
}

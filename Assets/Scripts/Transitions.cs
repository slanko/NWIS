using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    RaceStateEvents stateEvents;
    private void Start()
    {
        stateEvents = GameObject.FindGameObjectWithTag("RaceState").GetComponent<RaceStateEvents>();
    }
    public void StartTrackGen()
    {
            TrackStatus.readyToGenerate.Invoke();
    }
    public void StartRace()
    {
        if (stateEvents.startGame.GetPersistentEventCount() > 0)
            stateEvents.startGame.Invoke();
    }
    public void BeginCountdown()
    {
       if(stateEvents.beginCountdown.GetPersistentEventCount()>0)
           stateEvents.beginCountdown.Invoke();
    }
}

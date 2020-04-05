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
        stateEvents.startGame.Invoke();
    }
}

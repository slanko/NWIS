using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLightsScript : MonoBehaviour
{
    public bool raceStarted;
    public void startThaRace()
    {
        raceStarted = true;
        GameObject.FindGameObjectWithTag("RaceState").GetComponent<RaceStateEvents>().beginRace.Invoke();
    }
}

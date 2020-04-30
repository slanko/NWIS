using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLightsScript : MonoBehaviour
{
    public bool raceStarted;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip countdown;
    [SerializeField] AudioClip engine;
    public void startThaRace()
    {
        raceStarted = true;
        RaceStateEvents raceEvents = GameObject.FindGameObjectWithTag("RaceState").GetComponent<RaceStateEvents>();
        if (raceEvents.beginCountdown.GetPersistentEventCount() > 0)
          raceEvents.beginRace.Invoke();
    }
    public void PlayCountdown()
    {
        audioSource.PlayOneShot(countdown);
    }
    public void PlayEngine()
    {
        audioSource.PlayOneShot(engine);
    }
}

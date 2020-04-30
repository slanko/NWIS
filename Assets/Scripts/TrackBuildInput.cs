using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class TrackBuildInput : MonoBehaviour
{
    [SerializeField] RaceStateEvents events;
    [SerializeField] Transitions transition;
    [SerializeField] LoadLevel loadLevel;
    bool generationComplete = false;
    private void Start()
    {
        TrackStatus.sceneryPlaced += GenDone;
    }
    private void OnDestroy()
    {
        TrackStatus.sceneryPlaced -= GenDone;
    }
    void Update()
    {
        if (Input.GetButton("MenuRegen"))
            Regen();
        if (Input.GetButton("MenuAccept"))
            Race();
        if (Input.GetButton("MenuBack"))
            transition.TransitionOut(LoadDestination.prev);
    }
    void GenDone()
    {
        generationComplete = true;
    }
    void Race()
    {
        if(generationComplete)
            events.finishedGen.Invoke();
    }
    void Regen()
    {
        transition.TransitionOut(LoadDestination.same);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class TrackBuildInput : MonoBehaviour
{
    [SerializeField] RaceStateEvents events;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

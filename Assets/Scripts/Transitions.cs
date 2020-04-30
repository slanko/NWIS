using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transitions : MonoBehaviour
{
    RaceStateEvents stateEvents;
    [SerializeField] LoadLevel loadLevel;
    [SerializeField] Animator anim;
    LoadDestination targetLevel;
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
    public void TransitionOut(LoadDestination dest)
    {
        targetLevel = dest;
        anim.SetTrigger("Out");
    }
    public void Load()
    {
        loadLevel.Activate(targetLevel); 
    }  
}

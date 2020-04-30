using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FinishLine : MonoBehaviour
{
    public static int playersFinished = 0;
    private void Start()
    {
        playersFinished = 0;
        Placings.placings = new Player[4];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player thisPlayer = other.gameObject.GetComponentInParent<StorePlayer>().thisPlayer;

            if(!Array.Exists(Placings.placings, element => element == thisPlayer))
            {
                thisPlayer.finished = true;
                thisPlayer.inGameShip.GetComponent<DisablePlayer>().Activate();
                Placings.placings[playersFinished] = thisPlayer;
                playersFinished++;
                thisPlayer.position = playersFinished;
                RaceStateEvents.playerFinish.Invoke(thisPlayer);
            }         
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePlayer : MonoBehaviour
{
    public Player thisPlayer;
    private void Start()
    {
        thisPlayer.inGameShip = gameObject;
        thisPlayer.finished = false;
    }
}

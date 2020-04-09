using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void PlayerFinishEvent(Player player);
public class RaceStateEvents : MonoBehaviour
{
    public UnityEvent finishedGen;
    public UnityEvent startGame;
    public UnityEvent beginCountdown;
    public UnityEvent beginRace;
    public static PlayerFinishEvent playerFinish;
    public UnityEvent finishRace;
}

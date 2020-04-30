using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class Player : ScriptableObject
{
    public int number;
    public string screenName;
    [HideInInspector] public int position;
    public bool finished;
    public TimeSpan time;
    public Color color;
    public GameObject demo;
    public GameObject inGameShip;
}

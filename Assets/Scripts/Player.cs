using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Player : ScriptableObject
{
    public int number;
    public string screenName;
    [HideInInspector] public int position;
    public Color color;
    public GameObject demo;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsTest : MonoBehaviour
{
    [SerializeField] Player[] players;
    private void Awake()
    {
        for(int i =0; i < players.Length; i++)
        {
            Placings.placings[i] = players[i];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] GameObject[] inGamePlayers;
    int num = 1;
    private void Awake()
    {
       if (PlayerData.players.Count > 0)
        {
            foreach (Player p in PlayerData.players)
            {
                inGamePlayers[p.number-1].SetActive(true);
            }
        }
        else
        {
            foreach (GameObject g in inGamePlayers)
            {
                g.SetActive(true);
            }
        }
    }
}

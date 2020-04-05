using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    int num = 1;
    private void Awake()
    {
        if (PlayerData.playerCount > 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (!PlayerData.players.Contains(i + 1))
                {
                    players[i].SetActive(false);
                }
                else
                {
                    players[i].GetComponentInChildren<CameraSetup>().playerNum = num;
                    num++;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayIfPlayerCount : MonoBehaviour
{
    [SerializeField] GameObject obj;
    void Update()
    {
        if (PlayerData.players.Count > 0)
        {
            if(!obj.activeSelf)
             obj.SetActive(true);
        }
        else if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
    }
}

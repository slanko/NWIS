using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetPlayerCount : MonoBehaviour
{
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void Change()
    {
        PlayerData.playerCount = (int)slider.value;
        Debug.Log(PlayerData.playerCount);
    }
}

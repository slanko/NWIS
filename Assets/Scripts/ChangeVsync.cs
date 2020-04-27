using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeVsync : MonoBehaviour
{
    Dropdown dropdownMenu;
    private void Start()
    {
        dropdownMenu = GetComponent<Dropdown>();
        dropdownMenu.value = PlayerPrefs.GetInt("Vsync");
    }
    public void Change()
    {
        PlayerPrefs.SetInt("Vsync", dropdownMenu.value);
        QualitySettings.vSyncCount = dropdownMenu.value;
    }
}

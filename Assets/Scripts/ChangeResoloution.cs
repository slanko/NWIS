using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeResoloution : MonoBehaviour //I now realise that this is spelled incorrectly.
{
    Dropdown dropdownMenu;

    private void Start()
    {
        dropdownMenu = GetComponent<Dropdown>();
        dropdownMenu.ClearOptions();
        if (Screen.resolutions.Length == 0)
            return;
        Resolution[] resolutions = Screen.resolutions;
        Resolution currentRes = Screen.currentResolution;
        if (!Screen.fullScreen)
        {
            currentRes.width = Screen.width;
            currentRes.height = Screen.height;
        }

        dropdownMenu.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height, Screen.fullScreen); });
        for (int i = 0; i < resolutions.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = resolutions[i].ToString();
            dropdownMenu.options.Add(option);
            if (CompareResolutions(resolutions[i], currentRes))
                dropdownMenu.value = i;
        }
    }

    bool CompareResolutions(Resolution A, Resolution B)
    {
        if (A.width == B.width && A.height == B.height && A.refreshRate == B.refreshRate)
            return true;
        return false;
    }
}

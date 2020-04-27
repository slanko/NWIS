using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeQuality : MonoBehaviour
{
    Dropdown dropdown;
    private void Start()
    {
        dropdown = GetComponent<Dropdown>();
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
       foreach(string name in QualitySettings.names)
        {
            options.Add(new Dropdown.OptionData(name));
        }
        dropdown.AddOptions(options);
        dropdown.value = QualitySettings.GetQualityLevel();
    }
    public void Activate()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("Vsync");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVsyncSet : MonoBehaviour
{
    [SerializeField] PixellationLevels levels;
    private void Start()
    {
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("Vsync", 1);
        int pixellation = PlayerPrefs.GetInt("PixellationLevel",2);
        if (pixellation > 0)
        {
            QualitySettings.antiAliasing = 0;
            levels.Set(pixellation);
        }
    }
}

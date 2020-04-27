using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PixellationLevels : ScriptableObject
{
    public Vector2[] levels;

    public void Set(int level)
    {
        PlayerPrefs.SetInt("PixellationLevel", level);
        if (level > 0)
        {
            QualitySettings.antiAliasing = 0;
        }
        else
        {
            QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel()); //This probably makes no sense but it just reapplies the removed antialiasing. I hope.
        }
        
    }
}

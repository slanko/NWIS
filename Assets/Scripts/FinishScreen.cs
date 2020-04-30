using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class FinishScreen : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Text posText;
    [SerializeField] Text timeText;
    public void SetImage(PositionData posData)
    {
        img.sprite = posData.sprite;
        posText.text = posData.name;
    }
    public void SetTime(TimeSpan t)
    {
        timeText.text = "Time:" + t.ToString(@"mm\:ss\.fff");
    }
}

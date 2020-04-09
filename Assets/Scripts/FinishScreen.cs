using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Text txt;
    public void SetImage(PositionData posData)
    {
        img.sprite = posData.sprite;
        txt.text = posData.name;
    }
}

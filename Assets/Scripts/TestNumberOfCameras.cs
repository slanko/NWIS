using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestNumberOfCameras : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Camera[] cameras;
    [SerializeField] GameObject[] testObj;
    void Update()
    {
        string textToShow = "";
        foreach(Camera c in cameras)
        {
            textToShow += (c.name + " is rendering at size: " + c.pixelWidth + " x " + c.pixelHeight);
            textToShow += "is active:  "+c.gameObject.activeInHierarchy + "\n";
        }
        foreach(GameObject g in testObj)
        {
            textToShow += g.name + " is active: " + g.activeInHierarchy + "\n";
        }
        text.text = textToShow;
    }
}

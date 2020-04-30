using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    Text text;
    float theTime;
    public float speed = 1;
    string minutes, seconds, milliseconds, grilliseconds;
  //  TimeSpan time = new TimeSpan();
  //  time = TimeSpan.FromSeconds(theTime);
  //  text.text = time.ToString(@"mm/:ss/.fff");

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        theTime += Time.deltaTime * speed; 
        minutes = Mathf.Floor((theTime % 3600)/60).ToString("00"); 
        seconds = (theTime % 60).ToString("00");
        milliseconds = Mathf.Floor((theTime % 1000)*60).ToString("000");
        grilliseconds = milliseconds.Substring(milliseconds.Length - 2, 2);
        text.text = "time: " + minutes + ":" + seconds + "." + grilliseconds;

    }
}

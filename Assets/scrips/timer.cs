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
        string minutes = Mathf.Floor((theTime % 3600)/60).ToString("00"); 
        string seconds = (theTime % 60).ToString("00");
        string milliseconds = Mathf.Floor((theTime % 1000)*60).ToString("000");
        text.text = "time: " + minutes + ":" + seconds + "." + milliseconds;

    }
}

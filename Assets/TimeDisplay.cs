using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[RequireComponent(typeof(Text))]
public class TimeDisplay : MonoBehaviour
{
    public Player player;
    RaceStateEvents events;
    Text text;
    bool updateTime = false;

    private void Start()
    {
        text = GetComponent<Text>();
        events = GameObject.FindGameObjectWithTag("RaceState").GetComponent<RaceStateEvents>();
        events.beginRace.AddListener(StartTimer);
    }
    private void Update()
    {
        if (!player.finished&&updateTime)
        {
            player.time+=TimeSpan.FromSeconds(Time.deltaTime);
            text.text = "Time:"+player.time.ToString(@"mm\:ss\.ff");
        }    
    }
    public void StartTimer()
    {
        updateTime = true;
    }
    private void OnDestroy()
    {
        events.beginRace.RemoveListener(StartTimer);
    }
}

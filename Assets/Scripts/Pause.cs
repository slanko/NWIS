using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    public delegate void pauseEvents();
    public event pauseEvents unPause;

    bool paused = false;

    public bool Paused
    {
        get { return paused; }
        set { paused = value; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            paused = !paused;
        if (paused)
        {
            StartPause();
        }
        else
        {
            UnPause();
        }
    }
    private void StartPause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    void UnPause()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        unPause();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public enum LoadTrigger
{
    none,
    start,
    buttonPress
}
public enum LoadDestination
{
    next,
    prev,
    number
}

public class LoadLevel : MonoBehaviour
{
    public LoadDestination loadDest;
    [HideInInspector] public int level;
    [HideInInspector] public LoadTrigger trigger;
    [HideInInspector] public string button;
    public void Activate()
    {
        int levelToGoTo = 0;
        switch (loadDest)
        {
            case LoadDestination.next:
                levelToGoTo = SceneManager.GetActiveScene().buildIndex + 1;
                break;
            case LoadDestination.prev:
                levelToGoTo = SceneManager.GetActiveScene().buildIndex - 1;
                break;
            case LoadDestination.number:
                levelToGoTo = level;
                break;
        }
        SceneManager.LoadScene(levelToGoTo);
    }
    private void Start()
    {
        if (trigger == LoadTrigger.start)
        {
            Activate();
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown(button)&&trigger==LoadTrigger.buttonPress)
            Activate();
    }
}

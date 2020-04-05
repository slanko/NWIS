using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventOnKeypress : MonoBehaviour
{
    public string buttonName;
    public bool disableAfter;
    public UnityEvent press;
    private void Update()
    {
        if (Input.GetButtonDown(buttonName))
        {
            press.Invoke();
            if (disableAfter)
                this.enabled = false;
        }
    }
}

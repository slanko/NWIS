using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionOnButton : MonoBehaviour
{
    public string button;
    [SerializeField] Transitions transitions;
    private void Update()
    {
        if (Input.GetButtonDown(button))
        {
            transitions.TransitionOut(LoadDestination.next);
        }
    }
}

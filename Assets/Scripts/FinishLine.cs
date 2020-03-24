using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject raceStateObj = GameObject.FindGameObjectWithTag("RaceState");
            raceStateObj.GetComponent<RaceStateEvents>().finishRace.Invoke();
        }
    }
}

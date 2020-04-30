using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRigidbody : MonoBehaviour
{
    RaceStateEvents raceState;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
        raceState = GameObject.FindGameObjectWithTag("RaceState").GetComponent<RaceStateEvents>();
        raceState.beginRace.AddListener(RaceStart);
    }

    void RaceStart()
    {
        rb.constraints = RigidbodyConstraints.None;
        this.enabled = false;
    }
    private void OnDestroy()
    {
        raceState.beginRace.RemoveListener(RaceStart);
    }
}

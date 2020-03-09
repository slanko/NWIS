using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    Rigidbody rb;
    public float accelSpeed, turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetAxis("Accelerate") != 0)
        {
            rb.AddForce(transform.forward * (Input.GetAxis("Accelerate") * accelSpeed), ForceMode.Force);
        }
        rb.AddTorque(transform.up * (turnSpeed * Input.GetAxis("Horizontal")));

    }
}

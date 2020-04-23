using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public int playerNum;
    Rigidbody rb;
    public float accelSpeed, turnSpeed, brakeDrag;
    public string accelName, horizontalName;
    public Vector3 localVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        accelName = playerNum + "PAccelerate";
        horizontalName = playerNum + "PHorizontal";
    }

    private void Update()
    {
        if (Input.GetAxis(accelName) > 0)
        {
            rb.AddForce(transform.forward * (Input.GetAxis(accelName) * accelSpeed), ForceMode.Force);
            
        }
        if (Input.GetAxis(accelName) < 0)
        {
            rb.drag = brakeDrag;
        }
        else
        {
            rb.drag = 1;
        }
        rb.AddTorque(transform.up * (turnSpeed * Input.GetAxis(horizontalName)));
        localVelocity = transform.TransformVector(rb.velocity);
    }
}

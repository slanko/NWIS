using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public int playerNum;
    Rigidbody rb;
    public float accelSpeedBase, accelSpeedTweaked, turnSpeed, brakeDrag, xDragDiv;
    public string accelName, horizontalName;
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
            rb.AddForce(transform.forward * (Input.GetAxis(accelName) * accelSpeedTweaked), ForceMode.Force);
            
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

        //sideways drag stuff
        var vel = rb.velocity;
        var velFlat = new Vector3(vel.x, 0, vel.z).normalized;
        var forward = rb.transform.forward;
        var angle = Vector3.Angle(forward, velFlat);
        if(angle > 10)
        {
            rb.drag = angle / xDragDiv;
            if(rb.drag < 1f)
            {
                rb.drag = 1;
            }
            accelSpeedTweaked = accelSpeedBase + angle;
        }

    }
}

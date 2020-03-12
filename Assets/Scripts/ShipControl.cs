using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public int playerNum;
    Rigidbody rb;
    public float accelSpeedBase, accelSpeedTweaked, turnSpeed, brakeDrag, xDragDiv, controlHeight;
    public Vector3 localVelocity;
    public string accelName, horizontalName;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        accelName = playerNum + "PAccelerate";
        horizontalName = playerNum + "PHorizontal";
    }

    private void FixedUpdate()
    {
        //input/acceleration and turning script
        if (Input.GetAxis(accelName) > 0)
        {
            rb.AddForce(transform.forward * (Input.GetAxis(accelName) * accelSpeedBase), ForceMode.Force);
            
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

        //distance from track check
        var localVel = transform.InverseTransformDirection(rb.velocity);

        localVel.x = localVel.x / xDragDiv;
        localVelocity = new Vector3(localVel.x, localVel.y, localVel.z);
        rb.velocity = transform.TransformDirection(localVel);

        if (Physics.Raycast(transform.position, Vector3.down, out var hit, controlHeight))
        {
            var up = hit.normal;
            var localUp = rb.transform.up;

            // torque localUp toward up

            rb.AddForceAtPosition(up * Time.deltaTime, localUp * 10, ForceMode.Impulse);
            rb.AddForceAtPosition(-up * Time.deltaTime, localUp * -10, ForceMode.Impulse);
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public int playerNum;
    Rigidbody rb;
    public float accelSpeedBase, accelSpeedTweaked, turnSpeedBase, tweakedTurnSpeed, brakeDrag, xDragDiv, correctForce, controlHeight, baseCamFOV;
    public Vector3 localVelocity;
    public string accelName, horizontalName;
    public Camera myCam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        accelName = playerNum + "PAccelerate";
        horizontalName = playerNum + "PHorizontal";
        baseCamFOV = myCam.fieldOfView;
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
        rb.AddTorque(transform.up * (tweakedTurnSpeed* Input.GetAxis(horizontalName)));

        //distance from track check
        var localVel = transform.InverseTransformDirection(rb.velocity);

        localVel.x = localVel.x / xDragDiv;
        if(localVel.y > 0)
        {
            localVel.y = localVel.y / 2;
        }

        localVelocity = new Vector3(localVel.x, localVel.y, localVel.z);
        rb.velocity = transform.TransformDirection(localVel);
        
        //FOV bullshit
        myCam.fieldOfView = baseCamFOV + (localVel.z / 3f);
        //tweakedTurnSpeed = turnSpeedBase - localVel.z;
        tweakedTurnSpeed = turnSpeedBase;
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, controlHeight))
        {
            var up = hit.normal;
            var localUp = rb.transform.up;

            // torque localUp toward up
            rb.AddForceAtPosition(up * Time.deltaTime, localUp * correctForce, ForceMode.Impulse);
            rb.AddForceAtPosition(-up * Time.deltaTime, localUp * -correctForce, ForceMode.Impulse);
        }



    }
}

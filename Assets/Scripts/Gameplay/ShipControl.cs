using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public int playerNum;
    Rigidbody rb;
    public float accelSpeedBase, accelSpeedTweaked, turnSpeedBase, tweakedTurnSpeed, turnSpeedDecrease, minTurnSpeed, brakeDrag, xDragDiv, correctForce, controlHeight, baseCamFOV, downForce;
    public Vector3 localVelocity;
    public string accelName, horizontalName;
    public Camera myCam;
    bool raceStarted = false;
    RaceStateEvents raceState;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        accelName = playerNum + "PAccelerate";
        horizontalName = playerNum + "PHorizontal";
        baseCamFOV = myCam.fieldOfView;
        raceState = GameObject.FindGameObjectWithTag("RaceState").GetComponent<RaceStateEvents>();
        raceState.beginRace.AddListener(RaceStart);
    }

    public void RaceStart()
    {
        raceStarted = true;
    }
    private void OnDestroy()
    {
        raceState.beginRace.RemoveListener(RaceStart);
    }

    private void FixedUpdate()
    {
        //input/acceleration and turning script
        if (Input.GetAxis(accelName) > 0)
        {
            if(raceStarted == true)
            {
                rb.AddForce(transform.forward * (Input.GetAxis(accelName) * accelSpeedBase), ForceMode.Force);
            }
            
        }
        if (Input.GetAxis(accelName) < 0)
        {
            rb.drag = brakeDrag;
        }
        else
        {
            rb.drag = 1;
        }

        //changing x velocity to make it turn better
        var localVel = transform.InverseTransformDirection(rb.velocity);

        localVel.x = localVel.x / xDragDiv;
        if (localVel.y > 0)
        {
            localVel.y = localVel.y / 1.5f;
        }

        //tweakedTurnSpeed = turnSpeedBase - localVel.z;
        tweakedTurnSpeed = turnSpeedBase - Mathf.Pow(localVel.z * turnSpeedDecrease, 2);
        if (tweakedTurnSpeed < minTurnSpeed)
        {
            tweakedTurnSpeed = minTurnSpeed;
        }

        if (raceStarted == true)
        {
            rb.AddTorque(transform.up * (tweakedTurnSpeed * Input.GetAxis(horizontalName)));
        }


        localVelocity = new Vector3(localVel.x, localVel.y, localVel.z);
        rb.velocity = transform.TransformDirection(localVel);
        
        //FOV bullshit
        myCam.fieldOfView = baseCamFOV + (localVel.z / 3f);



        if (Physics.Raycast(transform.position, Vector3.down, out var hit, controlHeight))
        {
            var up = hit.normal;
            var localUp = rb.transform.up;

            // torque localUp toward up
            rb.AddForceAtPosition(up * Time.deltaTime, localUp * correctForce, ForceMode.Impulse);
            rb.AddForceAtPosition(-up * Time.deltaTime, localUp * -correctForce, ForceMode.Impulse);
        }

        //downforce script
        rb.AddForce(Vector3.down * downForce);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl2 : MonoBehaviour
{
    Rigidbody rb;
    public float accelSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * accelSpeed, ForceMode.Force);
        }
    }
}

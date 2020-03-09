using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class floaterScript : MonoBehaviour
{
    Rigidbody rb;
    public float floatHeight, floatForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        if(Physics.Raycast(transform.position, new Vector3(0, -1, 0), floatHeight))
        {
            rb.AddForce(transform.up * floatForce, ForceMode.Force);
        }
    }
}

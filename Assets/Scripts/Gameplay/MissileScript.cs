using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    Rigidbody rb;
    public float rocketSpeed, controlHeight, correctForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * rocketSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, controlHeight))
        {
            var up = hit.normal;
            var localUp = rb.transform.up;
            Debug.DrawLine(transform.position, hit.point, Color.green, 200);
            rb.AddForceAtPosition(up * Time.deltaTime, localUp * correctForce, ForceMode.Impulse);
            rb.AddForceAtPosition(-up * Time.deltaTime, localUp * -correctForce, ForceMode.Impulse);
            //transform.rotation = hit.transform.rotation;
        }
        rb.AddForce(transform.forward * rocketSpeed, ForceMode.Acceleration);
    }
}

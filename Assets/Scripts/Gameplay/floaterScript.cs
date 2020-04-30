using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class floaterScript : MonoBehaviour
{
    Rigidbody rb;
    public float floatHeight, floatForce;
    public LayerMask layers;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ground check
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, floatHeight,layers))
        {
            var proportion = Mathf.Pow(1 - hit.distance / floatHeight, 3);
            rb.AddForce(hit.normal * floatForce * proportion * Time.deltaTime, ForceMode.Impulse);
        }
    }
}

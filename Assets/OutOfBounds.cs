using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Checkpoint))]
[RequireComponent(typeof(Rigidbody))]
public class OutOfBounds : MonoBehaviour
{
    Checkpoint checkpoint;
    Rigidbody[] bodies;
    const float spawnHeight = 2.5f;
    private void Start()
    {
        checkpoint = GetComponent<Checkpoint>();
        bodies = GetComponentsInChildren<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            transform.position = checkpoint.checkPoint.position+new Vector3(0,spawnHeight,0);
            transform.rotation = checkpoint.checkPoint.rotation;
            foreach (var body in bodies)
            {
                body.velocity = Vector3.zero;
                body.angularVelocity = Vector3.zero;
            }
        }
    }
}

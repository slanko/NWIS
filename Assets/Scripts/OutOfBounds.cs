using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Checkpoint))]
[RequireComponent(typeof(Rigidbody))]
public class OutOfBounds : MonoBehaviour
{
    Checkpoint checkpoint;
    Rigidbody[] bodies;
    [SerializeField] GameObject destroyed;
    
    private void Start()
    {
        checkpoint = GetComponent<Checkpoint>();
        bodies = GetComponentsInChildren<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground"|| collision.collider.tag == "Building")
        {
            GetComponentInParent<ResetPlayer>().Reset(checkpoint);
        }
    }
}

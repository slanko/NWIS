using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackFollow : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * 5);
    }
}

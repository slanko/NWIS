using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetSize : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] string axis;
    [SerializeField] Rigidbody rb;
    float zSize = 1;
    private void Update()
    {
        float velocity = rb.velocity.magnitude;
        float scale = Mathf.Lerp(0.3f, 1f, Input.GetAxis(axis))+Mathf.Lerp(0f,1f,velocity/100);
        zSize = Mathf.Lerp(zSize, scale, 10 * Time.deltaTime);
        foreach (Transform t in transforms) {
            Vector3 size = t.localScale;
            size.z = zSize;
            t.localScale = size; 
        }
    }
}

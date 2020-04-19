using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAccelerate : MonoBehaviour
{
    [SerializeField] string axis;
    float zSize = 1;
    private void Update()
    {
        float scale = Mathf.Lerp(0.3f, 2f, Input.GetAxis(axis));
        zSize = Mathf.Lerp(zSize, scale, 2 * Time.deltaTime);
        Vector3 size = transform.localScale;
        size.z = zSize;
        transform.localScale = size;

    }
    void FixedUpdate()
    {
        
    }
}

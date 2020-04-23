using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    LayerMask layer = 1 << 9;
    public Transform checkPoint;
    private void OnEnable()
    {
        StartCoroutine(Check());
    }
    IEnumerator Check()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(0.1f);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 100, layer))
            {
                if (hit.collider.tag == "Track")
                {
                    checkPoint = hit.transform;
                }
            }
        }
    }
}

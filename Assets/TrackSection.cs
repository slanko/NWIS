using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrackSection: ScriptableObject
{
    public GameObject prefab;
    public float length;
    public float difficulty;

    public GameObject CreateSection(GameObject origin)
    {
        GameObject g = Instantiate(prefab, origin.transform.position, origin.transform.rotation);
        Transform end = g.transform.GetChild(1);
        Transform start = g.transform.GetChild(0);
        float distance = Vector3.Distance(start.position, end.position)/2;

        Rigidbody rb = g.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        RaycastHit hit;
        rb.SweepTest(Vector3.zero, out hit);
        if (hit.collider != null)
        {
            Destroy(g);
            return origin; //This is returned if the track would overlap
        }
        else
        {
            Destroy(rb);
            return end.gameObject;
        }
    }
}

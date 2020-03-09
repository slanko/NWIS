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

        
        BoxCollider b = g.transform.GetChild(4).GetComponent<BoxCollider>();
        if(Physics.CheckBox(b.transform.position, b.size/2, b.transform.rotation))
        { 
            Destroy(g);
            Debug.Log("Fail");
            return origin; //This is returned if the track would overlap
        }
        else
        {
            Debug.Log("Success");
            g.transform.GetChild(3).gameObject.GetComponent<MeshCollider>().enabled = true;
            return end.gameObject;
        }
    }
}

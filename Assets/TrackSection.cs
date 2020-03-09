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
        if (Random.Range(0, 2) == 1)
        {
            Vector3 scale = g.transform.localScale;
            scale.x = -scale.x;
            g.transform.localScale = scale;
            Debug.Log("Flipped");
        }
        GameObject cubey = g.transform.GetChild(4).gameObject;
        if(Physics.CheckBox(cubey.transform.position, cubey.transform.localScale/2, cubey.transform.rotation))
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

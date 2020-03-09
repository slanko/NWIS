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
        GameObject hitbox = g.transform.GetChild(4).gameObject;

        FlipSectionRandom(g);
        
        if(Physics.CheckBox(hitbox.transform.position, hitbox.transform.localScale/2, hitbox.transform.rotation))
        { 
            Destroy(g);
            return origin; //This is returned if the track would overlap
        }
        else
        {
            g.transform.GetChild(3).gameObject.GetComponent<MeshCollider>().enabled = true;
            return end.gameObject;
        }
    }

    void FlipSectionRandom(GameObject g)
    {
        if (Random.Range(0, 2) == 1)
        {
            Vector3 scale = g.transform.localScale;
            scale.x = -scale.x;
            g.transform.localScale = scale;
        }
    }
}

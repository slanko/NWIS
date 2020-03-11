using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrackSection: ScriptableObject
{
    public GameObject prefab;
    public float weight;
    public int heightChange;
    public GameObject CreateSection(GameObject origin)
    {
        
        GameObject g = Instantiate(prefab, origin.transform.position, origin.transform.rotation);
        SectionData data = g.GetComponent<SectionData>();
        Transform end = data.end;
        Transform start = data.start;
        Transform hitbox = data.hitbox;
        data.trackCollider.enabled = false;
        FlipSectionRandom(g);
        
        if(Physics.CheckBox(hitbox.position, hitbox.localScale/2, hitbox.rotation))
        { 
            Destroy(g);
            return origin; //This is returned if the track would overlap
        }
        else
        {       
            TrackGenerator.height += heightChange;
            data.trackCollider.enabled = true;
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

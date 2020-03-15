using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrackSection : ScriptableObject
{
    public GameObject prefab;
    public float weight;
    public int heightChange;
    public float difficulty;
    [HideInInspector] public float likelihood;
    [SerializeField] LayerMask layer;
    public GameObject CreateSection(GameObject origin)
    {

        GameObject g = Instantiate(prefab, origin.transform.position, origin.transform.rotation);
        FlipSectionRandom(g);
        SectionData data = g.GetComponent<SectionData>();
        Transform end = data.end;
        Transform start = data.start;
        BoxCollider hitBox = data.hitbox;


        
        Vector3 checkPoint = hitBox.transform.TransformPoint(hitBox.center);
        Quaternion checkRotation = hitBox.transform.rotation;
        hitBox.enabled = true;
        hitBox.transform.rotation = Quaternion.identity;
        Physics.SyncTransforms();
        Vector3 checkSize = hitBox.bounds.size;
        hitBox.transform.rotation = checkRotation;
        Physics.SyncTransforms();
        hitBox.enabled = false;

        
        data.trackCollider.enabled = false;
        
        Debug.Log(g.transform.localScale);
        if (Physics.CheckBox(checkPoint, checkSize / 2, checkRotation, layer))
        {
            Destroy(g);
            return origin; //This is returned if the track would overlap
        }
        else
        {
            TrackGenerator.height += heightChange;
            data.trackCollider.enabled = true;
            GameObject tempObj = new GameObject();
            tempObj.transform.rotation = checkRotation;
            tempObj.transform.position = checkPoint;
            g.GetComponent<HitboxVis>().b = new Box(tempObj.transform, checkSize);


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

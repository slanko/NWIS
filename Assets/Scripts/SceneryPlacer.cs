using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Box
{
    public Transform transform;
    public Vector3 size;
    public Box(Transform _transform, Vector3 _size)
    {
        transform = _transform;
        size = _size;
    }
}
public class SceneryPlacer : MonoBehaviour
{
    [Tooltip("Chance of spawning in percent")]
    public AnimationCurve chanceLookup;
    public float chance;
    public GameObject[] sceneryPoints;
    public GameObject[] sceneryObjects;
    public List<Box> boxChecks = new List<Box>();
    [SerializeField] LayerMask layer;
    int count = 0;
    Vector3 spawnPoint;
    GameObject objToPlace;
    private void Start()
    {
        TrackCompleted.complete += TrackComplete;
    }
    void TrackComplete()
    {
        sceneryPoints = GameObject.FindGameObjectsWithTag("Scenery Point");
        StartCoroutine(PlaceScenery());
    }

    IEnumerator PlaceScenery()
    {
        for (int i =0;i <sceneryPoints.Length;i++)
        {

            chance = Mathf.PerlinNoise((float)i / (float)sceneryPoints.Length * 5, 0);
            chance = chanceLookup.Evaluate(chance);
            yield return new WaitForSeconds(0.0001f);
            objToPlace = GetRandomSection();

            CheckPlacement(sceneryPoints[i]);
        }
    }

    void CheckPlacement(GameObject point)
    {
        Vector3 spawnPoint = point.transform.position;
        float distAmt = 0;
        for (int i = 20; i > 0; i--)
        {
            if (Random.Range(0f, 1f)<chance)
            {
                RaycastHit hit;
                if (Physics.Raycast(spawnPoint, Vector3.down, out hit, 1000, 1 << 8, QueryTriggerInteraction.Ignore))
                {
                    point.transform.position = hit.point;
                    Place(point);
                }
            }
            spawnPoint = spawnPoint + (point.transform.forward * distAmt);
            distAmt++;
        }
    }

    void Place(GameObject point) //returns true if successful.
    {
        spawnPoint = point.transform.position;
        GameObject g = Instantiate(objToPlace, point.transform.position, point.transform.rotation);
        BoxCollider hitbox = g.GetComponent<Scenery>().hitbox;
        hitbox.enabled = true;
        Quaternion originalRotation = hitbox.transform.rotation;
        hitbox.transform.rotation = Quaternion.identity;
        Physics.SyncTransforms();
        Vector3 checkPoint = hitbox.bounds.center;
        Vector3 checkSize = hitbox.bounds.size;
        hitbox.transform.rotation = originalRotation;
        hitbox.enabled = false;
        Physics.SyncTransforms();

        Quaternion checkRotation = hitbox.transform.rotation;

        if (Physics.CheckBox(checkPoint, checkSize/2, checkRotation, layer))
        {
            Destroy(g);
            Debug.Log("Box Failed");
            spawnPoint = spawnPoint + (point.transform.forward * 8);
            return;
        }

       /* GameObject tempObj = new GameObject();
        tempObj.transform.position = checkPoint;
        tempObj.transform.rotation = checkRotation;
        boxChecks.Add(new Box(tempObj.transform, checkSize));*/
        hitbox.enabled = true;
        objToPlace = GetRandomSection();
    }

   /* void OnDrawGizmosSelected()
    {
        foreach (Box b in boxChecks)
        {
            Gizmos.matrix = b.transform.localToWorldMatrix;
            Gizmos.DrawCube(Vector3.zero, b.size);
            Destroy(b.transform.gameObject);
        }
        
    }*/

    public GameObject GetRandomSection()
    {
        float random = Random.Range(0f, 1f);
        float totalWeight = 0;
        float currentWeight = 0;
        foreach (GameObject g in sceneryObjects)
        {
            totalWeight += g.GetComponent<Scenery>().weight;

        }

        foreach (GameObject g in sceneryObjects)
        {
            float upper = currentWeight + (g.GetComponent<Scenery>().weight / totalWeight);
            float floor = currentWeight;
            if (random >= floor && random < upper)
            {
                return g;
            }
            currentWeight += (g.GetComponent<Scenery>().weight / totalWeight);
        }
        Debug.Log("failed to select a section");
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Box
{
    public Transform transform;
    public Vector3 size;
    public Box(Transform _transform, Vector3 _size)
    {
        transform=_transform;
        size = _size;
    }
}
public class SceneryPlacer : MonoBehaviour
{
    public GameObject[] sceneryPoints;
    public GameObject[] sceneryObjects;
    public List<Box> boxChecks = new List<Box>();
    [SerializeField] LayerMask layer;
    int count = 0;

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
        foreach(GameObject g in sceneryPoints) {

                yield return new WaitForSeconds(0.0001f);
                GameObject objToPlace = GetRandomSection();

                Place(objToPlace, g);
        }
    }

    void Place(GameObject objToPlace,GameObject point)
    {
        Vector3 spawnPoint = point.transform.position;
        for(int i = 50; i > 0; i--)
        {
            if (Random.Range(0, 80) == 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(point.transform.position, Vector3.down, out hit, 1 << 8))
                {
                    GameObject g = Instantiate(objToPlace, hit.point, point.transform.rotation);
                    BoxCollider hitbox = g.GetComponent<Scenery>().hitbox;
                    
                    Vector3 checkPoint = g.transform.position;
                    Vector3 checkSize = hitbox.bounds.size;
                    Debug.Log("Bounds size" + checkSize);
                    hitbox.enabled = false;
                    Quaternion checkRotation = g.transform.rotation;
                    if (Physics.CheckBox(checkPoint, checkSize, checkRotation, layer))
                    {
                        Destroy(g);
                        spawnPoint = spawnPoint + (point.transform.forward * 8);
                    }
                    else
                    {
                        GameObject tempObj = new GameObject();
                        tempObj.transform.position = checkPoint;
                        tempObj.transform.rotation = checkRotation;
                        boxChecks.Add(new Box(tempObj.transform, checkSize));
                        hitbox.enabled = true;
                        objToPlace = GetRandomSection();
                    }
                }
                else
                {
                    spawnPoint = spawnPoint + (point.transform.forward * 8);
                }
                
            }
            else
            {
                spawnPoint = spawnPoint + (point.transform.forward * 8);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        foreach(Box b in boxChecks)
        {
            Gizmos.matrix = b.transform.localToWorldMatrix;
            Gizmos.DrawCube(Vector3.zero,b.size);
        }
    }

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
            float upper = currentWeight + g.GetComponent<Scenery>().weight/totalWeight;
            float floor = currentWeight;
            if (random >= floor && random < upper)
            {
                return g;
            }
            currentWeight += g.GetComponent<Scenery>().weight / totalWeight;
        }
        Debug.Log("failed to select a section");
        return null;
    }
}

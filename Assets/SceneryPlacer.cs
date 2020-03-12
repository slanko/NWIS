using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryPlacer : MonoBehaviour
{
    public GameObject[] sceneryPoints;
    public GameObject[] sceneryObjects;
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
        Transform hitbox = objToPlace.GetComponent<Scenery>().hitbox;
        Vector3 spawnPoint = point.transform.position;
        for(int i = 50; i > 0; i--)
        {
            if (Random.Range(0, 80) == 0)
            {
                if (Physics.CheckBox(spawnPoint, hitbox.localScale * 0.6f, point.transform.rotation))
                {

                    spawnPoint = spawnPoint + (point.transform.forward * 8);
                }
                else
                {

                    Instantiate(objToPlace, spawnPoint, point.transform.rotation); //this is default rotation for now
                    objToPlace = GetRandomSection();
                    hitbox = objToPlace.GetComponent<Scenery>().hitbox;

                }
            }
            else
            {
                spawnPoint = spawnPoint + (point.transform.forward * 8);
            }
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

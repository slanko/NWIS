using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawnScript : MonoBehaviour
{
    public int numToSpawn;
    public GameObject[] rocks;
    private Vector3 position;
    private string rockToDestroyName;
    private GameObject rockToDestroy;

    private bool destroyEm;
    // Start is called before the first frame update
    void Start()
    {
        int spawned = 0;

        while(spawned < numToSpawn)
        {

            position = new Vector3(Random.Range(-2000f, 2000.0f), -200, Random.Range(-2000f, 2000.0f));
            Instantiate(rocks[Random.Range(0, rocks.Length)], position,Quaternion.Euler(new Vector3(0, Random.Range(0,360) ,0)));
            spawned++;
        }
    }


}



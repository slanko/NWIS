using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPadScript : MonoBehaviour
{
    public float chanceToSpawn;
    public bool weaponDispensed = false;
    // Start is called before the first frame update
    void Start()
    {
        var chanceNum = Random.Range(0, 100);
        if(chanceNum > chanceToSpawn)
        {
            gameObject.SetActive(false);
        } 

    }

    public void resetWeaponAvailability()
    {
        weaponDispensed = false;
    }
}

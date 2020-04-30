using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPadScript : MonoBehaviour
{
    public float chanceToSpawn, chanceToBeHealth;
    public bool weaponDispensed = false, healthPad;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        var chanceNum = Random.Range(0, 100);
        if(chanceNum > chanceToSpawn)
        {
            gameObject.SetActive(false);
        }
        chanceNum = Random.Range(0, 100);
        if(chanceNum < chanceToBeHealth)
        {
            healthPad = true;
        }
        if(healthPad == true)
        {
            anim.SetBool("healthMode", true);
        }
        else
        {
            anim.SetBool("healthMode", false);
        }
    }

    public void resetWeaponAvailability()
    {
        weaponDispensed = false;
    }
}

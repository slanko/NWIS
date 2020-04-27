using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public GameObject particlez; 

    public void DestroyMe()
    {
        particlez.transform.parent = null;
        Destroy(gameObject);

    }
}

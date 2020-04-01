using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    Rigidbody rb;
    weaponSystem wS;
    public float explosionPower,  explosionRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            wS = other.gameObject.GetComponent<weaponSystem>();
            rb.AddExplosionForce(explosionPower, transform.position, explosionRadius, 1f, ForceMode.Impulse);
            //rb.AddForceAtPosition(Vector3.up * explosionPower, transform.position, ForceMode.Impulse);
            wS.health = wS.health - 1;
            Destroy(this.gameObject);
        }

    }
}

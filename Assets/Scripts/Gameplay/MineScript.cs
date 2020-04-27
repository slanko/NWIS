using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    Rigidbody rb;
    weaponSystem wS;
    public float explosionPower,  explosionRadius, controlHeight, lerpDownSpeed;
    public LayerMask correctLayer;
    public GameObject explosion;
    bool damageDealt = false;


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            wS = other.gameObject.GetComponent<weaponSystem>();
            if (damageDealt == false)
            {
                if(wS.shieldsEnabled == false)
                {
                    rb.AddExplosionForce(explosionPower, transform.position, explosionRadius, 1f, ForceMode.Impulse);
                    wS.health = wS.health - 1;
                }
                damageDealt = true;
            }
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, controlHeight, correctLayer))
        {
            var up = hit.normal;
            Debug.DrawLine(transform.position, hit.point, Color.green, 200);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, hit.transform.position.y + .75f, lerpDownSpeed), transform.position.z);
        }
    }
}

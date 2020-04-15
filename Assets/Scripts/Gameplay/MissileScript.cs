using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    Rigidbody rb, pRb;
    weaponSystem wS;
    public float rocketSpeed, controlHeight, correctForce, explosionPower, explosionRadius, lerpDownSpeed;
    public LayerMask correctLayer;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * rocketSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, controlHeight, correctLayer))
        {
            var up = hit.normal;
            var localUp = rb.transform.up;
            Debug.DrawLine(transform.position, hit.point, Color.green, 200);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, hit.transform.position.y + .5f, lerpDownSpeed) , transform.position.z);
        }
        rb.AddForce(transform.forward * rocketSpeed, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            pRb = other.gameObject.GetComponent<Rigidbody>();
            wS = other.gameObject.GetComponent<weaponSystem>();
            rb.AddExplosionForce(explosionPower, transform.position, explosionRadius, 1f, ForceMode.Impulse);
            wS.health = wS.health - 1;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

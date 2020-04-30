using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject brokenBarrier;
    public GameObject brokenExplode;

    public Rigidbody brokenPiece1;
    public Rigidbody brokenPiece2;
    public Rigidbody brokenPiece3;
    public Rigidbody brokenPiece4;


    // Start is called before the first frame update
    void Start()
    {
        brokenExplode.SetActive(false);
        this.gameObject.SetActive(true);
        brokenPiece1.useGravity = false;
        brokenPiece2.useGravity = false;
        brokenPiece3.useGravity = false;
        brokenPiece4.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            brokenExplode.SetActive(true);
            brokenBarrier.transform.parent = null;
            this.gameObject.SetActive(false);
            brokenPiece1.useGravity = true;
            brokenPiece2.useGravity = true;
            brokenPiece3.useGravity = true;
            brokenPiece4.useGravity = true;

            brokenPiece1.AddForce(transform.right * 1100);
            brokenPiece2.AddForce(transform.right * 1800);
            brokenPiece3.AddForce(transform.right * 1400);
            brokenPiece4.AddForce(transform.right * 1200);

            brokenPiece1.AddTorque(transform.up * 100 * 100);
            brokenPiece2.AddTorque(transform.up * 100 * 100);
            brokenPiece3.AddTorque(transform.up * 100 * 100);
            brokenPiece4.AddTorque(transform.up * 100 * 100);

            Destroy(brokenBarrier, 5f);

            Destroy(this.gameObject, 5f);
        }
    }
}

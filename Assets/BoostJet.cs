using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostJet : MonoBehaviour
{
    [SerializeField] string vertical;
    [SerializeField] string horizontal;
    [SerializeField] string button;
    [SerializeField] float forceMulti;
    [SerializeField] float horizontalMulti;
    Vector3 force;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetButtonDown(button))
        {
            Debug.LogWarning("Boost");
            float vert = Input.GetAxis(vertical);
            if (Mathf.Abs(vert) < 0.8f)
                vert = 0;
            float hori = Input.GetAxis(horizontal);
            if (Mathf.Abs(hori) < 0.8f)
                hori = 0;
            if (hori == 0 & vert == 0)
                vert = 1;
            force = new Vector3(hori, 0, vert);
            force = force.normalized;
            force.x *= horizontalMulti;
            StartCoroutine(Boost());
        }
    }
    IEnumerator Boost()
    {
        for(int i =0; i < 20; i++)
        {
            rb.AddRelativeForce(force * forceMulti);
            yield return new WaitForFixedUpdate();
        }
    }
}

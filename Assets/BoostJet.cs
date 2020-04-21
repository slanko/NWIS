using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostJet : MonoBehaviour
{
    [SerializeField] GameObject boost;
    [SerializeField] AnimationCurve boostCurve;
    [SerializeField] string vertical;
    [SerializeField] string horizontal;
    [SerializeField] float forceMulti;
    [SerializeField] float horizontalMulti;
    Vector3 force;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Trigger()
    {
        float vert = Input.GetAxis(vertical);

        float hori = Input.GetAxis(horizontal);
        if (Mathf.Abs(vert) < 0.5f && Mathf.Abs(hori) < 0.5f)
        {
            vert = 1;
            hori = 0;
        }
        force = new Vector3(hori, 0, vert);
        force = force.normalized;
        Vector3 worldRotation = transform.TransformDirection(-force);
        Quaternion rot = Quaternion.LookRotation(worldRotation, Vector3.up);
        Instantiate(boost, transform.position, rot);
        force.x *= horizontalMulti;
        StartCoroutine(Boost());
    }
    IEnumerator Boost()
    {
        
        for(int i =0; i < 10; i++)
        {
            float curveMulti = boostCurve.Evaluate(i / 10);
            rb.AddRelativeForce(force * forceMulti*curveMulti);
            yield return new WaitForFixedUpdate();
        }
    }
}

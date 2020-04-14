using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem system;
    [SerializeField] float emitHit;
    [SerializeField] float emitStay;
    float stayParticles = 0;

    private void OnCollisionEnter(Collision collision)
    {
        system.transform.position = collision.contacts[0].point + collision.contacts[0].normal*0.2f;
        system.Emit((int)(emitHit * collision.impulse.magnitude));
    }
    private void OnCollisionStay(Collision collision)
    {

        system.transform.position = collision.contacts[0].point+collision.contacts[0].normal*0.2f;
        stayParticles += (emitStay * collision.relativeVelocity.magnitude);
        if (stayParticles > 1)
        {
            int partsToEmit = (int)stayParticles;
            stayParticles -= partsToEmit;
            system.transform.position = collision.contacts[0].point + collision.contacts[0].normal * 0.2f;
            system.Emit(partsToEmit);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonEffects : MonoBehaviour
{
    [System.Serializable]
    [SerializeField]
    class CollisionEffect
    {
        public ParticleSystem system;
        public float hitEmission;
        public float stayEmission;
        [HideInInspector] public float partsToEmit;
        public bool setColor;
    }
    [SerializeField] Transform fxTransform;
    [SerializeField] CollisionEffect[] effects;


    private void Start()
    {
        foreach (CollisionEffect ce in effects)
        {
            if (ce.setColor)
            {
                Color color = GetComponent<StorePlayer>().thisPlayer.color;
                ParticleSystem.MainModule module = ce.system.main;
                module.startColor = color;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        fxTransform.position = collision.contacts[0].point + collision.contacts[0].normal * 0.5f + (Vector3.up * 0.2f);
        foreach (CollisionEffect ce in effects)
        {
            ce.system.Emit((int)(ce.hitEmission * collision.impulse.magnitude));
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        fxTransform.position = collision.contacts[0].point + collision.contacts[0].normal * 0.5f + (Vector3.up * 0.2f);

        foreach (CollisionEffect ce in effects)
        {
            ce.partsToEmit += (ce.stayEmission * collision.relativeVelocity.magnitude);
            if (ce.partsToEmit > 1)
            {
                int parts = (int)ce.partsToEmit;
                ce.partsToEmit -= parts;
                ce.system.Emit(parts);
            }
        }
    }
}

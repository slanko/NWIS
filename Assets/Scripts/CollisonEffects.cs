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
        [HideInInspector] public int maxHit = 20;
        [HideInInspector] public int maxStay = 5;
    }
    [SerializeField] Transform fxTransform;
    [SerializeField] CollisionEffect[] effects;
    [SerializeField] GameObject lightObject;
    Light lightSource;
    Transform lightTransform;
    float lightIntensity = 0;
    bool lightEnabled = false;
    const float maxIntensity = 2;
    const float lightHitMulti = 0.5f;
    const float lightStayMulti = 0.1f;


    private void Start()
    {
        lightSource = lightObject.GetComponent<Light>();
        lightTransform = lightObject.transform;
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
    private void OnEnable()
    {
        StartCoroutine(FadeLight());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 pos = collision.contacts[0].point + collision.contacts[0].normal * 0.5f + (Vector3.up * 0.2f);
        fxTransform.position = pos;
        lightTransform.position = pos;
        float magnitude = collision.impulse.magnitude;
        lightIntensity = magnitude * lightHitMulti;
        int iterations = effects.Length;
        for (int i = 0; i < iterations; i++)
        {
            int amountToEmit = (int)(effects[i].hitEmission * magnitude);
            amountToEmit = Mathf.Clamp(amountToEmit, 0, effects[i].maxHit);
            effects[i].system.Emit(amountToEmit);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 pos = collision.contacts[0].point + collision.contacts[0].normal * 0.5f + (Vector3.up * 0.2f);
        fxTransform.position = pos;
        lightTransform.position = pos;
        float relativeVelocity = collision.relativeVelocity.magnitude;
        lightIntensity = relativeVelocity * lightStayMulti;
        int iterations = effects.Length;
        for (int i = 0; i < iterations; i++)
        {
            float extraParts = (effects[i].stayEmission * relativeVelocity);
            extraParts = Mathf.Clamp(extraParts, 0, effects[i].maxStay);
            effects[i].partsToEmit += extraParts;
            if (effects[i].partsToEmit > 1)
            {
                int parts = (int)effects[i].partsToEmit;
                effects[i].partsToEmit -= parts;
                effects[i].system.Emit(parts);
            }
        }
    }

    IEnumerator FadeLight()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(1 / 60);
            if (lightIntensity > 0.1f)
            {
                if (!lightSource.enabled)
                    lightSource.enabled = true;
                lightIntensity = Mathf.Clamp(lightIntensity, 0, maxIntensity);
                lightIntensity = Mathf.Lerp(lightIntensity, 0, 0.1f);
                lightIntensity += 1 * (Mathf.PerlinNoise(Time.time*5, 0) - 0.5f);
                lightSource.intensity = lightIntensity;
            }
            else
            {
                if (lightSource.enabled)
                    lightSource.enabled = false;
            }
            
        }
    }
}

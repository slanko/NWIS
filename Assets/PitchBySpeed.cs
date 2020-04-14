using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchBySpeed : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSource;
    [SerializeField] Rigidbody rb;
    const float refSpeed = 100;
    private void Start()
    {
    }
    void Update()
    {
        float pitch = Mathf.Lerp(0.5f, 1.5f, rb.velocity.magnitude / refSpeed);
        float vol = Mathf.Lerp(0f, 0.3f, rb.velocity.magnitude / 50);
        foreach (AudioSource a in audioSource)
        {
            a.pitch = pitch;
            a.volume = vol;
        }
            
    }
}

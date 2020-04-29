using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript2 : MonoBehaviour
{
    public AudioClip[] soundz;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.PlayOneShot(soundz[Random.Range(0, soundz.Length)], 1f);
    }
}

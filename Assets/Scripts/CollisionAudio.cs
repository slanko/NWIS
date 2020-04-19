using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    [SerializeField] AudioSource hitAudio;
    [SerializeField] AudioClip[] hitClip;
    [SerializeField] AudioSource scrapeAudio;
    [SerializeField] float scrapeVol = 0.4f;
    [SerializeField] float hitVol = 0.4f;
    float minImpulse = 20;
    float maxImpulse = 80;
    float maxScrapeSpeed = 10;
    float targetVol = 0;
    bool canPlay = true;
    const float cooldownTime = 0.1f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.magnitude > minImpulse&&canPlay)
        {
            int pick = Random.Range(0, hitClip.Length);
            float volume = Mathf.Lerp(0, hitVol, collision.impulse.magnitude / maxImpulse);
            hitAudio.PlayOneShot(hitClip[pick],volume);
            canPlay = false;
            StartCoroutine(HitSoundCooldown());
        }
    }
    IEnumerator HitSoundCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canPlay = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        targetVol = Mathf.Lerp(0, scrapeVol, collision.relativeVelocity.magnitude/maxScrapeSpeed);
        scrapeAudio.pitch = Mathf.Lerp(0.8f, 1.2f, collision.relativeVelocity.magnitude / maxScrapeSpeed);
    }
    private void FixedUpdate()
    {
        float lerpAmt = 0;
        if(targetVol>scrapeAudio.volume)
        {
            lerpAmt = 0.2f;
        }
        else
        {
            lerpAmt = 0.1f;
        }
        scrapeAudio.volume = Mathf.Lerp(scrapeAudio.volume, targetVol, lerpAmt);
    }
    private void OnCollisionExit(Collision collision)
    {
        targetVol = 0;
    }
}

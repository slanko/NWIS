using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class CullLightsAtDistance : MonoBehaviour
{
    Light lightSource;
    [SerializeField] float enableDistance;
    const float updateTime = 0.5f;
    float currentDistance;

    private void OnEnable()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(CheckDistance());
    }
    IEnumerator CheckDistance()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(updateTime);
            int iterations = CameraTransforms.transforms.Count;
            bool shouldLight = false;
            for(int i = 0; i < iterations; i++)
            {
                if (Vector3.Distance(transform.position, CameraTransforms.transforms[i].position) < enableDistance)
                {
                    shouldLight = true;
                }
            }
            lightSource.enabled = shouldLight;   
        }
    }
}

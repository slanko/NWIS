using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField] float time;

    private void Start()
    {
        StartCoroutine(WaitToDestroy());
    }
    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject destroyed;
    Rigidbody[] bodies;
    const float spawnHeight = 2.5f;
    bool canReset = true;
    void Start()
    {
        player = transform.GetChild(0).gameObject;
        bodies = GetComponentsInChildren<Rigidbody>();
    }
    public void Reset(Checkpoint checkpoint)
    {
        if (canReset)
        {
            canReset = false;
            player.SetActive(false);
            GameObject des = Instantiate(destroyed, player.transform.position, player.transform.rotation);
            Rigidbody[] bits = des.GetComponentsInChildren<Rigidbody>();
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            foreach(Rigidbody r in bits)
            {
                r.velocity = playerRb.velocity;
            }
            StartCoroutine(WaitToRespawn(checkpoint));
        } 
    }
    public IEnumerator WaitToRespawn(Checkpoint checkpoint)
    {
        yield return new WaitForSeconds(2);
        player.transform.position = checkpoint.checkPoint.position + new Vector3(0, spawnHeight, 0);
        player.transform.rotation = checkpoint.checkPoint.rotation;
        foreach (var body in bodies)
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }
        player.SetActive(true);
        canReset = true;
    }
}

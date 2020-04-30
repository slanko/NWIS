using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] floaters;
    FixedJoint[] joints = new FixedJoint[4];
    Vector3[] connectedAnchors = new Vector3[4];
    [SerializeField] GameObject destroyed;
    Rigidbody[] bodies;
    const float spawnHeight = 2.5f;
    Rigidbody playerRb;
    bool canReset = true;
    Transform tempTransform;
    void Start()
    {
        player = transform.GetChild(0).gameObject;
        bodies = GetComponentsInChildren<Rigidbody>();
        playerRb = player.GetComponent<Rigidbody>();
        for (int i = 0; i < floaters.Length; i++)
        {
            joints[i] = floaters[i].GetComponent<FixedJoint>();
            connectedAnchors[i] = joints[i].connectedAnchor;
            floaters[i].GetComponent<FixedJoint>().autoConfigureConnectedAnchor = false;
        }
    }
    public void Reset(Checkpoint checkpoint, float time)
    {
        if (canReset)
        {
            canReset = false;
            tempTransform = Instantiate(new GameObject(), player.transform.position, player.transform.rotation).transform;
            tempTransform.parent = transform;
            SetParent(tempTransform);
            tempTransform.gameObject.SetActive(false);
            for (int i = 0; i < floaters.Length; i++)
            {
                floaters[i].gameObject.SetActive(false);
            }
            player.SetActive(false);
            GameObject des = Instantiate(destroyed, player.transform.position, player.transform.rotation);
            Rigidbody[] bits = des.GetComponentsInChildren<Rigidbody>();
            int iterations = bits.Length;
            for(int i =0;i<iterations;i++)
            {
                bits[i].velocity = playerRb.velocity;
            }
            StartCoroutine(WaitToRespawn(checkpoint,time));
        }
    }
    public IEnumerator WaitToRespawn(Checkpoint checkpoint, float time)
    {
        yield return new WaitForSeconds(time);
        tempTransform.position = checkpoint.checkPoint.position + new Vector3(0, spawnHeight, 0);
        tempTransform.rotation = checkpoint.checkPoint.rotation;
        SetParent(transform);
        Destroy(tempTransform.gameObject);

        int iterations = bodies.Length;
        for (int i = 0; i < iterations; i++)
        {
            bodies[i].velocity = Vector3.zero;
            bodies[i].angularVelocity = Vector3.zero;
        }
        player.SetActive(true);
        for (int i = 0; i < floaters.Length; i++)
        {
            floaters[i].GetComponent<FixedJoint>().connectedAnchor = connectedAnchors[i];
            floaters[i].gameObject.SetActive(true);
        }
        canReset = true;
    }
    void SetParent(Transform parent)
    {
        player.transform.parent = parent;
        for (int i = 0; i < floaters.Length; i++)
        {
            floaters[i].transform.parent = parent;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingCamScript : MonoBehaviour
{
    public GameObject followTarget;
    public float camFollowWeight;
    public Quaternion followDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followDirection = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, camFollowWeight);
        transform.rotation = Quaternion.Lerp(followDirection, followTarget.transform.rotation, camFollowWeight);
    }
}

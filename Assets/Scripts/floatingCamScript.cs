using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingCamScript : MonoBehaviour
{
    public GameObject followTarget;
    public float camFollowWeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, camFollowWeight);
        transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, camFollowWeight);
    }
}

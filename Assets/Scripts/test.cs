using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VideoPlayer>().Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

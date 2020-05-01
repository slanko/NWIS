using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fletchergowild : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = Random.Range(0.9f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloPulser : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator HaloPulse()
    {
        yield return new WaitForSeconds(1);
    }
}

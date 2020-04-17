using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed : MonoBehaviour
{
    Slider sL;
    public ShipControl sC;

    void Start()
    {
        sL = gameObject.GetComponent<Slider>();
    }
    void Update()
    {
        sL.value = sC.localVelocity.z;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour
{
    ShipControl control;
    [SerializeField] GameObject ui;
    private void Start()
    {
        control = GetComponent<ShipControl>();
    }
    public void Activate()
    {
        control.enabled = false;
        GetComponent<Rigidbody>().drag = 6;
        ui.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBuildings : MonoBehaviour
{
    public GameObject building;
    private void Start()
    {
        for(int i = 20; i > 0; i--)
        {
            Vector2 circle = Random.insideUnitCircle * transform.localScale.x;
            Vector3 add = new Vector3(circle.x, 0, circle.y);
            Instantiate(building, transform.position + add, Quaternion.identity);
        }
    }
}

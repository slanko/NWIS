using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGamePositions : MonoBehaviour
{
    [SerializeField] int pos;
    [SerializeField] Text text;
    private void Start()
    {
        if (Placings.placings[pos-1] != null)
        {
            GameObject g = Instantiate(Placings.placings[pos-1].demo, transform.position, transform.rotation);
            g.transform.parent = transform;
            text.text = Placings.placings[pos-1].screenName;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public int healthpips;
    public int numOfhealth;

    public Image[] Pips;
    public Sprite Pip1;
    public Sprite Pip2;
    public Sprite Pip3;
    public Sprite emptyPips;

    //health code
    void Update()
    {
        for (int i = 0; i < Pips.Length; i++)
        {
            if (healthpips > numOfhealth)
            {
                healthpips = numOfhealth;
            }

            if (i < numOfhealth)
            {
                Pips[i].enabled = true;
            }
            else
            {
                Pips[i].enabled = false;
            }
        }
    }

    //speed code
 

}

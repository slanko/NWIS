using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponSystem : MonoBehaviour
{
    //this turned out to be way more of a whole UI system, sorry 'bout that

    ShipControl sc;
    Animator padAnim;
    public GameObject missile, mine, missileLocation, mineLocation;
    public int mineCount, missileCount, shieldCount, boostCount;
    int randomNum;
    string mineButton, missileButton;
    GameObject instMissile;
    Quaternion missileRotation;
    public int health; 
    public Text missileCounter, mineCounter, shieldCounter, boostCounter;
    public GameObject healthPip1, healthPip2, healthPip3;
    public Slider speedometer;
    public Text speedText;

    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<ShipControl>();
        mineButton = sc.playerNum + "PB";
        missileButton = sc.playerNum + "PX";

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "weaponPad")
        {
            var wPadScript = other.GetComponent<weaponPadScript>();
            if(wPadScript.weaponDispensed == false)
            {
                wPadScript.weaponDispensed = true;
                randomNum = Random.Range(1, 3);
                if (randomNum == 1)
                {
                    mineCount++;
                }
                if (randomNum == 2)
                {
                    missileCount++;
                }
                padAnim = other.gameObject.GetComponent<Animator>();
                padAnim.SetTrigger("activate");
                wPadScript = null;
            }

        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }

        if (Input.GetButtonDown(mineButton))
        {
           if (mineCount > 0)
            {
                Instantiate(mine, mineLocation.transform.position, transform.rotation);
                mineCount -= 1;
            }
        }
        if (Input.GetButtonDown(missileButton))
        {
            if (missileCount > 0)
            {
                missileRotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                instMissile = Instantiate(missile, missileLocation.transform.position, transform.rotation);
                instMissile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(sc.localVelocity);
                missileCount -= 1;
            }
        }

        //update UI
        missileCounter.text = missileCount.ToString();
        mineCounter.text = mineCount.ToString();
        shieldCounter.text = shieldCount.ToString();
        boostCounter.text = boostCount.ToString();
        speedometer.value = sc.localVelocity.z;
        speedText.text = sc.localVelocity.z.ToString("F0");

        if(health == 3)
        {
            healthPip3.SetActive(true);
        }
        if(health == 2)
        {
            healthPip3.SetActive(false);
            healthPip2.SetActive(true);
        }
        if (health == 1)
        {
            healthPip2.SetActive(false);
            healthPip1.SetActive(true);
        }
        if (health == 0)
        {
            healthPip1.SetActive(false);
        }
    }
}

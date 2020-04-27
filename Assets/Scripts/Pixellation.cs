using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pixellation : MonoBehaviour
{
    [SerializeField] PixellationLevels levels;
    Dropdown dropdown;
    private void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.value = PlayerPrefs.GetInt("PixellationLevel", 2);
    }
    public void Activate()
    {
        levels.Set(dropdown.value);
    }
}

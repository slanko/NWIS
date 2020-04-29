using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void Setting()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

    public void Quitgame()
    {
        Debug.Log("quit");
        Application.Quit(); 
    }
}

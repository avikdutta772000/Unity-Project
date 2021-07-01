using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public string currentlevel;
    public void Gameover()
    {
        if (currentlevel == "Level 1")
        {
            SceneManager.LoadScene("game over 1");
        }
        if (currentlevel == "Level 2")
        {
            SceneManager.LoadScene("game over 2");
        }
        if (currentlevel == "Level 3")
        {
            SceneManager.LoadScene("game over 3");
        }
    }
    public void levelcomplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}

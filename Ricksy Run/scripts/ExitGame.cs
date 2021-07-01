using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to exit the game

public class ExitGame : MonoBehaviour
{
    public void exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

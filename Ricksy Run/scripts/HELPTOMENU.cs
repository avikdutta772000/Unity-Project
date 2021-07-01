using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//used to goto menu from help scene

public class HELPTOMENU : MonoBehaviour
{
   public void backbutton()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//loads the help scene

public class HELP : MonoBehaviour
{
   public void help()
    {
        SceneManager.LoadScene("Help");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//restarts the level, level name is given by public variable lastlevel
public class RestartLevel : MonoBehaviour
{
    public string lastlevel;
  public void restartlevel()
    {
        SceneManager.LoadScene(lastlevel);
    }
}

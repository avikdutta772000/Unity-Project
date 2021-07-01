using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvaschanger : MonoBehaviour
{
    
    public GameObject Audio;
    public bool gameIsPaused;
    public GameObject to;
   public void ChangeTo()
    {
        to.SetActive(true);
        Time.timeScale = 0f;
       gameIsPaused = true;

    }
   public void ChangeBack()
    {
        gameIsPaused = false;
        to.SetActive(false);
        Time.timeScale = 1f;
        
    }
    public void escape()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
       

    }
    public void StopSound()
    {
        Audio.SetActive(false);
    }
    public void RetryButton()
    {
        Scene current_Scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current_Scene.name);
    }
    
   
        
}

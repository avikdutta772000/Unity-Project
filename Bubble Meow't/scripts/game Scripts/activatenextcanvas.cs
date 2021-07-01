using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activatenextcanvas : MonoBehaviour
{

    public GameObject next;
    public GameObject prev;
    public GameObject canv;
    public void activateNext()
    {
        prev.SetActive(false);
        next.SetActive(true);

    }
    public void activatenextscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1) ;
    }
    public void activate_Easy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void activate_Medium()
    {
        SceneManager.LoadScene("Medium");
    }
    public void activate_Hard()
    {
        SceneManager.LoadScene("Hard");
    }
    public void leaderboardSceneShow()
    {
        SceneManager.LoadScene("Leaderboard Scene");
    }
    public void MenuActivation()
    {
        SceneManager.LoadScene("menu");
    }
    public void ActivateGivenCanvas()
    {
        canv.SetActive(true);
    }
}

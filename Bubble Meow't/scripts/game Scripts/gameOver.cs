using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{

    public double Hscore;
    public Text yourScore;
    public GameObject highhigh1;
    public GameObject highscoredisplay;
    public Text Highscore;
    public time Time1;
    public GameObject gameover2;
    public Text timer_Negative_Text;
    void Start()
    {
        GameObject.Find("AuthManager").GetComponent<RegisterScript>().HelpDisplayScore();
        
       //Highscore.text = PlayerPrefs.GetFloat("HighScore",0).ToString("F2");
        //timer_Negative_Text.text = "";
        // Highscore.text= GameObject.Find("AuthManager").GetComponent<RegisterScript>().DisplayUserScoreInGame();
    }
   
    public void GameOverScene(int state)
    {

        Hscore= GameObject.Find("DBManager").GetComponent<DatabaseScript>().HighScoreValue;
       // yield return new WaitUnitl(() => Hscore != 0);
        
        gameover2.SetActive(true);
        if (state == 1)
        {
            timer_Negative_Text.text = "Time dropped below 0\n\n" +
                "Note: Do not stay in the BLUE bubble for long.";
            yourScore.text = "0";
        }
        else
        {
            timer_Negative_Text.text = "";
            yourScore.text = Time1.timer.ToString("F2");
        }

        Debug.Log("High Score inside gOver " + GameObject.Find("DBManager").GetComponent<DatabaseScript>().HighScoreValue);
        
        if (Time1.timer >= Hscore)    //highscore achieved;
        {
            //PlayerPrefs.SetFloat("HighScore", Time1.timer);
            //Highscore.text = Time1.timer.ToString("F2");
            
            //Debug.Log("Aaya ki nhi");


            // highhigh1.SetActive(true);
            highscoredisplay.SetActive(true);

            GameObject.Find("AuthManager").GetComponent<RegisterScript>().UpdateUserScoreToDB(Time1.timer);
            GameObject.Find("DBManager").GetComponent<DatabaseScript>().HighScoreValue = Time1.timer;
           // GameObject.Find("HighScoreManager").GetComponent<StoresHighScore>().HighScoreValue = Time1.timer; //GameObject.Find("DBManager").GetComponent<DatabaseScript>().ReturnScore();
            // Highscore.text = GameObject.Find("AuthManager").GetComponent<RegisterScript>().DisplayUserScoreInGame();
        }
        

       // Time.timeScale = 0f;
        
            
            
        
        
        
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        Highscore.text = "0";
    }
   
   
   

}

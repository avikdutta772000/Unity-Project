using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoresHighScore : MonoBehaviour
{
    public Text HighScoreText;
    public Text UsernameText;
    IEnumerator Start()
    {
        GameObject.Find("AuthManager").GetComponent<RegisterScript>().HelpDisplayScore();
        
        yield return new WaitUntil(()=>GameObject.Find("DBManager").GetComponent<DatabaseScript>().HighScoreValue!=0);
       // double hscore = GameObject.Find("DBManager").GetComponent<DatabaseScript>().HighScoreValue;
        HighScoreText.text = GameObject.Find("DBManager").GetComponent<DatabaseScript>().HighScoreValue.ToString("F2");
        // GameObject.Find("DBManager").GetComponent<DatabaseScript>().SortingLeaderboard(hscore);
        UsernameText.text = GameObject.Find("DBManager").GetComponent<DatabaseScript>().usernameValue;

    }
   
    
}

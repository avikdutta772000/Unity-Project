using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yourscore : MonoBehaviour
{
    public Text myScore;
    public time Time1;
    public void DisplaymyScore()
    {
        myScore.text = Time1.timer.ToString("F2");
    }
}

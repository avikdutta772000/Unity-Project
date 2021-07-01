using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    
    public Text timetext;
    public float timer;
    public bool checktime;
    void Start()
    {
        checktime = true;
        timer = 0.0f;
        timetext.text = timer.ToString("F2");
    }
    void Update()
    {
        if(checktime)
        timer += Time.deltaTime*1;
        timetext.text = timer.ToString("F2");
    }
}

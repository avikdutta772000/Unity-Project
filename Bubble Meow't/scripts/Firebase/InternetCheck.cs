using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetCheck : MonoBehaviour
{
    public GameObject canv;
    void Start()
    {
        canv = GameObject.Find("Internet Canvas");
        canv.SetActive(false);
    }    
    void Update()
    {
        CheckInternetConnection();
        
    }
    public void CheckInternetConnection()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Check your internet connection");
            canv.SetActive(true);
        }
    }
    public void OkButton()
    {
        canv.SetActive(false);
    }
}

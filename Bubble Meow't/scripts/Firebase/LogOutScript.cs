using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOutScript : MonoBehaviour
{
   
    // Start is called before the first frame update
   

    // Update is called once per frame
    public void OnSigningOut()
    {
        
        GameObject.Find("AuthManager").GetComponent<RegisterScript>().OnLogOutButtonClick();
       
    }
}

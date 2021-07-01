using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase.Analytics;
using Firebase.Extensions;


public class LogInSceneScriot : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
  

    /*void Start()
    {
        Firebase.Auth.FirebaseAuth.DefaultInstance.StateChanged += HandleAuthStateChanged;
        CheckUser();
    }*/
    private void OnDestroy()
    {
        Firebase.Auth.FirebaseAuth.DefaultInstance.StateChanged -= HandleAuthStateChanged;
    }
    private void HandleAuthStateChanged(object sender,System.EventArgs e)
    {
        CheckUser();
    }
    private void CheckUser()
    {
        if(Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser!=null)
        {
            SceneManager.LoadScene(sceneToLoad);
            
        }
    }
    public void sceneChanger()
    {
        SceneManager.LoadScene("menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using Firebase.Unity.Editor;
public class FirebaseInit : MonoBehaviour
{
    //public UnityEvent OnFirebaseInitialized = new UnityEvent();
    public bool state;
    private void Start()
    {
        //for initializing Analytics
        state = false;
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;
                InitializeFirebase();
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
           

        });

        void InitializeFirebase()
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);

            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://bubble-meow-t.firebaseio.com/");
            state = true;
            Debug.Log("Abhi hua Initialize");
        }

        //for initializing Database 
        /* FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
         {
             if (task.Exception!=null)
             {
                 Debug.LogError("Failed to intialize Firebase with {task.Exception}");
                 return;
             }
             OnFirebaseInitialized.Invoke();


         });

     */





    }
}
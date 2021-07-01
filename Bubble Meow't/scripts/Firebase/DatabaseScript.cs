using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase.Analytics;
using Firebase.Extensions;

public class DatabaseScript : MonoBehaviour
{
    public UnityEvent OnFirebaseInitialized = new UnityEvent();

    private HighScoreTableScript hstScript;
    private UserHighScoreTable hstScriptUser;

    public DatabaseReference reference;
    private DatabaseReference db;
    public RegisterScript reg;
    public double HighScoreValue;

    private string val;

    public List<HighScoreEntry> highscoreEntryList;
    public bool filled;
    public bool filledUser;
    public string usernameValue;


    //  public float valFloat;


    //private gameOver highScore;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        /*FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError("Failed to intialize Firebase with {task.Exception}");
                return;
            }
            OnFirebaseInitialized.Invoke();


        });*/
        yield return new WaitUntil(() => GameObject.Find("Manage Canvas").GetComponent<FirebaseInit>().state);
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://bubble-meow-t.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
       // leaderManage = GameObject.Find("LeaderboardManager").GetComponent<LeaderboardScript>();


    }


    
    //***********************************************************************


    public void ShowData()
    {
      db.GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;

          }
      });

    }
    
    //********************************************************
    

    public void SortingLeaderboardTill20()
    {
        
        hstScript = GameObject.Find("HighScore Table").GetComponent<HighScoreTableScript>();
        filled = false;
        
        
        reference.Child("users").OrderByChild("score").LimitToLast(20).GetValueAsync().ContinueWith(task => { 
        if (task.IsFaulted)
        {
            Debug.Log("error showing data");
            return;
        }
        else if (task.IsCompleted)
        {
                
                DataSnapshot snapshot = task.Result;
                
                foreach (DataSnapshot ds in snapshot.Children)
                {
                    
                    Dictionary<string,object> val =(Dictionary<string,object>)ds.Value;

                     HighScoreEntry ob = new HighScoreEntry();


                     ob.score = (double)val["score"];

                     ob.name = (string)val["username"];
                  

                    //  hstScript.highscoreEntryList = new List<HighScoreEntry>() {ob};
                    hstScript.highscoreEntryList.Add(ob);

                    
                   
                    //hstScript.highscoreEntryList.Add(new HighScoreEntry { score=(double)val["score"],name=(string)val["username"]});
                    
                  
                }
                
                filled = true;
               
            } });

    }


    //*******************************************************




    public void SortingLeaderboardTillUser(double scorer)
    {
        hstScriptUser = GameObject.Find("HighScore Table User").GetComponent<UserHighScoreTable>();
        filledUser = false;
        reference.Child("users").OrderByChild("score").StartAt(scorer).GetValueAsync().ContinueWith(task => {                 //edit kro
            if (task.IsFaulted)
            {
                Debug.Log("error showing data");
                return;
            }
            else if (task.IsCompleted)
            {

                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot ds in snapshot.Children)
                {

                    Dictionary<string, object> val = (Dictionary<string, object>)ds.Value;

                    HighScoreEntry ob = new HighScoreEntry();

                    
                    ob.score = (double)val["score"];

                    ob.name = (string)val["username"];

               
                    //  hstScript.highscoreEntryList = new List<HighScoreEntry>() {ob};
                    hstScriptUser.highscoreEntryListUser.Add(ob);
                    


                    //hstScript.highscoreEntryList.Add(new HighScoreEntry { score=(double)val["score"],name=(string)val["username"]});


                }
               
                filledUser = true;

            }
        });

    }




    //******************************************************


  
    public void writeNewUser(string userId, string name, string email)
    {
        User user = new User(name, email,0.0);
        string json = JsonUtility.ToJson(user);

        reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }
    public void UpdateUserScore(double score,string userId)
    {
        
        reference.Child("users").Child(userId).Child("score").SetValueAsync(score);

    }
    
    
    //*****************************************************


    public void DisplayUserScore(string userId)
    {
        
        reference.Child("users").Child(userId).GetValueAsync().ContinueWith(task =>
        {
            
            if (task.IsFaulted)
            {
                Debug.Log("Error occured in displaying score");
                return;
            }
            else if(task.IsCompleted)
            {
                
                //DataSnapshot snapshot = task.Result;
                Dictionary<string, object> data = (Dictionary<string, object>)task.Result.Value;
                
                HighScoreValue = (double)data["score"];
                usernameValue = (string)data["username"];

               
                
                
               // GameObject.Find("HighScoreManager").GetComponent<StoresHighScore>().HighScoreValue = (float)data["score"];
                





            }
            
        });
        
      
    }

    

    //***************************************************
    














}

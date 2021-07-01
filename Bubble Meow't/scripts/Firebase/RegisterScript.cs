using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using UnityEngine.SceneManagement;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase.Analytics;
using Firebase.Extensions;



public class RegisterScript : MonoBehaviour
{
    [SerializeField]
    private InputField userIdField;

    [SerializeField]
    private InputField emailField;

    [SerializeField]
    private InputField passwordField;

    [SerializeField]
    private InputField emailFieldSignIn;

    [SerializeField]
    private InputField passwordFieldSignIn;

    public State registerState;
    private string instuct;

    Firebase.Auth.FirebaseAuth auth;
    public Firebase.Auth.FirebaseUser user;

    public bool signedIn;

    public DatabaseScript DBScript;
    public Text textMessageIn;
    public Text textMessageUp;

    

    public enum State
    {
        InvalidEmail,
        EnteruserId,
        Enteremail,
        EnterPassword,
        ok
    }


    IEnumerator Start()
    {
        yield return new WaitUntil(() => GameObject.Find("Manage Canvas").GetComponent<FirebaseInit>().state);
        registerState = State.EnteruserId;
        instuct = "Enter userId";
        InitializeFirebase();


        
    }
   
    
    

    private void ComputeStateSignUp()
    {
        if(string.IsNullOrEmpty(userIdField.text))
        {
            registerState = State.EnteruserId;
            instuct = "Enter userId";
        }
        else if (string.IsNullOrEmpty(emailField.text))
        {
            registerState = State.Enteremail;
            instuct = "Enter email";
        }
        else if (string.IsNullOrEmpty(passwordField.text))
        {
            registerState = State.EnterPassword;
            instuct = "Enter Password";
        }
        else if(emailField.text.IndexOf('@')<=0)
        {
            
            registerState = State.InvalidEmail;
            instuct = "Invalid email Id";
        }
        else
        {
            registerState = State.ok;
            
        }
    }

    private void ComputeStateSignIn()
    {
        
        if (string.IsNullOrEmpty(emailFieldSignIn.text))
        {
            registerState = State.Enteremail;
            instuct = "Enter email";
        }
        else if (string.IsNullOrEmpty(passwordFieldSignIn.text))
        {
            registerState = State.EnterPassword;
            instuct = "Enter Password";
        }
        else if (emailFieldSignIn.text.IndexOf('@') <= 0)
        {

            registerState = State.InvalidEmail;
            instuct = "Invalid email Id";
        }
        else
        {
            registerState = State.ok;

        }
    }


    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }


    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        Debug.Log("Andar ghusa");
        if (auth.CurrentUser != user)
        {
            signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                
               
                Debug.Log("Signed in " + user.UserId);
                Debug.Log("Email : " + user.Email);
                SceneManager.LoadScene("menu");
                

            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }






    public void OnSignUpButtonClick()
    {
        ComputeStateSignUp();
        if(registerState==State.ok)
        {
            Debug.Log("baat aage badao");
            //UserUid = userIdField.text;
            StartCoroutine(SignUpUser(emailField.text, passwordField.text));


        }
        else
        {
            textMessageUp.text = instuct;
            Debug.Log(instuct);
        }
    }

    public void OnSignInButtonClick()
    {
        ComputeStateSignIn();
        if (registerState == State.ok)
        {
            Debug.Log("baat aage badao");
            //UserUid = userIdField.text;
            StartCoroutine(SignInUser(emailFieldSignIn.text, passwordFieldSignIn.text));


        }
        else
        {
            textMessageIn.text = instuct;
            Debug.Log(instuct);
        }
    }



    public IEnumerator SignUpUser(string email,string password)
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(()=>registerTask.IsCompleted);
        if(registerTask.Exception!=null)
        {
            Debug.Log("Error during Registration");
            textMessageUp.text = "Error during Registration. Try Again.";
        }
        else
        {
            Debug.Log("Registered Succesfully");
            textMessageUp.text = "Registered Successfuly";
            user = registerTask.Result;
            
        }
        WriteToDB();
    }
    public IEnumerator SignInUser(string email,string password)
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        var signinTask = auth.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(()=>signinTask.IsCompleted);
        if(signinTask.Exception!=null)
        {
            Debug.Log("Unable to SignIn");
            textMessageIn.text="Unable to Sign In. Try Again.";
        }
        else
        {
            Debug.Log("SignIn Succesful");
            textMessageIn.text = "SignIn Successful";
            user = signinTask.Result;
            
        }
        
       
    }
    public void OnLogOutButtonClick()
    {
        
        auth.SignOut();
        //SceneManager.LoadScene("Login Scene");
    }
    public void WriteToDB()
    {

        DBScript.writeNewUser(user.UserId,userIdField.text,user.Email);
    }
    public void UpdateUserScoreToDB(float score)
    {
        DBScript.UpdateUserScore(score, user.UserId);
    }
    public void HelpDisplayScore()
    {
        DBScript.DisplayUserScore(user.UserId);
    }




    




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class player : MonoBehaviour
{
    
    public AudioSource popSound;
    public AudioSource boingSound;
    
    public canvaschanger can;
    
    public int health;
    
    public gameOver gOver;
    
    public int maxhealth = 100;
    public health healthbar;
    
    private int state=0;
    public time timer1;
    private float alpha_Value_Out=1f;
    private float alpha_Value_In = 0.5f;
    
    public GameObject time_Dec;
    public float blue_Time_Reduce;
    public int blue_Health_inc;
    public int dec_Idle;
    public int dec_Green;
    public int dec_Yellow;

    private int audioState;
    private float maxRevive = 7.0f;
    private float revive;
    public GameObject revive_Button;
    public Image reviveBarSlider;
    public GameObject ReviveCanvas;

    private int reviveTimeCalling = 0;

    public AdManagerScript rewardedAd;

    private bool buttonIsClicked;
    


    void Start()
    {
        can.gameIsPaused = false;
        health = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        time_Dec.SetActive(false);
        audioState = 0;
        ReviveCanvas.SetActive(false);
        buttonIsClicked = false;
        
    }
   
    void Update()
    {
        
        if (!can.gameIsPaused)
        {
            
            GameObject closer = distance();
            timer1.checktime = true;

            if (closer != null)
            {
                if(audioState==0)
                {
                    popSound.Play();
                    audioState = 1;
                }
                
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha_Value_In);
                transform.position = closer.transform.position;
                healthmanage(closer);
            }
            else
            {
                audioState = 0;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha_Value_Out);
                health = health - dec_Idle;
                healthbar.SetHealth(health);
                time_Dec.SetActive(false);

            }


            

            //gameOver condition
            if (health < 0 || timer1.timer < 0 || transform.position.y > 5.21 || transform.position.y < -5.21 || transform.position.x > 2.28 || transform.position.x < -2.28)
            {
                if(timer1.timer < 0)
                {
                     state = 1;
                }
                else
                {
                    state = 0;
                }
                // Debug.Log("Game Over");
                //Destroy(this);
                boingSound.Play();                                                //gameOver sound
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha_Value_Out);              //color remains intact
                if (reviveTimeCalling == 0)
                {
                    can.gameIsPaused = true;           //will pause the spawning
                    timer1.checktime = false;
                    reviveTimeCalling++;
                    Revive();
                }
                else
                {
                    finalGameOver();
                }                       
                
            }
        }
        
        
        
        else                                                                               //working on the Revive
        {
            if(reviveTimeCalling==1)
            {
                if (!buttonIsClicked)
                {
                    revive -= Time.deltaTime * 1.0f/maxRevive;
                    
                }
                SetReviveBar(revive);

                if (rewardedAd.giveReward&&revive>0.0f)
                {
                    health = maxhealth;
                    this.transform.position = new Vector3(0, 0, 0);
                    reviveTimeCalling++;
                    can.gameIsPaused = false;
                    
                }
                if (revive <= 0)
                {
                    // gOver.GameOverScene(state);
                    //  ReviveCanvas.SetActive(false);
                    finalGameOver();
                }

            }
        }
    }

    public void finalGameOver()
    {
        Destroy(this);
        timer1.checktime = false;
        gOver.GameOverScene(state);
    }    
        
    
    public GameObject distance()
    {
        GameObject[] currobj;
        GameObject closest = null;
        currobj = GameObject.FindGameObjectsWithTag("Respawn");
        float mindistance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject go in currobj)
        {
            Vector3 diff = go.transform.position - position;
            float dist = diff.magnitude;
            if(dist<mindistance)
            {
                mindistance = dist;
                closest = go;
            }
        }
        if (mindistance <= 1.2)
            return closest;
        else
            return null;
    }
   
    
    
    
    
  
    
    public void healthmanage(GameObject ob)
    {
        
        
            if (ob.name == "blue(Clone)")
            {
           
                health = health + blue_Health_inc;
                timer1.checktime = false;
                timer1.timer -= Time.deltaTime * blue_Time_Reduce;
                time_Dec.SetActive(true);
            }
            if (ob.name == "green(Clone)")
            {

                health = health - dec_Green;
            }
            if (ob.name == "yellow(Clone)")
            {

                health = health - dec_Yellow;
            }
            if (health > maxhealth)
                health = maxhealth;

        
            
          
       
        
        healthbar.SetHealth(health);
        
    }
   
    
    
    
    
    
    
    
    
    
    public void Revive()
    {
        ReviveCanvas.SetActive(true);
        SetMaxRevive();

    }
    public void SetReviveBar(float revive)
    {
        reviveBarSlider.fillAmount = revive;
    }
    public void SetMaxRevive()
    {
        reviveBarSlider.fillAmount = 1;
        revive=1.0f;

    }
    public void OnClickingReviveButton()
    {
        Debug.Log("Button click hua hai");
        buttonIsClicked = true;
        rewardedAd.ShowVideoRewardAd();
        ReviveCanvas.SetActive(false);
        //Show the ad
        //resume the play with full health.
    }
    
            
       
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public canvaschanger can;
    public GameObject[] bubbles;
    public int count;
    public int count_Limit;
    public int count_respawn;
    public int respawnTime;
    public int respawn_Time_inc;
   void Start()
    {
        GameObject b = Instantiate(bubbles[0]) as GameObject;
        b.transform.position = new Vector2(Random.Range(-2.28f, 2.28f), -6.5f);
        count = 0;
        count_respawn = 0;
    }
    void Update()
    {
        if (!can.gameIsPaused)
        {
            count++;
            if (count > respawnTime)
            {
                respawnBubbles();
                count = 0;

            }
            count_respawn++;
            if(count_respawn>respawn_Time_inc&&respawnTime>count_Limit)
            {
                respawnTime--;
                count_respawn = 0;
            }
                

        }
    }
   
    public void respawnBubbles()
    {
        GameObject a = Instantiate(bubbles[UnityEngine.Random.Range(0, bubbles.Length)]) as GameObject;
        a.transform.position = new Vector2(Random.Range(-2.28f, 2.28f), -6.5f);
        count = 0;
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    //this script is attached to Camera gameobject
    private Camera mainCamera;
    private Vector2 screenBounds;
    public GameObject platformPrefab;
    public GameObject surprisePrefab;
    public GameObject zombieHandsPrefab;
    public GameObject startPlatform;
    [HideInInspector]
    public GameObject prevPlatform;
    private GameObject newPlatform;
    private float offset;
    private GameObject parentPlatform;
    private long countPlatform;
    public int countRegion;
    public int[] mark;
    public int blanks=2;
    private int multMag;
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        prevPlatform = startPlatform;
        offset= screenBounds.x * 3;
        parentPlatform = GameObject.Find("Platform Generation");
        mark = new int[countRegion+1];
        countPlatform = -1;
        multMag = 2;
    }
    void Update()
    {
        AddPlatform();
        RemovePlatform();

    }
    void RemovePlatform()
    {
        if(transform.position.x- parentPlatform.transform.GetChild(0).transform.position.x>offset)
        {
            
            Destroy(parentPlatform.transform.GetChild(0).gameObject);
            
        }
    }
    void AddPlatform()
    {
        if(prevPlatform.transform.position.x-transform.position.x<=offset)
        {
            //instantiatePlatform();
            countPlatform++;
            int plat = (int)((countPlatform % countRegion) + 1);//plat ranges from 1 to countRegion
            if(plat==1)
            {
                determineObstacles();
            }
            implementObstacle(plat);
        }
        
    }


    void instantiatePlatform()
    {
        float distLeftRightEdge = multMag*(prevPlatform.transform.GetChild(1).transform.position.x - prevPlatform.transform.GetChild(0).transform.position.x);
        newPlatform = Instantiate(platformPrefab, new Vector3(prevPlatform.transform.position.x+distLeftRightEdge, prevPlatform.transform.position.y, prevPlatform.transform.position.z), Quaternion.identity);
        newPlatform.transform.parent = parentPlatform.transform;
        prevPlatform = newPlatform;
        multMag = 2;
    }
    void instantiateSurpPlatform()
    {
        float distLeftRightEdge = 2 * (prevPlatform.transform.GetChild(1).transform.position.x - prevPlatform.transform.GetChild(0).transform.position.x);
        GameObject newSurpPlatform = Instantiate(surprisePrefab, new Vector3(prevPlatform.transform.position.x + distLeftRightEdge, prevPlatform.transform.position.y, prevPlatform.transform.position.z), Quaternion.identity);
        newSurpPlatform.transform.parent = parentPlatform.transform;
        //prevPlatform = newPlatform;
        multMag = 4;
    }

    void determineObstacles()
    {
        //Set mark to 0 when there is no obstacle
        //Set mark to 1 when there is pit
        //Set mark to 2 when there is surprise pit
        //Set mark to 3 when there is zombie hands
        //Set mark to 4 when it is occupied

        int i;
        for(i=0;i<=countRegion;i++)
        {
            mark[i] = 0;
        }

        //set platform position for pit
        int numOfPit = (int)Random.Range(1f, 2.2f);
        int pitPos;

        do
        {
            pitPos= (int)Random.Range(1f, countRegion);
            if(mark[pitPos]>0||pitPos==1)//||pitPos==countRegion)
            {
                continue;
            }
            else
            {
                
                if (pitPos - blanks < 1)
                {
                    i = 1;
                }
                else
                {
                    i = pitPos - blanks;
                }
                for(;i<=pitPos+blanks&&i<=countRegion;i++)
                {
                    mark[i] = 4;
                }
                mark[pitPos] = 1;
                numOfPit--;
            }
        } while (numOfPit>0);

        //set plat for surprise pit
        int numOfSurp = (int)Random.Range(1f, 2.2f);
        int surpPos;
        do
        {
            surpPos = (int)Random.Range(1f, countRegion);
            if(mark[surpPos]>0||surpPos==1)//||handPos==countRegion)
            {
                continue;
            }
            else
            {
                if(surpPos-blanks<1)
                {
                    i = 1;
                }
                else
                {
                    i = surpPos - blanks;
                }
                for(;i<=countRegion&&i<=surpPos+blanks;i++)
                {
                    mark[i] = 4;
                }
                mark[surpPos] = 2;
                numOfSurp--;
            }
        } while (numOfSurp>0);

        //set plat for zombie hands
        int numOfHands = (int)Random.Range(1f, 2.2f);
        int handPos;
        do
        {
            handPos = (int)Random.Range(1f, countRegion);
            if(mark[handPos]>0||handPos==1)//||handPos==countRegion)
            {
                continue;
            }
            else
            {
                if(handPos-blanks<1)
                {
                    i = 1;
                }
                else
                {
                    i = handPos - blanks;
                }
                for(;i<=countRegion&&i<=handPos+blanks;i++)
                {
                    mark[i] = 4;
                }
                mark[handPos] = 3;
                numOfHands--;
            }
        } while (numOfHands>0);
    }

    void implementObstacle(int plat)
    {
        if(mark[plat]==0||mark[plat]==4)
        {
            instantiatePlatform();
        }
        if(mark[plat]==1)
        {
            //pit formation
            instantiatePlatform();
            newPlatform.SetActive(false);
        }
        if(mark[plat]==2)
        {
            //surprise pit formation
            instantiateSurpPlatform();
        }
        if(mark[plat]==3)
        {
            //zombie hands formation
            instantiatePlatform();
            GameObject zombHand=Instantiate(zombieHandsPrefab, new Vector3(prevPlatform.transform.position.x, -0.5f, prevPlatform.transform.position.z), Quaternion.identity);
        }

    }
}

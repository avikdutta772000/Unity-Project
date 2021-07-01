using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserHighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    public List<HighScoreEntry> highscoreEntryListUser;
    private List<Transform> highscoreEntryTransformListUser;
    private int countRank;
    private int count;
    private IEnumerator Start()
    {
        entryContainer = transform.Find("HighScoreEntryContainerUser");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplateUser");

        entryTemplate.gameObject.SetActive(false);
        
        highscoreEntryListUser = new List<HighScoreEntry>();

        double Hscore = GameObject.Find("DBManager").GetComponent<DatabaseScript>().HighScoreValue;
        GameObject.Find("DBManager").GetComponent<DatabaseScript>().SortingLeaderboardTillUser(Hscore);
        yield return new WaitUntil(() => GameObject.Find("DBManager").GetComponent<DatabaseScript>().filledUser == true);
        
        highscoreEntryListUser.Reverse();

       //******************
        
        
        count = highscoreEntryListUser.Count;
        
        countRank = 0;
        int diffcount = count - 19;
        int p = 1;
      
        //****************************
        
        
        highscoreEntryTransformListUser = new List<Transform>();
       
        
        
        foreach (HighScoreEntry highscoreEntry in highscoreEntryListUser)
        {
            //*********************************
              countRank++;
              if(countRank<=3)
              {
                  CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformListUser);
              }
              else
              {
                  if(p<=diffcount)
                  {
                      p++;
                      continue;
                  }
                  else
                  {
                      CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformListUser);
                  }



              }
           // CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformListUser);
            //************************************
        }
    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        
        float TemplateHeight = 80f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -TemplateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        int rank;
       // rank = transformList.Count + 1;
        if (countRank<=3)
        {
            rank = transformList.Count + 1;
        }
        else
        {
            rank = countRank;
        }
        
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "th"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;

        }
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        double score = highscoreEntry.score;                                                           //marker
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString("F2");
        string name = highscoreEntry.name;                                                                        //marker
        entryTransform.Find("nameText").GetComponent<Text>().text = name;


        entryTransform.Find("backgroundUser").gameObject.SetActive(rank % 2 != 0);

        if (GameObject.Find("DBManager").GetComponent<DatabaseScript>().usernameValue == name)
        {
            Debug.Log("#####");
            entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;

        }
        if (rank == 1)
        {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.yellow;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.yellow;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.yellow;
        }


        switch (rank)
        {
            default:
                entryTransform.Find("trophy1 (1)").gameObject.SetActive(false);
                entryTransform.Find("trophy2 (1)").gameObject.SetActive(false);
                entryTransform.Find("trophy3 (1)").gameObject.SetActive(false); break;
            case 1:
                entryTransform.Find("trophy1 (1)").gameObject.SetActive(true);
                entryTransform.Find("trophy2 (1)").gameObject.SetActive(false);
                entryTransform.Find("trophy3 (1)").gameObject.SetActive(false); break;
            case 2:
                entryTransform.Find("trophy1 (1)").gameObject.SetActive(false);
                entryTransform.Find("trophy2 (1)").gameObject.SetActive(true);
                entryTransform.Find("trophy3 (1)").gameObject.SetActive(false); break;
            case 3:
                entryTransform.Find("trophy1 (1)").gameObject.SetActive(false);
                entryTransform.Find("trophy2 (1)").gameObject.SetActive(false);
                entryTransform.Find("trophy3 (1)").gameObject.SetActive(true); break;
        }






        transformList.Add(entryTransform);
        if(rank==3&&count>20)
        {
            Transform entryTransformBlank = Instantiate(entryTemplate, container);
            RectTransform entryRectTransformBlank = entryTransformBlank.GetComponent<RectTransform>();
            entryRectTransformBlank.anchoredPosition = new Vector2(0, -TemplateHeight * transformList.Count);
            entryTransformBlank.gameObject.SetActive(true);
            entryTransformBlank.Find("posText").GetComponent<Text>().text = "";
            entryTransformBlank.Find("scoreText").GetComponent<Text>().text = "";
            entryTransformBlank.Find("nameText").GetComponent<Text>().text = "";
            transformList.Add(entryTransformBlank);
            entryTransformBlank.Find("trophy1 (1)").gameObject.SetActive(false);
            entryTransformBlank.Find("trophy2 (1)").gameObject.SetActive(false);
            entryTransformBlank.Find("trophy3 (1)").gameObject.SetActive(false);

        }
    }
    
}
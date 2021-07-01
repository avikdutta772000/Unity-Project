using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreTableScript : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    public List<HighScoreEntry> highscoreEntryList;     //scores top 20
    
    private List<Transform> highscoreEntryTransformList;
    

    private IEnumerator Start()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);


        highscoreEntryList = new List<HighScoreEntry>();



        


        GameObject.Find("DBManager").GetComponent<DatabaseScript>().SortingLeaderboardTill20();

        yield return new WaitUntil(() => GameObject.Find("DBManager").GetComponent<DatabaseScript>().filled == true);
        highscoreEntryList.Reverse();
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }




        //******** fill in the highscore list  ***************

        


    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry,Transform container,List<Transform> transformList)
    {
        float TemplateHeight = 80f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -TemplateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
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
        
        
        //highlighting entries
        entryTransform.Find("background").gameObject.SetActive(rank % 2 != 0);
        if(GameObject.Find("DBManager").GetComponent<DatabaseScript>().usernameValue==name)
        {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;

        }
        if(rank==1)
        {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.yellow;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.yellow;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.yellow;
        }

        switch (rank)
        {
            default:
                entryTransform.Find("trophy1").gameObject.SetActive(false);
                entryTransform.Find("trophy2").gameObject.SetActive(false);
                entryTransform.Find("trophy3").gameObject.SetActive(false); break;
            case 1:
                entryTransform.Find("trophy1").gameObject.SetActive(true);
                entryTransform.Find("trophy2").gameObject.SetActive(false);
                entryTransform.Find("trophy3").gameObject.SetActive(false); break;
            case 2:
                entryTransform.Find("trophy1").gameObject.SetActive(false);
                entryTransform.Find("trophy2").gameObject.SetActive(true);
                entryTransform.Find("trophy3").gameObject.SetActive(false); break;
            case 3:
                entryTransform.Find("trophy1").gameObject.SetActive(false);
                entryTransform.Find("trophy2").gameObject.SetActive(false);
                entryTransform.Find("trophy3").gameObject.SetActive(true); break;
        }


        transformList.Add(entryTransform);
    }


    
    
}

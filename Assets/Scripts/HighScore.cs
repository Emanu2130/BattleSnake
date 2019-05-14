using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour{
    
    private GameObject entryContainer;
    private Transform entryTemplate;
    private Transform realEntryContainer;
    private List<int> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    private void Awake(){
        entryContainer =  GameObject.FindGameObjectWithTag("HighScoreBox");
        realEntryContainer = entryContainer.transform;
        entryTemplate = realEntryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<int>(){
            100,200,300,400,500
        };

        for (int i = 0; i < highScoreEntryList.Count; i++)
        {
            for (int j = 0; j < highScoreEntryList.Count; j++)
            {
                if(highScoreEntryList[i] > highScoreEntryList[j]){
                    int tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                 }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (int highScoreEntry in highScoreEntryList){
            createHighScoreEntry(highScoreEntry, realEntryContainer, highScoreEntryTransformList);
        }
        

    }

    private void createHighScoreEntry(int highScoreEntry, Transform container, List<Transform> transformList){
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector3(0, (-90 * transformList.Count), 0);
            entryTransform.gameObject.SetActive(true);

            int rank = 1 + transformList.Count;
            string rankString = rank.ToString();
            entryTransform.Find("Position").GetComponent<Text>().text = rankString;
            entryTransform.Find("Score").GetComponent<Text>().text = highScoreEntry.ToString();
            transformList.Add(entryTransform);
    }
}


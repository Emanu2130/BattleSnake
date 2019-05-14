using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour{
    
    private GameObject entryContainer;
    private Transform entryTemplate;
    private Transform realEntryContainer;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    private void Awake(){
        entryContainer =  GameObject.FindGameObjectWithTag("HighScoreBox");
        realEntryContainer = entryContainer.transform;
        entryTemplate = realEntryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<HighScoreEntry>(){
            new HighScoreEntry {Score = 500},
            new HighScoreEntry {Score = 120},
            new HighScoreEntry {Score = 150},
            new HighScoreEntry {Score = 320},
            new HighScoreEntry {Score = 400},
        };

        for (int i = 0; i < highScoreEntryList.Count; i++)
        {
            for (int j = 0; j < highScoreEntryList.Count; j++)
            {
                if(highScoreEntryList[i].Score > highScoreEntryList[j].Score){
                    HighScoreEntry tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                 }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScoreEntryList){
            createHighScoreEntry(highScoreEntry, realEntryContainer, highScoreEntryTransformList);
        }
        HighScores allHighScores = new HighScores{HighScoreEntryList = highScoreEntryList};
        string json = JsonUtility.ToJson(allHighScores);
        PlayerPrefs.SetString("HighScoreTables", json);
        PlayerPrefs.Save();
        print(PlayerPrefs.GetString("HighScoreTables"));

    }

    private void createHighScoreEntry(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList){
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector3(0, (-90 * transformList.Count), 0);
            entryTransform.gameObject.SetActive(true);

            int rank = 1 + transformList.Count;
            string rankString = rank.ToString();
            entryTransform.Find("Position").GetComponent<Text>().text = rankString;
            entryTransform.Find("Score").GetComponent<Text>().text = highScoreEntry.Score.ToString();
            transformList.Add(entryTransform);
    }

    private class HighScores
    {
        public List<HighScoreEntry> HighScoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry{
        public int Score;
    }
}


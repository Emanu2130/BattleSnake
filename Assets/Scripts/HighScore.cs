using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{

    private GameObject highScoreContainer;
    private List<HighScoreItem> HighScoreList;
    private List<Transform> HighScoreItemTransformList;

    private GameObject TopList;
    public Text Score;
    public Text position;
    // Start is called before the first frame update
    private void Awake(){
        TopList =  GameObject.FindGameObjectWithTag("HighScoreBox");
        highScoreContainer =  GameObject.FindGameObjectWithTag("HighScoreList");
        highScoreContainer.gameObject.SetActive(false);
        HighScoreList = new List<HighScoreItem>(){
            new HighScoreItem{Score = 120},
            new HighScoreItem{Score = 1220},
            new HighScoreItem{Score = 1320},
            new HighScoreItem{Score = 1420},
            new HighScoreItem{Score = 1520},
            new HighScoreItem{Score = 1620},
            new HighScoreItem{Score = 1720},
            new HighScoreItem{Score = 1280},
        };
        HighScoreItemTransformList = new List<Transform>();
        foreach (HighScoreItem item in HighScoreList){
            print(TopList.transform);
            createHighScoreEntryTransform(item, TopList.transform, HighScoreItemTransformList);
        }
    }

    private void createHighScoreEntryTransform(HighScoreItem item, Transform container, List<Transform> transformList){
        Transform highScoreTransform = Instantiate(highScoreContainer.transform, container);
        RectTransform highScoreRectTransform = highScoreTransform.GetComponent<RectTransform>();

        switch(transformList.Count){
            case 0:
                Score.text = item.Score.ToString();
                position.text = "2";
                highScoreRectTransform.anchoredPosition = new Vector3(0, 140, 0);
                break;
                
            case 1:
                Score.text = item.Score.ToString();
                position.text = "3";
                highScoreRectTransform.anchoredPosition = new Vector3(0, 45, 0);
                break;

            case 2:
                Score.text = item.Score.ToString();
                position.text = "4";
                highScoreRectTransform.anchoredPosition = new Vector3(0, -45, 0);
                break;

            case 3:
                Score.text = item.Score.ToString();
                position.text = "5";
                highScoreRectTransform.anchoredPosition = new Vector3(0, -140, 0);
                break;

            case 4:
                Score.text = item.Score.ToString();
                position.text = "1";
                highScoreRectTransform.anchoredPosition = new Vector3(0, -235, 0);
                break;
        }
        transformList.Add(highScoreTransform);
        //highScoreContainer.gameObject.SetActive(true);

    }

    private class HighScoreItem{
        public int Score;
        
    }
}

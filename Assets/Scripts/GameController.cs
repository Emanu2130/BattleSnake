using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;


    void Start(){
        player =  GameObject.FindGameObjectWithTag("Snake");
    }

    void Update(){
    }

    public void changeLevel(string level){
        SceneManager.LoadScene(level);
    }

    public void touchRight(){
        if(Input.touchCount > 0){
            player.transform.Rotate(0,0,-4f);
        }
    }

    public void touchLeft(){
        if(Input.touchCount > 0){
            player.transform.Rotate(0,0,4f);
        } 
    }

    public void Exit(){
        print("BYE BYE");
        Application.Quit();
    }
}

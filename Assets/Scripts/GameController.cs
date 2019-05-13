using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public bool holdIzq, holdDer;

    

    void Start(){
        player =  GameObject.FindGameObjectWithTag("Snake");
    }
 
    public void Update(){
        
        if(holdIzq){
            player.transform.Rotate(0,0,4f);
        }else if(holdDer){
            player.transform.Rotate(0,0,-4f);
        }

    }

    public void OnPressLeft(){
        holdIzq = true;
    }

    public void OnReleaseLeft(){
        holdIzq = false;
    }

    public void OnPressRight(){
        holdDer = true;
    }

    public void OnReleaseRight(){
        holdDer = false;
    }

    public void bulletShot(){
        if(Input.touchCount > 0){
        var snake = GameObject.Find("Snake");
            if(snake != null){
                Instantiate(bullet, snake.transform.position, Quaternion.identity);
            }
        }
    }

    public void changeLevel(string level){
        SceneManager.LoadScene(level);
    }

    public void Exit(){
        print("BYE BYE");
        Application.Quit();
    }
}

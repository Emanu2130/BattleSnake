using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject player;


    void Start(){
        player =  GameObject.FindGameObjectWithTag("Snake");
    }

    void Update(){
        if(Input.touchCount > 0){
            player.transform.Rotate(0,0,-4f);
        }
    }

    /*public void touchRight(){
        print
        if(Input.touchCount > 0){
            player.transform.Rotate(0,0,-4f);
        }
    }

    public void touchLeft(){
        if(Input.touchCount > 0){
            player.transform.Rotate(0,0,4f);
        } 
    }*/
}

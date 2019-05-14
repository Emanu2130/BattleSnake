using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Start(){
        PlayerPrefs.SetFloat("PlayerHealth", 100);
        PlayerPrefs.SetInt("PlayerPoints", 0);
    }
 
    public void Update(){

    }

    public void changeLevel(string level){
        SceneManager.LoadScene(level);
    }

    public void Exit(){       
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{

    public float speed = 10f;
    public float currentHP, totalHP;
    public float hor;
    public GameObject bullet;
    public GameObject health; 

    void Start(){
        transform.position = new Vector3(0,0,transform.position.z);
        totalHP = 100;
        currentHP = PlayerPrefs.GetInt("PlayerHealth");
    }

    // Update is called once per frame
    void Update(){
        float InputHor = Input.GetAxis("Horizontal");

        transform.Translate (0, -speed * Time.deltaTime, 0);

        //Rotacion 
        if(InputHor > 0 && InputHor != 0){
            transform.Rotate(0,0,-4f); 
        }else if(InputHor < 0 && InputHor != 0){
            transform.Rotate(0,0,4f); 
        }

        //Disparo
        if(Input.GetKeyDown(KeyCode.Space)){
            var snake = GameObject.Find("Snake");
            if(snake != null){
                Instantiate(bullet, snake.transform.position, Quaternion.identity);
            }
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Wall"){
            currentHP -= 5;
            health.transform.localScale = new Vector3((currentHP / totalHP), 1, 0);
            if(currentHP == 0){
                SceneManager.LoadScene("Game Over");
            } 
            transform.position = new Vector3(0, 0, transform.position.z);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            currentHP -= 5;
            health.transform.localScale = new Vector3((currentHP / totalHP), 1, 0);
            if(currentHP == 0){
                SceneManager.LoadScene("Game Over");
            } 
        }
    }
}

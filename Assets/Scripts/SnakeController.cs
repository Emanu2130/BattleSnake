using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    public float speed = 10f;
    public float hor;
    public GameObject bullet;

    void Start(){
        transform.position = new Vector3(0,0,transform.position.z);
        
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

        var enemy = GameObject.Find("Enemy");
        print(enemy.transform.childCount);
        if(enemy.transform.childCount == 0){
            //print("Cambio de Nivel");
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Wall"){
            transform.position = new Vector3(0, 0, transform.position.z);
            this.Start();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
           // print("Mmamaguevo dejeme quieto!!");
        }
    }
}

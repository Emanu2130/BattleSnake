using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    public float speed = 10f;
    public float padding = 2;
    private Rigidbody2D rb2d;
    public float hor, ver;
    public Vector3 localScale;
    public GameObject Bullet;

    void Start(){
        transform.position = new Vector3(0,0,transform.position.z);
        Bullet =  GameObject.FindGameObjectWithTag("Bullet");
        //localScale = transform.localScale;
        Bullet.transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update(){
        //movimiento horizontal
        float InputHor = Input.GetAxis("Horizontal");
        float InputVer = Input.GetAxis("Vertical");

        transform.Translate (0, -speed * Time.deltaTime, 0);
        //print(InputHor + " " + InputVer);
        //Rotacion 
        if(InputHor > 0 && InputHor != 0){
            transform.Rotate(0,0,-4f); 
        }else if(InputHor < 0 && InputHor != 0){
            transform.Rotate(0,0,4f); 
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Wall"){
            transform.position = new Vector3(0, 0, transform.position.z);
            this.Start();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        print("Mmamaguevo dejeme quieto!!");
    }
}

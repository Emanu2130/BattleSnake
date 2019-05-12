using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    public float speed = 10f;
    public float bulletSpeed = 0;
    public float padding = 2;
    private Rigidbody2D rb2d;
    public float hor, ver;
    public Vector3 localScale;
    public GameObject Bullet;
    public GameObject Head;

    void Start(){
        transform.position = new Vector3(0,0,transform.position.z);
        Bullet =  GameObject.FindGameObjectWithTag("Bullet");
        //Bullet.transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update(){
        //Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        float InputHor = Input.GetAxis("Horizontal");

        transform.Translate (0, -speed * Time.deltaTime, 0);

        //Rotacion 
        if(InputHor > 0 && InputHor != 0){
            transform.Rotate(0,0,-4f); 
            //Bullet.transform.Rotate(0,0,0);
        }else if(InputHor < 0 && InputHor != 0){
            transform.Rotate(0,0,4f); 
            //Bullet.transform.Rotate(0,0,0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && Bullet.tag == "Bullet"){
            bulletSpeed = 5f;
        }
            Bullet.transform.Translate((bulletSpeed) * Time.deltaTime, 0, 0);
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

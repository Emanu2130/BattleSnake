using UnityEngine;
using System.Collections;
 
public class ShootController : MonoBehaviour
{
    public float bulletSpeed = 0.5f;
    public GameObject snake;
    public float snakeZ;
 
    // Use this for initialization
    void Start (){
        snake =  GameObject.FindGameObjectWithTag("Snake");
        this.GetComponent<Rigidbody2D>();
        snakeZ = snake.transform.rotation.eulerAngles.z + 180;
        shoot();
    }

    void Update(){        
        transform.Translate (0, 0.57f, 0);
    }
    
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Wall"){
            Destroy(gameObject);
        }
    }
    

    void shoot(){
        transform.Rotate(0, 0, snakeZ);
    }
}
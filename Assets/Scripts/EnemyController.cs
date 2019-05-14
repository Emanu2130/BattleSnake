using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Transform target;
    public GameObject Bullet;

    void Start(){
        target =  GameObject.FindGameObjectWithTag("Snake").GetComponent<Transform>();
        Bullet =  GameObject.FindGameObjectWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bullet"){
            Destroy(this.gameObject);
            Destroy(Bullet);
        }
    }
}

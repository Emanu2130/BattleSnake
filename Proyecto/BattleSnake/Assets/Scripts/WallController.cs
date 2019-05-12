using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject Culebrita;
    public GameObject Bullet;

    void Start() {
        Culebrita = GetComponent<GameObject>();
        Bullet =  GameObject.FindGameObjectWithTag("Bullet");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bullet"){
            Destroy(Bullet);
        }
    }
}

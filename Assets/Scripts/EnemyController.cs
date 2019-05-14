using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public int snakePoints;
    public Text score;
    public int i = 0;
    private Transform target;
    public GameObject Bullet;

    void Start(){
        target =  GameObject.FindGameObjectWithTag("Snake").GetComponent<Transform>();
        Bullet =  GameObject.FindGameObjectWithTag("Bullet");
        snakePoints = 0;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bullet"){
            snakePoints = 100 + PlayerPrefs.GetInt("PlayerPoints");
            PlayerPrefs.SetInt("PlayerPoints", snakePoints);
            Destroy(this.gameObject);
            Destroy(Bullet);
            score.text = "Score: " + snakePoints.ToString();
        }
    }
}

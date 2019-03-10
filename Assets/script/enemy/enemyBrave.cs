using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBrave : MonoBehaviour {

    public float speed;
    private Transform playerPos;
    private playerController player;
    public int health = 5;
    private int atk;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if(atk == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            atk = 1;
        }
    }
}

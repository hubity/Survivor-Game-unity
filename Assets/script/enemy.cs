using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float speed;
    private Transform playerPos;
    private playerController player;
    public GameObject effect;
    public int health = 5;
    public Animator shake;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shake.SetTrigger("ImpactEffect");
            Instantiate(effect, transform.position, Quaternion.identity);
            player.health--;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Projectile"))
        {
            
            health = health - 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Debug.Log(health);
        }
    }
}
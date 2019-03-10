using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public float speed;
    public int health = 10;

    public Text healthDisplay;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public Slider SliderHealth;
 

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        SliderHealth.maxValue = health;
        

	}
	
	// Update is called once per frame
	void Update () {

        healthDisplay.text = "HEALTH :" + health;
        SliderHealth.value = health;

        faceMouse(); // função que faz com que o player rotacione com o mouse

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

     void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);   
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
         );
        transform.up = direction;
    }

}

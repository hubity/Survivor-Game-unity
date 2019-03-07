using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testes : MonoBehaviour {

    public float distance;
    public float rotationSpeed;
    public Vector2 mousePoint;
	// Use this for initialization
	void Start () {
        Physics2D.queriesStartInColliders = false;
	}
	
	// Update is called once per frame
	void Update () {
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        faceMouse();

        //transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        Debug.DrawLine(transform.position, transform.position + transform.right * mousePoint.y, Color.red);
        
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

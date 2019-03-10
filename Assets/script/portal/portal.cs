using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {

    private Transform destination;
    public bool isOrange;
    public float distance = 0.3f;

	// Use this for initialization
	void Start () {

        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("OrangePortal").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Vector2.Distance(transform.position, collision.transform.position) > distance)
        collision.transform.position = new Vector2(destination.position.x, destination.position.y);
    }
}

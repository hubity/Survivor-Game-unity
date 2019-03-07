
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBlue : MonoBehaviour {

    public float rotationSpeed;
    public float speed;
    public float distance;

    public LineRenderer lineOfSight;

    public Transform playerPos;

	// Use this for initialization
	void Start () {
        Physics2D.queriesStartInColliders = false;

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);

            if (hitInfo.collider.CompareTag("Player"))
            {
                //Destroy(hitInfo.collider. gameObject);
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
        }

        lineOfSight.SetPosition(0, transform.position);
	}
}

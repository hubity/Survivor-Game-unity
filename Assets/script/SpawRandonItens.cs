using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawRandonItens : MonoBehaviour {

    public GameObject lote;
    public Transform moveLote;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // Use this for initialization
    void Start () {

        for (int i = 0; i < 10; i++)
        {
            moveLote.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(lote, moveLote.position, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
  
}

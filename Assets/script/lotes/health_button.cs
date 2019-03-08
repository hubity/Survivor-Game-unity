using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_button : MonoBehaviour {

    private playerController player;
    public int heal = 2;

	// Use this for initialization
	void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
	}

    public void Health()
    {
        player.health = player.health + 2;
        Destroy(gameObject);
    }
}

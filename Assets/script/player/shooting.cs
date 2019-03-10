using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    public GameObject shot;
    private Transform playerPos;
    public GameObject effectShoot;
    public Vector2 target;

    public int maxAmmo = 10;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Animator animator;
	// Use this for initialization
	void Start () {
  
        playerPos = GetComponent<Transform>(); 
        currentAmmo = maxAmmo;     
    }

    // Update is called once per frame
    void Update () {

        if (isReloading)
        {
            return;
        }


        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        currentAmmo--;
        Instantiate(effectShoot, transform.position, Quaternion.identity);
        Instantiate(shot, playerPos.position, Quaternion.identity);
    }
}

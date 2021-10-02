using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{

    public GameObject bulletObj;
    public float rateOfFire = 0.5f;
    
    private bool canShoot = true;

    IEnumerator Shoot() 
    {
        canShoot = false;
        Instantiate(bulletObj, this.transform);
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot) 
        {
            StartCoroutine(Shoot());
        }
    }

}

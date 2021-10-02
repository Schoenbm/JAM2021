using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{

    public GameObject bulletObj;
    public float rateOfFire = 0.5f;
	public float recoil = 0.5f;
	public Rigidbody2D rbplayer;
	private bool canShoot = true;
    

	void Start(){
		this.gameObject.GetComponentInParent<Rigidbody2D>();
	}
    IEnumerator Shoot() 
    {
        canShoot = false;
	    Instantiate(bulletObj, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }

    // Update is called once per frame
	void FixedUpdate()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector2 direction = mousePos - transform.position;
		Debug.Log(direction);
		
		float angle = Vector2.SignedAngle(Vector2.right, direction);
		transform.eulerAngles = new Vector3 (0, 0, angle);
		
    	
        if (Input.GetButton("Fire1") && canShoot) 
        {
	        StartCoroutine(Shoot());
	        rbplayer.AddForce(-transform.right * recoil);
        }
    }

}

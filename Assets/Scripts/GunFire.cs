using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
	public SpriteRenderer gunSprite;
	public GameObject gunpoint;
    public GameObject bulletObj;
    public float rateOfFire = 0.5f;
	public float recoil = 0.5f;
	public Rigidbody2D rbplayer;
	private bool canShoot = true;
	public Camera gameCamera;
	private bool faceRight = true;
	private bool constantShooting = false;
	
	public void setConstantShooting(bool constantShooting)
	{
		this.constantShooting = constantShooting;
	}
	
	void Start(){
		faceRight = true;
		this.gameObject.GetComponentInParent<Rigidbody2D>();
		gameCamera = FindObjectOfType<Camera>();
	}
    IEnumerator Shoot() 
    {
        canShoot = false;
	    Instantiate(bulletObj, gunpoint.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }

	void FixedUpdate()
	{
		Vector3 mousePos3 = Input.mousePosition;
		Vector2 mousePos = gameCamera.ScreenToWorldPoint(mousePos3);
		Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
		
		//flip
		if(direction.x < 0 && faceRight){ // if we look left, flip
			faceRight = false;
			gunSprite.flipY = !gunSprite.flipY;
		}
		else if(direction.x > 0 && !faceRight){//if we look right, flip
			faceRight = true;
			gunSprite.flipY = !gunSprite.flipY;
		}
			
		float angle = Vector2.SignedAngle(Vector2.right, direction);
		transform.eulerAngles = new Vector3 (0, 0, angle);
		
    	
		if ((Input.GetButton("Fire1") || constantShooting) && canShoot) 
        {
	        StartCoroutine(Shoot());
	        rbplayer.AddForce(-transform.right * recoil);
        }
    }

}
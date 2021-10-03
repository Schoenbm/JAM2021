﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
	public SpriteRenderer gunSprite;
	public GameObject gunpoint;
	gameManager gm;
    public GameObject bulletObj;
    public float rateOfFire = 0.5f;
	public float recoil = 0.5f;
	public Rigidbody2D rbplayer;
	private bool canShoot = true;
	public Camera gameCamera;
	private bool faceRight = true;
	private bool constantShooting = false;
	private bool rr = false;
	
	private AudioSource audioSrc;
	
	public void setConstantShooting(bool constantShooting)
	{
		this.constantShooting = constantShooting;
	}

	public void setRecoil(float recoilValue)
	{
		this.recoil = recoilValue;
	}
	
	void Start(){
		faceRight = true;
		this.gameObject.GetComponentInParent<Rigidbody2D>();
		gameCamera = FindObjectOfType<Camera>();
		gm = FindObjectOfType<gameManager>();
	}
    IEnumerator Shoot() 
    {
	    canShoot = false;
	    //audioSrc.Play();
	    Instantiate(bulletObj, gunpoint.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }
    
	public void setRR(bool rr2){
		rr = rr2;
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
			if(!rr){
				StartCoroutine(Shoot());
				rbplayer.AddForce(-transform.right * recoil);
			}else{
				int getRektRR = Random.Range(1,6);
				if(getRektRR == 1){
					GetComponentInParent<Player>().GetHit(1 , this.transform.position, 0f);
					gm.GetComponent<gameManager>().playerHit();
				}else{
					StartCoroutine(Shoot());
					rbplayer.AddForce(-transform.right * recoil);
				}
			}
	        
        }
    }

}
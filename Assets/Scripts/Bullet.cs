﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int damage;
	public float knockback;
	public float bulletTravelSpeed = 20f;
	private Rigidbody2D rb;

	private int secondsToLive = 5;
	
	void Start(){
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * bulletTravelSpeed;
		AllIn1Shader shader = gameObject.AddComponent(typeof(AllIn1Shader)) as AllIn1Shader;
		shader.MakeNewMaterial(true,"Allin1Sprite");
		
		Destroy(gameObject, secondsToLive);
	}
    // Update is called once per frame
	void Update()
	{
		
	}
	

	private void OnTriggerEnter2D(Collider2D collision) 
    {
	    print("Collision with: " + collision.transform.name);
	    if(!collision.transform.CompareTag(this.gameObject.tag)){
		    Animal target = collision.GetComponent<Animal>();
		    if(target != null)
		    	target.GetHit(damage, this.transform.position, knockback);
		    Destroy(this.gameObject);
	    }
    }

}

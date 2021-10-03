using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int damage;
	public float knockback;
	public float bulletTravelSpeed = 20f;
	private Rigidbody2D rb;

	private int secondsToLive = 5;
	private gameManager gm;
	
	void Awake(){
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * bulletTravelSpeed;
		//AllIn1Shader shader = gameObject.AddComponent(typeof(AllIn1Shader)) as AllIn1Shader;
		//shader.MakeNewMaterial(true,"Allin1Sprite");
		gm = FindObjectOfType<gameManager>();
		
		Destroy(gameObject, secondsToLive);
	}

	private void OnTriggerEnter2D(Collider2D collision) 
    {
	    //print("Collision with: " + collision.transform.name);
	    if(!collision.transform.CompareTag(this.gameObject.tag)){
		    Animal target = collision.gameObject.GetComponent<Animal>();
		    if(target != null) {
		    	target.GetHit(damage * gm.DamageModifier, this.transform.position, knockback);
			}
		    Destroy(this.gameObject);
	    }
    }

}

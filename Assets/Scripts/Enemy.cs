using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Animal
{
	public int strengh;
	public float knockback;
	
	protected float speed = 2.0f;
	public SpawnEnemies spawner;


    private void OnCollisionEnter2D(Collision2D collision) 
    {
    	if (collision.transform.tag == "Player"){
    		collision.gameObject.GetComponent<Player>().GetHit(strengh, this.transform.position, knockback);
    	}
    }
	
	public void hitPlayer(Collider2D collision){
		if (collision.transform.tag == "Player"){
			collision.gameObject.GetComponent<Player>().GetHit(strengh, this.transform.position, knockback);
		}
	}
	
	override
	public void Die(){
		spawner.spawnedEnemyDied();
		Debug.Log("Death");
		Destroy(this.gameObject);

	}

}

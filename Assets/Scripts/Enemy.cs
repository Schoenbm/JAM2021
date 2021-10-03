using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Animal
{
	public int strength;
	public float knockback;
	
	protected float speed = 2.0f;
	public SpawnEnemies spawner;
	
	public GameObject DropPrefab;

    private void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.transform.tag == "Player"){
    		collision.gameObject.GetComponent<Player>().GetHit(strength * gm.DamageModifier, this.transform.position, knockback);
    	}
    }
	
	public void hitPlayer(Collider2D collision){
		if (collision.transform.tag == "Player"){
			collision.gameObject.GetComponent<Player>().GetHit(strength * gm.DamageModifier, this.transform.position, knockback);
		}
	}
	
	override
	public void Die(){
		Instantiate(DropPrefab, this.gameObject.transform.position, this.transform.rotation);
		spawner.spawnedEnemyDied();
		gm.enemyKilled();
		Destroy(this.gameObject);
	}
	
	public void Fall() {
		spawner.spawnedEnemyDied();
		Destroy(this.gameObject);
	}

}

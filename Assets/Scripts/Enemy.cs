using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Animal
{
	[Range(0,100)] public int probabilityDrop;
	public int strength;
	public float knockback;
	protected Rigidbody2D rb;
	protected float speed = 2.0f;
	public SpawnEnemies spawner;
	
	public GameObject DropPrefab;
	
	void Start(){
		rb = this.GetComponent<Rigidbody2D>();
	}
    private void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.transform.tag == "Player"){
    		collision.gameObject.GetComponent<Player>().GetHit(strength * gm.DamageModifier, this.transform.position, knockback);
    	}
    }
	
	public void hitPlayer(Collider2D collision){
		if (collision.transform.tag == "Player"){
			collision.gameObject.GetComponent<Player>().GetHit(strength * gm.DamageModifier, this.transform.position, knockback);
			gm.playerHit();
		}
	}
	
	override
	public void Die(){
		if(Random.Range(0,100) > probabilityDrop)
			Instantiate(DropPrefab, this.gameObject.transform.position, this.transform.rotation);
		spawner.spawnedEnemyDied();
		gm.enemyKilled();
		Destroy(this.gameObject);
	}
	
	public void Fall() {
		spawner.spawnedEnemyDied();
		gm.BreakCombo();
		Destroy(this.gameObject);
	}

}

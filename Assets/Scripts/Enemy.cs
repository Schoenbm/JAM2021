﻿using System.Collections;
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
	
	public void hitPlayer(Collider2D collision){
		if (collision.transform.tag == "Player"){
			Player p = collision.gameObject.GetComponent<Player>();
			if(p.isInvincible) {
				Die();
			}
			else {
				p.GetHit(strength * gm.DamageModifier, this.transform.position, knockback);
				gm.playerHit();
				Debug.Log(this.gameObject.name + " hit player");
			}
		}
	}
	
	override
	public void Die(){
		if(Random.Range(0,100) > probabilityDrop)
		{
			Instantiate(DropPrefab, this.gameObject.transform.position, Quaternion.identity);
		}
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

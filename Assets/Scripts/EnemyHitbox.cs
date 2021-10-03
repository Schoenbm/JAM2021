using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
	public Enemy parentEnemy;
	
	void OnTriggerEnter2D(Collider2D collider){
		parentEnemy.hitPlayer(collider);
	}
	
	void OnTriggerStay2D(Collider2D collider){
		Vector2 direction = (-this.transform.position + collider.transform.position).normalized;
		collider.GetComponent<Rigidbody2D>().AddForce(direction * 10f);
	}
}

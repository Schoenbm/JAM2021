using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
	public int totalHealthPoints;
	protected int currentHealthPoints;
	protected bool invulnerable;
	protected bool canMove;
	public float invulnerabilityFrame;
	
	public void Awake(){
		currentHealthPoints = totalHealthPoints;
	}
	public void TakeDamages(int p){
		if(invulnerable)
			return;
		currentHealthPoints -= p; 
		Debug.Log("healthpoints =" + currentHealthPoints + " entity is:" + this.tag);
		if(currentHealthPoints <= 0)
			this.Die();
		else StartCoroutine(Hit());
	}
	
	public void heal(int p){
		if(currentHealthPoints< totalHealthPoints)
			currentHealthPoints += p;
	}
	
	abstract public void Die();
	
	IEnumerator Hit(){
		invulnerable = true;
		SpriteRenderer sp = this.gameObject.GetComponent<SpriteRenderer>();
		sp.color = new Color(1, 0.6f, 0.6f);
		yield return new WaitForSeconds(invulnerabilityFrame);
		invulnerable = false;
		sp.color = new Color(1, 1 , 1);
	}
	
	protected IEnumerator Invulnerable(float t){
		invulnerable = true;
		yield return new WaitForSeconds(t);
		invulnerable = false;
	}
	
	protected IEnumerator NoCollider(float t){
		//this.gameObject.GetComponent<BoxCollider2D>()
		yield return new WaitForSeconds(t);
		//this.gameObject.GetComponent<BoxCollider2D>().isActiveAndEnabled = true;
		invulnerable = false;
	}

	protected IEnumerator CantMove(float t)
    {
		canMove = false;
		yield return new WaitForSeconds(t);
		canMove = true;
	}
}

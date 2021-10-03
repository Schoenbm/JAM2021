using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
	protected gameManager gm;
	public int totalHealthPoints;
	protected int currentHealthPoints;
	protected bool invulnerable;
	protected bool canMove;
	public float invulnerabilityFrame;
	protected Vector3 vectorZero = new Vector3(0,0,0);
	protected Color ogColor;
	
	public void Awake(){
		currentHealthPoints = totalHealthPoints;
	}
	
	public void GetHit(int pStr, Vector3 pCoordObjHit, float pKnockback){
		print("damage taken:" + pStr);
		if(invulnerable)
			return;
		currentHealthPoints -= pStr;
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce((this.transform.position - pCoordObjHit).normalized * pKnockback);
		//Debug.Log("healthpoints =" + currentHealthPoints + " entity is:" + this.tag);
		if(currentHealthPoints <= 0)
			this.Die();
		else StartCoroutine(Hit());
	}
	
	public void heal(int p){
		if(currentHealthPoints< totalHealthPoints)
			currentHealthPoints += p;
	}

	
	abstract public void Die();
	
	public void setGm(gameManager pGm){gm = pGm	;}
	
	
	IEnumerator Hit(){
		ogColor = this.gameObject.GetComponent<SpriteRenderer>().color;
		invulnerable = true;
		SpriteRenderer sp = this.gameObject.GetComponent<SpriteRenderer>();
		sp.color = new Color(0.5f, 0.3f, 0.3f);
		yield return new WaitForSeconds(invulnerabilityFrame);
		invulnerable = false;
		
		if(invulnerabilityFrame ==0)
			yield return new WaitForSeconds(0.1f);

		sp.color = ogColor;
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

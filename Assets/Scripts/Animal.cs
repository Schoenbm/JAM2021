using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
	public int totalHealthPoints;
	protected int currentHealthPoints;
	
	public void Awake(){
		currentHealthPoints = totalHealthPoints;
	}
	public void takeDamages(int p){
		currentHealthPoints --; 
		Debug.Log("healthpoints =" + currentHealthPoints + " entity is:" + this.tag);
		if(currentHealthPoints <= 0)
			this.Die();
	}
	
	public void heal(int p){
		if(currentHealthPoints< totalHealthPoints)
			currentHealthPoints ++;
	}
	
	abstract public void Die();
	
	
}

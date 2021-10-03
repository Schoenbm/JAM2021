using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostTransparentEnemy : Rule
{
	private GameObject[] enemies;
	Color color;
	Color og;
	bool exit = false;
	public AlmostTransparentEnemy(){
		this.ruleName = "Invisible";
		this.description = "Where did you go?";
	}
	
	public override void applyRule(){
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		og = enemies[0].GetComponent<SpriteRenderer>().color;
		color = og;
		color.a = 0.5f;
		foreach (GameObject e in enemies)
		{
			e.GetComponent<SpriteRenderer>().color = color;
		}
		
	}

	public override void removeRule(){
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject e in enemies)
		{
			e.GetComponent<SpriteRenderer>().color = og;
		}
	}
	
	
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : Rule
{
	
	private GameObject gm;
	
	public DoubleDamage()
	{
		gm = GameObject.Find("GameManager");
		
		this.ruleName = "2x Damage";
		this.description = "Everything does twice the damage!";
	}
	
	public override void applyRule()
	{
		gm.GetComponent<gameManager>().DamageModifier = 2;
	}
	
	public override void removeRule()
	{
		gm.GetComponent<gameManager>().DamageModifier = 1;
	}
}

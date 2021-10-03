using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantShooting : Rule
{
	private GameObject JamesGunn;
	
	public ConstantShooting()
	{
		this.ruleName = "Constant Shooting";
		this.description = "You gun won't stop shooting!";
		
		JamesGunn = GameObject.FindGameObjectWithTag("Gun");
	}
	
	public override void applyRule()
	{
		JamesGunn.GetComponent<GunFire>().setConstantShooting(true);
	}
	
	public override void removeRule()
	{
		JamesGunn.GetComponent<GunFire>().setConstantShooting(false);
	}
}

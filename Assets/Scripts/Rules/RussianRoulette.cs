using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoussianRoulette : Rule
{
	GameObject player;
	GameObject gun;
	
	public RoussianRoulette(){
		this.ruleName = "Roussian Roulette";
		this.description = "Will you take your chances?";

		player = GameObject.FindGameObjectWithTag("Player");
		gun = GameObject.FindGameObjectWithTag("Gun");
	}
	
	public override void applyRule(){
		gun.GetComponent<GunFire>().setRR(true);
	}

	public override void removeRule(){
		gun.GetComponent<GunFire>().setRR(false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantJump : Rule
{
	GameObject player;
	
	public CantJump(){
		this.ruleName = "Can't Jump";
		this.description = "STICK TO THE GROUND!";

		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	public override void applyRule(){
		player.GetComponent<Player>().setMaxJumps(0);
	}

	public override void removeRule(){
		player.GetComponent<Player>().setMaxJumps(1);
	}
}

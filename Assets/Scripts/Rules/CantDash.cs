using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantDash : Rule
{
	GameObject player;
	
	public CantDash(){
		this.ruleName = "Can't Dash";
		this.description = "Dont RUN!";

		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	public override void applyRule(){
		player.GetComponent<Player>().setDash(false);
	}

	public override void removeRule(){
		player.GetComponent<Player>().setDash(true);
	}
}

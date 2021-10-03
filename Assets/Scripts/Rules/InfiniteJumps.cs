using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteJumps : Rule
{
	GameObject player;
	
	public InfiniteJumps(){
		this.ruleName = "Infinite Jumps";
		this.description = "You can jump forever";

		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	public override void applyRule(){
		player.GetComponent<Player>().setMaxJumps(999);
	}

	public override void removeRule(){
		player.GetComponent<Player>().setMaxJumps(1);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : Rule
{
	GameObject player;
	
	public Invincible() {
		this.ruleName = "Invincible";
		this.description = "Can't touch this";
		
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	public override void applyRule()
	{
		player.GetComponent<Player>().isInvincible = true;
		player.GetComponent<PlayerRainbowColor>().enabled = true;
	}

	public override void removeRule()
	{
		player.GetComponent<Player>().isInvincible = false;
		player.GetComponent<PlayerRainbowColor>().enabled = false;
		player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}
}

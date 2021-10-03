using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : Rule
{
	private GameObject player;
	
	public ChangeSkin()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		
		this.ruleName = "Skin change";
		this.description = "Rock that new look";
	}
	
	public override void applyRule()
	{
		player.GetComponent<SpriteRenderer>().sprite = player.GetComponent<Player>().spriteChange[1];
	}
	
	public override void removeRule()
	{
		player.GetComponent<SpriteRenderer>().sprite = player.GetComponent<Player>().spriteChange[0];
	}
}

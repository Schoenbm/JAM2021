using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostTransparent : Rule
{
	GameObject player;
	Color color;
	Color og;
	public AlmostTransparent(){
		this.ruleName = "Invisible";
		this.description = "Where did you go?";
		player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	public override void applyRule(){
		color = new Color(color.r,color.g,color.b,0.1f);
		og = player.GetComponent<SpriteRenderer>().color;
		player.GetComponent<SpriteRenderer>().color = color;
	}

	public override void removeRule(){
		color = og;
		player.GetComponent<SpriteRenderer>().color = color;
	}
}
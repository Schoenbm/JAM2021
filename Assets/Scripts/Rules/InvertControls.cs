﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertControls : Rule
{
	private GameObject player;
	
	public InvertControls()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		
		this.ruleName = "Inverted controls";
		this.description = "Your controls are inverted!";
	}
	
	public override void applyRule()
	{
		player.GetComponent<Player>().Inverted = -1;
	}
	
	public override void removeRule()
	{
		player.GetComponent<Player>().Inverted = 1;
	}
}

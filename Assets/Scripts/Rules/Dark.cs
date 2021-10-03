using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : Rule
{
	GameObject dark;
	public Dark(){
		this.ruleName = "Dark";
		this.description = "Mommy im scared!";
		dark = GameObject.FindGameObjectWithTag("Player").transform.Find("hidden").gameObject;
	}
	
	public override void applyRule(){
		dark.active = true;
	}

	public override void removeRule(){
		dark.active = false;
	}
}
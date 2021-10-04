using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : Rule
{
	GameObject dark;
	public Dark(){
		this.ruleName = "Dark";
		this.description = "Mommy im scared!";

	}
	
	public override void applyRule(){
		dark = GameObject.FindGameObjectWithTag("Player").transform.Find("hidden").gameObject;
		dark.SetActive(true);
	}

	public override void removeRule(){
		dark = GameObject.FindGameObjectWithTag("Player").transform.Find("hidden").gameObject;
		dark.SetActive(false);
	}
}
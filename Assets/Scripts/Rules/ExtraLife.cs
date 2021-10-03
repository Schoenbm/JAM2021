using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : Rule
{
	GameObject gm;
	
	public ExtraLife(){
		this.ruleName = "Extra Life";
		this.description = "Feeling lucky today?";
		
		gm = GameObject.Find("GameManager");
	}
	
	public override void applyRule(){
		gm.GetComponent<gameManager>().addExtraLife();
	}

	public override void removeRule(){
	}
}

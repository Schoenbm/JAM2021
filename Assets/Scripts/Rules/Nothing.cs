using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : Rule
{
	
	
	public Nothing(){
		this.ruleName = "Nothing";
		this.description = "Enjoy it pal";
	}
	
	public override void applyRule(){
		;
	}

	public override void removeRule(){

	}
}
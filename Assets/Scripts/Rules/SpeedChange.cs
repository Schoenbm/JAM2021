using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChange : Rule
{
	private GameObject gm;
	private int type;
	
	public SpeedChange()
	{
		gm = GameObject.Find("GameManager");
		type = Random.Range(0, 2);
		
		if (type == 0)
		{
			this.ruleName = "Speed Up";
			this.description = "Everyone moves faster!";
		}
		else if (type == 1)
		{
			this.ruleName = "Speed Down";
			this.description = "Everyone moves slower";
		}
	}
	
	public override void applyRule()
	{
		if (type == 0)
			gm.GetComponent<gameManager>().SpeedModifier = 1.5f;
		else if (type == 1)
			gm.GetComponent<gameManager>().SpeedModifier = 0.5f;
	}
	
	public override void removeRule()
	{
		gm.GetComponent<gameManager>().SpeedModifier  = 1f;
	}
}

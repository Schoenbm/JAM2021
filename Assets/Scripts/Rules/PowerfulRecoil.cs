using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerfulRecoil : Rule
{
	private GameObject Gun;
	private float currentRecoil;

	public PowerfulRecoil()
	{
		this.ruleName = "Powerful Recoil";
		this.description = "Take care where you shoot !";

		Gun = GameObject.FindGameObjectWithTag("Gun");
		currentRecoil = Gun.GetComponent<GunFire>().recoil;
	}

	public override void applyRule()
	{
		Gun.GetComponent<GunFire>().setRecoil(10 * currentRecoil);
	}
	public override void removeRule()
	{
		Gun.GetComponent<GunFire>().setRecoil(currentRecoil);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : Rule
{
	CameraShake camera;
	
	public Shaking(){
		this.ruleName = "Shaking";
		this.description = "nsotaeusantoehusnthoeu";
	}
	
	public override void applyRule(){
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
		camera.enabled = true;
	}

	public override void removeRule(){
		camera.enabled = false;
		camera.transform.position = new Vector3(0,0,-10);
	}
}
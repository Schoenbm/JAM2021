using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostTransparent : Rule
{
	GameObject player;
	GameObject Gun;
	Color colorPlayer;
	Color colorGun;
	Color ogPlayer;
	Color ogGun;
	public AlmostTransparent(){
		this.ruleName = "Invisible";
		this.description = "Where did you go?";
		player = GameObject.FindGameObjectWithTag("Player");
		Gun = GameObject.FindGameObjectWithTag("Gun");		
	}
	
	public override void applyRule(){
		colorPlayer = new Color(colorPlayer.r,colorPlayer.g,colorPlayer.b,0.2f);
		colorGun = colorPlayer;
		ogPlayer = player.GetComponent<SpriteRenderer>().color;
		player.GetComponent<SpriteRenderer>().color = colorPlayer;

		ogGun = Gun.GetComponent<GunFire>().gunSprite.color;
		Gun.GetComponent<GunFire>().gunSprite.color = colorGun;
	}

	public override void removeRule(){
		colorPlayer = ogPlayer;
		colorGun = ogGun;
		player.GetComponent<SpriteRenderer>().color = colorPlayer;
		Gun.GetComponent<GunFire>().gunSprite.color = colorGun;
	}
}
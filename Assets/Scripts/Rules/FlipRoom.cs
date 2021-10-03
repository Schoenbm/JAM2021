using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRoom : Rule
{
	private GameObject room;
	private GameObject player;
	private GameObject[] enemies;
	
	
	public FlipRoom(){
		this.ruleName = "Flip the room";
		this.description = "Everything is flipped";
		player = GameObject.FindGameObjectWithTag("Player");
		room = GameObject.FindGameObjectWithTag("Room");
		
	}
	
	public override void applyRule(){
		room.transform.localScale = new Vector3(-1,1,1);
		player.transform.position = new Vector3(-player.transform.position.x,player.transform.position.y,player.transform.position.z);
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject e in enemies)
		{
			e.transform.position = new	Vector3(-e.transform.position.x,e.transform.position.y,e.transform.position.z);
		}
	}

	public override void removeRule(){
		room.transform.localScale = new Vector3(1,1,1);
		player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject e in enemies)
		{
			e.transform.position = new	Vector3(e.transform.position.x,e.transform.position.y,e.transform.position.z);
		}

	}
}

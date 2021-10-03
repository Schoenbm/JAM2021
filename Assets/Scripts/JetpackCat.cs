using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackCat : Enemy
{
	public Pathfinding.AIDestinationSetter DestinationSetter;

	
	void Start(){
		rb = this.GetComponent<Rigidbody2D>();
		gm = FindObjectOfType<gameManager>();
		
		DestinationSetter.target = gm.getPlayer().gameObject.transform;
	}

}

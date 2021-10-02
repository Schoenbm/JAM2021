using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{

	public float travelSpeed = 2.0f;
	private int direction = 1;
	
	private void Update()
	{
		this.transform.Translate(new Vector2(travelSpeed * direction * Time.deltaTime, 0));
	}
	private void OnCollisionEnter2D(Collision2D collision) 
	{
		switch (collision.transform.tag) 
		{
		case "Enemy":
			direction *= -1;
			break;
		case "Player":
			collision.gameObject.GetComponent<Player>().TakeDamages(strengh);
			break;
		case "Wall":
			direction *= -1;
			break;
            
		}
	}
}

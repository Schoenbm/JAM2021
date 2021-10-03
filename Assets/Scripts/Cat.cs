using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{

	public float travelSpeed = 2.0f;
	private int direction = 1;
	[Range(0,0.5f)] public float smoothing = 0.05f;
	private void Update()
	{
		this.transform.Translate(new Vector2(travelSpeed * gm.SpeedModifier * direction * Time.deltaTime, 0));
		
		float movement = direction * travelSpeed;
		Vector3 targetVelocity = new Vector2(movement, rb.velocity.y);
		// And then smoothing it out and applying it to the character
		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref vectorZero , smoothing);
	}
	private void OnCollisionEnter2D(Collision2D collision) 
	{
		print(collision.transform.name);
		switch (collision.transform.tag) 
		{
		case "Wall":
			direction *= -1;
			this.gameObject.GetComponent<SpriteRenderer>().flipX = !this.gameObject.GetComponent<SpriteRenderer>().flipX;
			break;
		}
	}
	
}

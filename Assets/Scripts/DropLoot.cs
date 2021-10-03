using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player")){
			GameObject player = collider.gameObject;
			player.GetComponent<Animal>().heal(1);
			FindObjectOfType<gameManager>().playerHealed();
			Destroy(this.gameObject);
		}
	}
	
	
}

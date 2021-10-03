using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
	float timer = 5f;
	
	void Start(){
		StartCoroutine(Timer());
	}
	
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(timer);
		Destroy(this.gameObject);
	}
	
	
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player")){
			FindObjectOfType<AudioManager>().Play("Heart");
			GameObject player = collider.gameObject;
			player.GetComponent<Animal>().heal(1);
			FindObjectOfType<gameManager>().playerHealed();
			Destroy(this.gameObject);
		}
	}
	
	
}

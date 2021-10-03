using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	gameManager gm;
	
	float pressure = 0.0f; // how much has built up
	int pressureLevel = 0; // the threshold we are in (0 to 3, 3 is game over)
	
	// We will tweak these later on
	int thresholdLow = 5; // level 1
	int thresholdMedium = 15; // level 2
	int thresholdHigh = 25; // level 3
	
	Vector3 spawnpoint;
	BoxCollider2D boxCollider;
	
	public void setSpawnPoint(Vector3 spawn){spawnpoint = spawn;}
	
    // Start is called before the first frame update
    void Start()
    {
	    boxCollider = GetComponent<BoxCollider2D>();
	    gm = FindObjectOfType<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
	    if(pressure <= thresholdLow) {
	    	if(pressureLevel != 0) {
	    		pressureLevel = 0;
	    		// TODO: change shader, sounds, etc.
	    	}
	    }
	    else if(pressure > thresholdLow && pressure <= thresholdMedium) {
	    	if(pressureLevel != 1) {
	    		pressureLevel = 1;
	    		// TODO: change shader, sounds, etc.
	    	}
	    }
	    else if(pressure > thresholdMedium && pressure <= thresholdHigh) {
	    	if(pressureLevel != 2) {
	    		pressureLevel = 2;
	    		// TODO: change shader, sounds, etc.
	    	}
	    }
	    else {
	    	gm.GameOver();
	    }
    }
    
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Enemy") {
			++pressure;
			col.gameObject.GetComponent<Enemy>().Fall();
		}
		if(col.tag == "Player"){
			Player p = col.GetComponent<Player>();
			p.GetHit(1, Vector3.zero, 0);
			p.transform.position = spawnpoint;
		}
	}
	
	public void reducePressure() {
		pressure -= 0.5f;
	}
	
	public int getPressureLevel(){
		return this.pressureLevel + 1;
	}
}

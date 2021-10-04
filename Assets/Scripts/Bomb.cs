using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	gameManager gm;
	
	float pressure = 0.0f; // how much has built up
	float pressureLevel = 0; // the threshold we are in (0 to 3, 3 is game over)
	
	float maxPressure = 24.0f; // We will tweak these later on
	
	float thresholdLow; // level 1
	float thresholdMedium; // level 2
	float thresholdHigh; // level 3
	
	
	Vector3 spawnpoint;
	BoxCollider2D boxCollider;
	
	public void setSpawnPoint(Vector3 spawn){spawnpoint = spawn;}
	
    // Start is called before the first frame update
    void Start()
    {
	    boxCollider = GetComponent<BoxCollider2D>();
	    gm = FindObjectOfType<gameManager>();
	    
	    thresholdLow = maxPressure * 0.33f; // level 1
	    thresholdMedium = maxPressure * 0.66f; // level 2
	    thresholdHigh = maxPressure; // level 3
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
	    	FindObjectOfType<AudioManager>().Play("Explosion");
	    	gm.GameOver();
	    }
    }
    
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Enemy") {
			++pressure;
			gm.increaseChaos();
			gm.playPitfall();
			col.gameObject.GetComponent<Enemy>().Fall();
		}
		if(col.tag == "Player"){
			Player p = col.GetComponent<Player>();
			p.GetHit(1, Vector3.zero, 0);
			p.transform.position = spawnpoint;
			gm.playerHit();
		}
	}
	
	public void reducePressure() {
		//pressure -= 0.5f;
	}
	
	public float getPressureLevel(){
		return this.pressureLevel + 1;
	}
	
	public float getMaxPressure() {
		return this.maxPressure;
	}
}

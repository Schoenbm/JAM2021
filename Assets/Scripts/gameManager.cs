using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
	int score;
	int combo;
	int killingSpree;
	int totalLife;
	int currentLife;
	
	private Player player;
	public GameObject playerPrefab;
	public GameObject spawnPoint;
	
    void Start()
    {
	    player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Player>();
	    score = 0;
	    combo = 0;
    }
	
	void enemyKilled(){
		killingSpree += 1;
		combo = (int)Mathf.Sqrt(killingSpree);
		score += combo;
	}
	
	public void addExtraLife(){
		player.totalHealthPoints += 1;
	}
	
    // Update is called once per frame
    void Update()
    {
	    currentLife = player.getCurrentHealth();
    }
}

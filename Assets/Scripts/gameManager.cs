using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	int score;
	int combo;
	int killingSpree;
	int totalLife;
	int currentLife;
	
	private Player player;
	public GameObject playerPrefab;
	public GameObject spawnPoint;
	
	public Bomb bomb;
	
    void Start()
    {
	    player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Player>();
	    score = 0;
	    combo = 0;
    }
	
	public void enemyKilled(){
		killingSpree += 1;
		combo = (int)Mathf.Sqrt(killingSpree);
		score += combo;
		bomb.reducePressure();
	}
	
	public void addExtraLife(){
		player.totalHealthPoints += 1;
	}
	
    // Update is called once per frame
    void Update()
    {
	    currentLife = player.getCurrentHealth();
    }
	
	public void ChangeUIText(string ruleName, string ruleDescription) {
		
	}
    
	public void GameOver() {
		Debug.Log("Game Over");
		
		// TODO: show animation, gamover screen, return to menu, etc.
	}
}

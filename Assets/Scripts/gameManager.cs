using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	int score;
	int combo;
	int killingSpree;
	int totalLife;
	int currentLife;
	float chaos;
	
	private Player player;
	private Image chaosBarMask;
	public GameObject playerPrefab;
	public GameObject spawnPoint;
	public Image chaosBar;
	public float chaosFillSpeed = 0.01f;
	
	public Bomb bomb;
	
    void Start()
    {
	    player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Player>();
	    chaosBarMask = chaosBar.transform.GetChild(0).GetComponent<Image>();
	    print(chaosBarMask.transform.name);
	    score = 0;
	    combo = 0;
	    chaos = 0.0f;
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
	    if (chaosBarMask.fillAmount < 1)
	    	chaosBarMask.fillAmount += chaosFillSpeed * Time.deltaTime;
    }
	
	public void ChangeUIText(string ruleName, string ruleDescription) {
		
	}
    
	public void GameOver() {
		Debug.Log("Game Over");
		
		// TODO: show animation, gamover screen, return to menu, etc.
	}
}

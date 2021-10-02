﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class gameManager : MonoBehaviour
{
	int score;
	int combo;
	int killingSpree;

	int currentLife;
	float chaos;
	private Player player;
	public GameObject playerPrefab;
	public GameObject spawnPoint;

	private Image chaosBarMask;
	public Image chaosBar;
	public float chaosFillSpeed = 0.01f;
	public Bomb bomb;
	
	public List<Image> heartContainers;
	public TextMeshProUGUI Score;
	public TextMeshProUGUI Combo;

	void Start()
	{
		player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Player>();
		chaosBarMask = chaosBar.transform.GetChild(0).GetComponent<Image>();
		print(chaosBarMask.transform.name);
		score = 0;
		combo = 0;
		chaos = 0.0f;
		currentLife = player.totalHealthPoints;
	}

	public void enemyKilled()
	{
		killingSpree += 1;
		combo = (int)Mathf.Sqrt(killingSpree);
		score += combo;
		bomb.reducePressure();
	}

	public void addExtraLife()
	{
		player.totalHealthPoints += 1;
		heartContainers[player.totalHealthPoints].color = new Color(1, 1, 1);
	}

	// Update is called once per frame
	void Update()
	{
		currentLife = player.getCurrentHealth();
		if (chaosBarMask.fillAmount < 1)
			chaosBarMask.fillAmount += chaosFillSpeed * Time.deltaTime;
		
		Score.text = "score: "+score;
		if (combo >= 2)
			Combo.text = "x" + combo + "!";
			if (currentLife < player.getCurrentHealth())
			{
				for (int i = currentLife; i < player.getCurrentHealth() && i < heartContainers.Count; i++)
				{
					heartContainers[i].color = new Color(1, 1, 1);
				}
			}
			else if (currentLife > player.getCurrentHealth())
			{
				for (int i = player.getCurrentHealth(); i < currentLife && i < heartContainers.Count; i++)
				{
						heartContainers[i].color = new Color(0, 0, 0);
				}
			}
		currentLife = player.getCurrentHealth();
	}
	
	public void GameOver(){}
}

using System.Collections;
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
	private Player player;
	public GameObject playerPrefab;
	public GameObject spawnPoint;

	private Image chaosBarFill;
	public Image chaosBar;
	public float chaosFillSpeed = 0.01f;
	public Bomb bomb;
	
	public List<Image> heartContainers;
	public TextMeshProUGUI Score;
	public TextMeshProUGUI Combo;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Player>();
	}
	
	void Start()
	{
		chaosBarFill = chaosBar.transform.GetChild(0).GetComponent<Image>();
		score = 0;
		combo = 0;
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
		
		if (chaosBarFill.fillAmount < 1)
			chaosBarFill.fillAmount += chaosFillSpeed * Time.deltaTime;
		
		
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

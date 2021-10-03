using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class gameManager : MonoBehaviour
{
	int score;
	int combo;
	int killingSpree;
	bool gamePaused;
	public int DamageModifier {get; set;}
	public float SpeedModifier {get; set;}
	
	int currentLife;
	private Player player;
	public GameObject playerPrefab;
	public GameObject spawnPoint;
	public AudioManager audioManager;
	
	private Image chaosBarFill;
	public Image chaosBar;
	public float chaosFillSpeed = 0.01f;
	public Bomb bomb;
	
	public List<Image> heartContainers;
	public TextMeshProUGUI Score;
	public TextMeshProUGUI Combo;
	public TextMeshProUGUI ScoreGameOver;
	public Canvas PauseMenu;
	public Canvas GameOverCanvas;

	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		chaosBarFill = chaosBar.transform.GetChild(0).GetComponent<Image>();
		player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Player>();
		DamageModifier = 1;
		SpeedModifier = 1f;
	}
	
	void Start()
	{
		PauseMenu.enabled= false;
		GameOverCanvas.enabled = false;
		gamePaused = false;
		score = 0;
		combo = 0;
		
		currentLife = player.totalHealthPoints;
		bomb.setSpawnPoint(spawnPoint.transform.position); // set respawn point in case of player falling down in bomb
	}

	public void setRuleName(string name)
	{
		this.transform.Find("UI").Find("Rule Name").GetComponent<TextMeshProUGUI>().text = name;
	}
	
	public void setDescName(string desc)
	{
		this.transform.Find("UI").Find("Rule desc").GetComponent<TextMeshProUGUI>().text = desc;
	}

	public void enemyKilled()
	{
		killingSpree += 1;
		combo = (int)Mathf.Sqrt(killingSpree);
		score += combo;
		bomb.reducePressure();

		Score.text = "score: "+score;

		if (combo >= 2)
			Combo.text = "x" + combo + "!";
		
	}

	public void addExtraLife()
	{
		player.totalHealthPoints += 1;
		heartContainers[player.totalHealthPoints].color = new Color(1, 1, 1);
	}
	
	public void BreakCombo(){combo = 0;}
	
	// Call after subtracting life
	public void playerHit()
	{
		this.combo = 0;
		this.killingSpree = 0;
		float val = Random.Range(0f, 1f);
		if (val <= 0.5f)
		{ 
			audioManager.Play("Get_Hit_1");
		}
		else
		{
			audioManager.Play("Get_Hit_2");
		}
		
		Combo.text = "";

		for(int i = player.getCurrentHealth(); i < player.getMaxHealth(); i++) {
			heartContainers[i].color = new Color(0, 0, 0);
		}
	}

	// Call after adding life
	public void playerHealed() {
		for(int i = 0; i < player.getCurrentHealth(); i++) {
			heartContainers[i].color = new Color(1,1,1);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (chaosBarFill.fillAmount < 1)
			chaosBarFill.fillAmount += chaosFillSpeed * Time.deltaTime * bomb.getPressureLevel();
		
		if(Input.GetAxis("Pause") != 0 || Input.GetKeyDown(KeyCode.Escape)) {
			if( gamePaused)
				Resume();
			else
				Pause();
		}

	}
	public void Pause(){
		PauseMenu.enabled = true;
		Time.timeScale = 0f;
		audioManager.Play("Pause_In");
		FindObjectOfType<Camera>().GetComponent<AudioLowPassFilter>().cutoffFrequency = 500f;

		gamePaused = true;
	}
	public void Resume()
	{
		PauseMenu.enabled = false;
		audioManager.Play("Pause_Off");
		FindObjectOfType<Camera>().GetComponent<AudioLowPassFilter>().cutoffFrequency = 4000;
		Time.timeScale = 1f;
		gamePaused = false;
	}
	public void Menu(){
		audioManager.Play("Button_Select");
		SceneManager.LoadScene(0);
	}
	public void Quit(){
		audioManager.Play("Button_Select");
		Application.Quit();
	}

	public Player getPlayer(){
		return this.player;
	}

	public void GameOver()
	{
		//Debug.Log("Your score was :" + score);
		audioManager.Play("Game_Over");
		ScoreGameOver.text = "Your score: " + score;
		Time.timeScale = 0f;
		GameOverCanvas.enabled = true;
	}
}

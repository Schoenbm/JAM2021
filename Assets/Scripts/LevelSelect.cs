using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

	public static string[] levels = {"Level1", "Level2", "Level3"};
	
	public void SelectLevel(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	
	public void BackToMenu() {
		SceneManager.LoadScene("Menu");
	}
	
	public void SelectRandomLevel() {
		int levelIndex = Random.Range(0, levels.Length - 1);
		SceneManager.LoadScene(levels[levelIndex]);
	}
	
	
}

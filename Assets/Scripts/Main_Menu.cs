using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main_Menu : MonoBehaviour
{
    public void Quit()
	{
		Application.Quit();
	}
	
	public void Play(string name)
	{
		SceneManager.LoadScene(name);
	}
}

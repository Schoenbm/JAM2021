using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main_Menu : MonoBehaviour
{
	public AudioManager audioManager;
	
	void Start(){
		audioManager.Play("Menu_Theme");
	}
	
    public void Quit()
	{
		Application.Quit();
	}
	
	public void Play()
	{
		SceneManager.LoadScene("Level Select");
	}
}

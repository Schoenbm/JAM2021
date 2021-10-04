using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tuto_Menu : MonoBehaviour
{
	public AudioManager audioManager;
	
	void Start(){
		audioManager.Play("Menu_Theme");
	}
}

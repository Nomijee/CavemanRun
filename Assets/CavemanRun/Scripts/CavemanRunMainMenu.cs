using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CavemanRunMainMenu : MonoBehaviour {
	public Text scoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " +PlayerPrefs.GetFloat("highscore");
	}

	public void StartGame() {
		SceneManager.LoadScene ("GameScene");
		//Application.LoadLevel ("GameScene");
	}

	public void Instructions() {
		SceneManager.LoadScene ("Info");
		//Application.LoadLevel ("Info");
	}

}

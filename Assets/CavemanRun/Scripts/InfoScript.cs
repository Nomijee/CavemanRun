﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InfoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MainMenu() {
		SceneManager.LoadScene ("CavemanRunMainMenu");
		//Application.LoadLevel ("CavemanRunMainMenu");
	}
}

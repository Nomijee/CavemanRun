using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public GUIText instructionsText;

	// Use this for initialization
	void Start () {
		//instructionsText.text = "Tap to jump over rocks!";
		Time.timeScale = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown) 	{
			Time.timeScale = 1;
			Destroy(gameObject);
		}
	
	}
}

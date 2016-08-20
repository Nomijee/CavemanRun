using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class CavemanRunCavemanController : MonoBehaviour {


	// Declare Variables
	public float CavemanJumpForce = 500f;
	public Text scoreText;
	public float scoreTextf;
	public AudioSource Jump;
	public AudioSource Death;
	private Rigidbody2D myrigidbody;
	private Animator myAnim;
	private float cavemanHurtTime = -1;
	private Collider2D mycollider;
	private float startTime;
	private int jumped = 1;
	//private Boolean flag = false;

	// Use this for initialization
	void Start () {
		myrigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		mycollider = GetComponent<Collider2D> ();
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene ("Title");
			//Application.LoadLevel("Title");
		}


		// The follwoing if statement handles jumps under normal conditions
		if (cavemanHurtTime == -1) 
		{
			if ((Input.touchCount>0 && Input.GetTouch( 0 ).phase == TouchPhase.Began||Input.GetButtonUp ("Jump")) && jumped > 0) 
			{
				myrigidbody.AddForce (transform.up * CavemanJumpForce);
				jumped--;
				Jump.Play ();
			}

			myAnim.SetFloat ("Velocity", myrigidbody.velocity.y);
			scoreText.text = (Time.time - startTime).ToString ("0.0");
			scoreTextf =  float.Parse(scoreText.text);

		} 
		else 
		{
			if (Time.time > cavemanHurtTime + 2.5) 
			{
				SceneManager.LoadScene ("CavemanRunMainMenu");
				//Application.LoadLevel("CavemanRunMainMenu");
			}
		} 
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("enemy")) {

			foreach (MoveLeft movelefter in FindObjectsOfType<MoveLeft>()) 
			{
				movelefter.enabled = false;	
			}

			foreach (prefabSpawner spawner in FindObjectsOfType<prefabSpawner>()) 
			{
				spawner.enabled = false;
			}

			cavemanHurtTime = Time.time;
			myAnim.SetBool ("CavemanHurt", true);
			myrigidbody.velocity = Vector2.zero;
			myrigidbody.AddForce (transform.up * CavemanJumpForce);
			mycollider.enabled = false;
			Death.Play ();

			// This replaces the highscore if it is grater then the pervious high score
			StoreHighscore (scoreTextf);
			/*if (scoreTextf > PlayerPrefs.GetFloat("highscore")) {
				flag = true;
			}*/
	
		}
	
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("ground")) 
		{
			jumped = 1;
		}
	}

	void StoreHighscore(float newHighscore)
	{
		float oldHighscore = PlayerPrefs.GetFloat("highscore", 0.0f);    
		if(newHighscore > oldHighscore)
			PlayerPrefs.SetFloat("highscore", newHighscore);
	}

	/*public Rect windowRect = new Rect(0, 0, 200, 200);
	private GUIStyle guiStyle = new GUIStyle();
	public void OnGUI() {
		if (flag) 
		{
			windowRect.center = new Vector2 (330, 100);
			windowRect = GUI.Window (0, windowRect, DoMyWindow, "Congratulations!");
		}
	}
	void DoMyWindow(int windowID) { 
		GUI.Label (new Rect (10, 15, 200, 50), "Your new high score is " + scoreText.text);
	}*/

}

﻿using UnityEngine;
using System.Collections;

public class LogicOfTheGame : MonoBehaviour {


	public GUIText scoreText;
	public GUIText livesText;
	public GUIText powerupText;
	public GameObject EnemySpawner;

	private int score;
	public int lives;
	public float powerUp;

	private static bool gameOver;

	private GameObject bullets;

	//Marcus: These are variables used for fading in
	//and out upon achieving a Game Over. Not sure 
	//where to put this.
	public GameObject fader;
	public float speed;
	private Color faderColor;

	// Use this for initialization


	void Start () {
		powerUp = 0.0f;
				bullets = GameObject.Find ("Bullets");
				score = 0;
				if (lives == 0) {
						lives = 100;
				}gameOver = false;
				scoreText.text = "Score: " + score;
				livesText.text = "Lives: " + lives;

				//Marcus: Sorry, don't know where to put this,
				//but this is for the fade in and fade out effects
				//upon achieving a Game Over.

				faderColor = fader.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {

				//Marcus: SORRY SAMANTHA I DON'T KNOW WHERE TO 
				//PUT THIS CODE PLS FORGIVE ME.

				if (Application.loadedLevelName == "Level 1") {
			
						if (gameOver && faderColor.a + speed >= 0 && faderColor.a + speed <= 255) {
								faderColor.a += speed;
								fader.renderer.material.SetColor ("_Color", faderColor);}
			
						if ((fader.renderer.material.GetColor ("_Color").a + speed) >= 1.0f) {
								Application.LoadLevel ("GameOver");
						}
				}

		
				if (Application.loadedLevelName == "GameOver") {
						if (fader.renderer.material.GetColor ("_Color").a >= 0.0f) {
								faderColor.a -= speed;
								fader.renderer.material.SetColor ("_Color", faderColor);
						}
						if (fader.renderer.material.GetColor ("_Color").a <= 0.0f) {
				
								if (Input.GetKeyDown (KeyCode.JoystickButton9) 
										|| Input.GetKeyDown (KeyCode.JoystickButton8) 
										|| Input.GetKeyDown ("r")) {
										Application.LoadLevel ("Level 1");
								}
						}
				}				
				
				//Marcus: THAT'S ALL OF IT. IDK YOU COULD PROBABLY
				//OPTIMIZE IT BETTER BUT THAT'S WHAT I HAD.
		UpdatePowerup ();
	}


	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void UpdatePowerup(){
		
		powerupText.text = "Power: " + getPowerup ().ToString ();

		powerupText.text =string.Format ( "Power: {0:f1}", getPowerup());
		}

	public void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void UpdateLives ()
	{
		livesText.text = "Lives: " + lives;
	}

	public bool LoseLife(){
				if (getPowerup () > 1.0f) {
						changePowerup (-1.0f);
						Debug.Log ("PowerUp lost");
						ClearBullets (bullets.transform);
				} else if (lives > 0 && getPowerup () < 1.0f) {
						lives--;
						Debug.Log ("Life lost.");
						ClearBullets (bullets.transform);
				} else if (lives == 0 && getPowerup () < 1.0f) {
						UpdateLives ();
						gameOver = true;
						//EnemySpawner.SetActive(false);
						foreach (Transform child in EnemySpawner.transform)
								child.gameObject.SetActive (false);
						EnemySpawner.SetActive (false);
						return true;

				}
				UpdateLives ();
				return false;

	
		}

	public static Transform ClearBullets(Transform transform){
		foreach (Transform child in transform) {
			GameObject.Destroy (child.gameObject);
		}
		return transform;
		}

	public bool clearScreen(){
				return gameOver;
		}
	public int getScore(){
		return score;
		}

	public void setPowerup(float value){
		powerUp = value;
	}

	public float getPowerup(){
		float returnValue = powerUp;
		return returnValue;
	}

	public void changePowerup(float change){
		powerUp += change;
	}
}
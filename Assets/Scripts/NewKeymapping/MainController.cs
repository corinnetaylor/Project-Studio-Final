using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
	
	public static MainController instance;
	public GUIText TimeLeftText;
	public Transform EndGoal;
	public bool running = true;
	bool gameOver = false;
	
	public GUIText GameOverText;
//	int doorUpCounter = 0;
	
	//One Minute is not really enough time, especially if they have to search
	float time = 120f;
	
	//Time for debugging
//	float time = 5f;
	
	void Awake(){
		instance = this;	
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameOver == false){
			running = true;
		} else {
			running = false;
		}
		
		if (!running){
			if (Input.GetKeyDown (KeyCode.Return)){			
				Application.LoadLevel("MainGame");			
			}
		}
//		doorCountText.text = ("Doors Opened: " + doorUpCounter.ToString());
		
		time -= Time.deltaTime;
		
		if (time <= 0){
			//Game Over State	
			gameOver = true;
			GameOverText.enabled = true;
			
			GameOverText.text = ("Time's Up!");
			GameOverText.text += ("\n You didn't manage to make it back to your lamp in time.");
			GameOverText.text += ("\n");
			GameOverText.text += ("\n");
			GameOverText.text += ("\n Press Enter to try again.");
			
		}
		
		TimeLeftText.text = (((int)time).ToString());
		
	}
	
//	public void IncrementDoorUp(){
//		doorUpCounter++;	
//	}
	
	public void EndGame(){
			
		Debug.Log("Over");
		
			gameOver = true;
			GameOverText.enabled = true;
		
			GameOverText.text = ("You did it!");
			GameOverText.text += ("\n Welcome home.");
			GameOverText.text += ("\n");
			GameOverText.text += ("\n");
			GameOverText.text += ("\n Press Enter to play again.");

		
	}
}

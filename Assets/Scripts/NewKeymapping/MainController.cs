using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
	
	public static MainController instance;
	public GUIText doorCountText;
	int doorUpCounter = 0;
	
	void Awake(){
		instance = this;	
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		doorCountText.text = ("Doors Opened: " + doorUpCounter.ToString());
	}
	
	public void IncrementDoorUp(){
		doorUpCounter++;	
	}
}

using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
		void OnTriggerEnter(){
			
		Debug.Log ("Game");
		if (MainController.instance.running){	
			MainController.instance.EndGame();
		}
	}
}

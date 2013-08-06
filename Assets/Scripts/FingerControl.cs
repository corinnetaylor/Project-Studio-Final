using UnityEngine;
using System.Collections;

public class FingerControl : MonoBehaviour {
	
	public bool fingerDown; //Used to determine hand configuration
	public KeyCode key; //Assign in inspector
	float timeStopped;
	float timeStarted;
	float speed = 3f;//controls the speed that the fingers move
	
	// Use this for initialization
	void Start () {
		animation.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (fingerDown == true){
//			Debug.Log (transform.name + " is down");
//		}
			
		//Plays the animation forward of the finger curling down
		//has the ability to play from a certain point in the animation if the animation was interrupted
		if (Input.GetKeyDown(key)){ 
			fingerDown = true;
			
			animation["FingerCurl"].speed = speed;
			
			timeStarted = animation["FingerCurl"].time;
			if (timeStarted != 0){
				animation["FingerCurl"].time = timeStarted;
			}
			animation.Play ("FingerCurl");
			
			
		//Plays the animation backward (finger curling up)
		//has the ability to play from a certain point in the animation if the animation was interrupted
		} else if (Input.GetKeyUp(key)) {
			fingerDown = false;
			timeStopped = animation["FingerCurl"].time;			
			
			animation["FingerCurl"].speed = -speed;
			
			if (timeStopped == 0){
			animation["FingerCurl"].time = animation["FingerCurl"].length;
			} else {
				animation["FingerCurl"].time = timeStopped;
			}
			animation.Play ("FingerCurl");
			

		}
	
	}
	// REVIEW: in C#, getter / setter methods are ideally implemented
	// as "properties" -- pseudo-variables that can execute code upon "get" or "set"
	// so instead of isKeyDown(), you might declare at the top of this class instead:
	//     public bool isKeyDown { get { return fingerDown; } }
	// for more information, see: http://www.dotnetperls.com/property
	
	//getter used by the MainGameController
	public bool isKeyDown(){
	
		return fingerDown;
		
	}
}

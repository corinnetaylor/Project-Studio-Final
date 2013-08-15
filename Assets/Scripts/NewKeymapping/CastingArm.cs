using UnityEngine;
using System.Collections;

public class CastingArm : MonoBehaviour {
	
	/*
	 * This script will control the casting arm, and interpret mouse clicks. It will instantiate Magic objects. It will allow the user to queue
	 * up kinds of magic. It talks to the HandController script to get what poses the player is making.
	 * 
	 * Problems: Casting arm needs to move smoothly based on the camera
	 * 
	 * TODO: Work out how to instantiate spell objects at a slower rate, and to move in the direction that the mouse is pointing
	 * */
	
	public Transform theHand;
	public Transform thePlayer;
	public Transform dummyArm;
	public Transform waterSound;
	public GameObject magicController;
	
	public Transform gem1;
	public Transform gem2;
	public Transform gem3;
	public Transform gem4;
	public Transform gem5;
	public Transform gem6;
	
	bool poseMade = false;
	bool extended = false;
	Vector3 startPosition;
	float damping = 5;
	float forwardAmount = .5f;
	int magicType;
	
	Vector3 goalPosition;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {		
		
		//Updates the status of the hand spell picking hand each frame

		switch(theHand.GetComponent<HandController>().getPosition()){
		case 0: poseMade = false;
			break;
			//Earth
		case 1: magicType = 1; //Lowered, Left
			poseMade = true;
			break;
		case 2: magicType = 2; //Lowered
			poseMade = true;
			break;
		case 3: magicType = 3; //Lowered, right
			poseMade = true;
			break;
			//Fire
		case 4: magicType = 1; //Left
			poseMade = true;
			break;
		case 5: magicType = 3; //Right
			poseMade = true;
			break;
			//Water
		case 6: magicType = 1;//Raised left
			poseMade = true;
			break;
		case 7: magicType = 2;//Raised
			poseMade = true;
			break;
		case 8: magicType = 3; //Raised right
			poseMade = true;
			break;
		}
		

		
		//Right mouse button toggles aiming
		if (Input.GetMouseButtonDown (1)){
			if (!extended){
				extended = true;
				Debug.Log("Arm is out");

			} else if(extended) {
				extended = false;
				Debug.Log ("Arm is in");
			}	
		}
		
		
		if (poseMade){
			
			switch(magicType){
		
			case 1: gem1.renderer.material.color = Color.green;
				gem2.renderer.material.color = Color.green;
				gem3.renderer.material.color = Color.green;
				gem4.renderer.material.color = Color.green;
				gem5.renderer.material.color = Color.green;
				gem6.renderer.material.color = Color.green;
			break;
			case 2: gem1.renderer.material.color = Color.red;
				gem2.renderer.material.color = Color.red;
				gem3.renderer.material.color = Color.red;
				gem4.renderer.material.color = Color.red;
				gem5.renderer.material.color = Color.red;
				gem6.renderer.material.color = Color.red;
			break;
			case 3: gem1.renderer.material.color = Color.blue;
				gem2.renderer.material.color = Color.blue;
				gem3.renderer.material.color = Color.blue;
				gem4.renderer.material.color = Color.blue;
				gem5.renderer.material.color = Color.blue;
				gem6.renderer.material.color = Color.blue;
			break;
			}
			
			} else {
				gem1.renderer.material.color = Color.black;
				gem2.renderer.material.color = Color.black;
				gem3.renderer.material.color = Color.black;	
				gem4.renderer.material.color = Color.black;
				gem5.renderer.material.color = Color.black;
				gem6.renderer.material.color = Color.black;	
		}
		
		//The arm has to be aimed to cast
		if (extended){
			//If aimed, the arm extends outward
				goalPosition = new Vector3(dummyArm.localPosition.x, dummyArm.localPosition.y, dummyArm.localPosition.z + forwardAmount);
				transform.localPosition = Vector3.Lerp(transform.localPosition, goalPosition, Time.deltaTime * damping);
			
			//If left mouse button is then clicked
			if (Input.GetMouseButtonDown(0)){		
				//And a pose is being made with the Spell-Picking hand
				if (poseMade){
					
					//Magic will be cast
					magicController.GetComponent<MagicController>().Cast (magicType, Vector3.zero);
//					Debug.Log ("Casting magic type " + magicType);
					if (magicType == 2){
						transform.audio.Play();	
					} else if (magicType == 3){
						waterSound.audio.Play ();
					}
				}
				
			} 
		} else {
			transform.localPosition = Vector3.Lerp(transform.localPosition, dummyArm.localPosition, Time.deltaTime * damping);	
		}
		
		
	}
}

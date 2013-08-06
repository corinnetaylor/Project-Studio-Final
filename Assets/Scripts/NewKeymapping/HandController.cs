using UnityEngine;
using System.Collections;

public class HandController : MonoBehaviour {
	
	/*
	 * This script controlls the movements of the hand based on WASD (in magic mode) and calculates which
	 * kind of magic the player is casting based on the position of the hand.
	 * */
	public GameObject player;
	bool movementMode;
	
	//Variables used in rotating the hand
	Quaternion goalRotation, baseRotation, startingRotation;
	float xTurnAmount, zTurnAmount = 0;
	float rotationAmount = 15f;
	float rotationSpeed = 10;
	
	//Variables used for determining the position of the hand
	int poseNumber = 0; //default 0, no pose is being made
	
	bool wDown = false;
	bool sDown = false;
	bool aDown = false;
	bool dDown = false;
	
	// Use this for initialization
	void Start () {
		startingRotation = transform.rotation; //This one never changes, it is the base rotation that goalRotation is calculated by
		baseRotation = transform.rotation; //This changes based on the current rotation of the hand
		goalRotation = transform.rotation; //This changes depending on which pose the player is making, and returns to startingRotation if no button is pressed
	}
	
	// Update is called once per frame
	void Update () {
		movementMode = player.GetComponent<MovementController>().getMode();
		
		
		
		//TODO: Have the hand raise into FOV in Magic Mode
		
		if (!movementMode){
			//Bools for shortening the pose calculation code
			if (Input.GetKey (KeyCode.W)){
				wDown = true;
			} else {
				wDown = false;	
			}
			if (Input.GetKey (KeyCode.S)){
				sDown = true;
			} else {
				sDown = false;	
			}	
			if (Input.GetKey (KeyCode.A)){
				aDown = true;
			} else {
				aDown = false;	
			}
			if (Input.GetKey (KeyCode.D)){
				dDown = true;
			} else {
				dDown = false;	
			}
			
			
			//Determine Hand Rotation
			if (Input.GetKey(KeyCode.W)){ //Hand pull back (fingers spread and back)
				xTurnAmount = rotationAmount;							
			} else if (Input.GetKey(KeyCode.S)){ //Hand press down (making a fist)
				xTurnAmount = -rotationAmount;
			} else {
				xTurnAmount = 0;	
			}
			
			if (Input.GetKey(KeyCode.A)){ //Tilt hand left
				zTurnAmount = rotationAmount;
			} else if (Input.GetKey(KeyCode.D)){ //Tilt hand right
				zTurnAmount = -rotationAmount;
			} else {
				zTurnAmount = 0;
			}
			
			baseRotation = transform.rotation;
			goalRotation = Quaternion.Euler(startingRotation.x + xTurnAmount, 
											startingRotation.y, 
											startingRotation.z + zTurnAmount);
			
			transform.rotation = Quaternion.Slerp(baseRotation, goalRotation, Time.deltaTime * rotationSpeed);

			//Pose Calculations			
			//There are 8 possible poses
			//Two options, to make poses based on keys being pressed or on the actual rotation of the hand, for now, pose is based on
			//which keys are being pressed, depending on how the modeled hand animates, either keep this convention or switch to rotation position
			
			if (!wDown && sDown && aDown && !dDown) { //Lowered tilted left
				poseNumber = 1;
			} else if (!wDown && sDown && !aDown && !dDown) { //Lowered, not tilted
				poseNumber = 2;
			} else if (!wDown && sDown && !aDown && dDown) { //Lowered tilted right
				poseNumber = 3;
			} else if (!wDown && !sDown && aDown && !dDown) { //Tilted left
				poseNumber = 4;
			} else if (!wDown && !sDown && !aDown && dDown) { //Tilted right
				poseNumber = 5;
			} else if (wDown && !sDown && aDown && !dDown) { //Raised tilted left
				poseNumber = 6;
			} else if (wDown && !sDown && !aDown && !dDown) { //Raised not tilted
				poseNumber = 7;
			} else if (wDown && !sDown && !aDown && dDown) { //Raised tilted right
				poseNumber = 8;
			} else if (!wDown && !sDown && !aDown && !dDown){ //The hand is not being rotated
				poseNumber = 0;
			}
			
			Debug.Log (poseNumber);
			
		} else {
			poseNumber = 0;
			//TODO: Have the hand lower out of FOV in Movement Mode
		}
		
	
	}
	
	public int getPosition(){
		
		return poseNumber;
	}
}

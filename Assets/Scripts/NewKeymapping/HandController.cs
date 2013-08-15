using UnityEngine;
using System.Collections;

public class HandController : MonoBehaviour {
	
	/*
	 * This script controlls the movements of the hand based on WASD and calculates which
	 * kind of magic the player is casting based on the position of the hand.
	 * */
	public GameObject player;
	public Transform baseHand, up, down, left, right, upLeft, upRight, downLeft, downRight;
	Transform goal;
	bool movementMode;
	float damping = 5f;
	
	//Variables used for determining the position of the hand
	int poseNumber = 0; //default 0, no pose is being made
	
	bool wDown = false;
	bool sDown = false;
	bool aDown = false;
	bool dDown = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		movementMode = player.GetComponent<MovementController>().getMode();
//		
//		
//		if (!movementMode){
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
			
			//Pose Calculations			
			//There are 8 possible poses
			//Two options, to make poses based on keys being pressed or on the actual rotation of the hand, for now, pose is based on
			//which keys are being pressed, depending on how the modeled hand animates, either keep this convention or switch to rotation position
			
			if (!wDown && sDown && aDown && !dDown) { //Lowered tilted left
				poseNumber = 1;
				goal = downLeft;
			} else if (!wDown && sDown && !aDown && !dDown) { //Lowered, not tilted
				poseNumber = 2;
				goal = down;
			} else if (!wDown && sDown && !aDown && dDown) { //Lowered tilted right
				poseNumber = 3;
				goal = downRight;
			} else if (!wDown && !sDown && aDown && !dDown) { //Tilted left
				poseNumber = 4;
				goal = left;
			} else if (!wDown && !sDown && !aDown && dDown) { //Tilted right
				poseNumber = 5;
				goal = right;
			} else if (wDown && !sDown && aDown && !dDown) { //Raised tilted left
				poseNumber = 6;
				goal = upLeft;
			} else if (wDown && !sDown && !aDown && !dDown) { //Raised not tilted
				poseNumber = 7;
				goal = up;
			} else if (wDown && !sDown && !aDown && dDown) { //Raised tilted right
				poseNumber = 8;
				goal = upRight;
			} else if (!wDown && !sDown && !aDown && !dDown){ //The hand is not being rotated
				poseNumber = 0;
				
				goal = baseHand;
			}
			
			transform.position = Vector3.Lerp(transform.position, goal.position, Time.deltaTime * damping);
			transform.rotation = Quaternion.Slerp(transform.rotation, goal.rotation, Time.deltaTime * damping);
		
	
	}
	
	public int getPosition(){
		
		return poseNumber;
	}
}

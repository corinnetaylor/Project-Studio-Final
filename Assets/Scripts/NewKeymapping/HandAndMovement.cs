using UnityEngine;
using System.Collections;

public class HandAndMovement : MonoBehaviour {
	
	//This is a test script, I plan to move the hand control to a separate script on the hand
	/* Problems to solve:
	 * -The jump is too 'floaty'
	 * -Looking is controlled by the mouse movement, but right now it's too sluggish on low turn speeds, and too sensative when moving the 
	 * mouse up and down, also the 'center' is not in the middle of the screen - Is there a way to set mouse turn to the mouse position on screen?
	 * 
	 * */
	
	public Transform theHand;
	
	bool movementMode = true; //Movement mode is initially enabled by default
	
	float jumpDamping = .5f;
	float xTurnAmount, zTurnAmount = 0;
	float rotationAmount = 15f;
	float mouseTurnSpeed = 100f;
	
	Vector3 moveVectorVert, moveVectorHoriz;
	Quaternion goalRotation, baseRotation;
	
	// Use this for initialization
	void Start () {
		baseRotation = theHand.rotation;
		goalRotation = theHand.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Switch Between movementMode and magicMode
		
		if (Input.GetKeyDown(KeyCode.LeftShift)){
			
			if (movementMode){ //If in Movement Mode
				movementMode = false;
				//Reset force when switching to magic mode so that player piece doesn't fling into the distance
				moveVectorVert = Vector3.zero;
				moveVectorHoriz = Vector3.zero;
				Debug.Log ("Switch to Magic Mode");
				
			} else { //Else if in Magic Mode
				movementMode = true;
				Debug.Log ("Switch to Movement Mode");
			}
			
		}
		
		//Turning is determined by mouse movement
		transform.Rotate (-Input.GetAxis ("Mouse Y")*Time.deltaTime  * mouseTurnSpeed,Input.GetAxis("Mouse X")*Time.deltaTime * mouseTurnSpeed,0f);
		
		Ray ray = new Ray(transform.position, -transform.up); //Ray for determining if the player is on the ground
		
		if (movementMode){
			
			
		
				if (Physics.Raycast(ray, 1.01f)){ //If the player is on the ground	
					//Movement is enabled					
					moveVectorVert = transform.forward * Input.GetAxis("Vertical");
					moveVectorHoriz = transform.right * Input.GetAxis("Horizontal");
				
					//Jump is enabled
					if (Input.GetKey(KeyCode.Space)){ //Jump					
						rigidbody.AddForce(transform.up * 500f);
						
						//Dampen forward and horizontal motion down while the player is in the air to reduce the 'launching' effect
						moveVectorVert *= jumpDamping;
						moveVectorHoriz *= jumpDamping;
						}
				} 


		} else if (!movementMode){ //else in magic mode
			
			if (Physics.Raycast(ray, 1.01f)){ //If the player is on the ground				
				if (Input.GetKey(KeyCode.Space)){ //If space is pressed down					
					moveVectorVert = transform.forward;	//Move Forward		
				} else if (Input.GetKeyUp (KeyCode.Space)){ //Else when space is released
					moveVectorVert *= 0;	//Forward movement = 0
				}
			}
			
			//THIS SECTION WILL PROBABLY NEED SOME TWEAKING
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
			
			baseRotation = theHand.rotation;
			goalRotation = Quaternion.Euler(transform.eulerAngles.x + xTurnAmount, 
											transform.eulerAngles.y, 
											transform.eulerAngles.z + zTurnAmount);
			
			theHand.rotation = Quaternion.Slerp(baseRotation, goalRotation, Time.deltaTime);
			
			//
		}
		
		
	
	}
	
		void FixedUpdate(){
		
		rigidbody.AddForce(moveVectorVert, ForceMode.VelocityChange);
		rigidbody.AddForce(moveVectorHoriz, ForceMode.VelocityChange);
		
	}
	
}

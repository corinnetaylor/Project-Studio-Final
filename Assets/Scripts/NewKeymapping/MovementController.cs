using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	/* Problems to solve:
	 * -The jump is too 'floaty'
	 * -Looking is controlled by the mouse movement, but right now it's too sluggish on low turn speeds, and too sensative when moving the 
	 * mouse up and down, also the 'center' is not in the middle of the screen - Is there a way to set mouse turn to the mouse position on screen?
	 * 
	 * */
	
	bool movementMode = true; //Movement mode is initially enabled by default
	bool moving = false;
	float jumpDamping = .5f;
//	float mouseTurnSpeed = 100f;
	
	Vector3 moveVectorVert, moveVectorHoriz;

	
	// Use this for initialization
	void Start () {
		StartCoroutine(WalkingSound());
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
				moving = false;
				Debug.Log ("Switch to Magic Mode");
				
			} else { //Else if in Magic Mode
				movementMode = true;
				Debug.Log ("Switch to Movement Mode");
			}
			
		}
		
		//Turning is determined by mouse movement
		//transform.Rotate (-Input.GetAxis ("Mouse Y")*Time.deltaTime  * mouseTurnSpeed,Input.GetAxis("Mouse X")*Time.deltaTime * mouseTurnSpeed,0f);
		
		Ray ray = new Ray(transform.position, -transform.up); //Ray for determining if the player is on the ground
		
		if (movementMode){
			
			
		
				if (Physics.Raycast(ray, 1.01f)){ //If the player is on the ground	
					//Movement is enabled					
					moveVectorVert = transform.forward * Input.GetAxis("Vertical");
					moveVectorHoriz = transform.right * Input.GetAxis("Horizontal");
				
					if (rigidbody.velocity.magnitude > .5){
						moving = true;
					} else {
						moving = false;	
					}
				
					//Jump is enabled
					if (Input.GetKey(KeyCode.Space)){ //Jump
						rigidbody.AddForce(transform.up * 500f);
						
						//Dampen forward and horizontal motion down while the player is in the air to reduce the 'launching' effect
						moveVectorVert *= jumpDamping;
						moveVectorHoriz *= jumpDamping;
						}
				} else {
					moving = false;	
			}


		} else if (!movementMode){ //else in magic mode
			
			if (Physics.Raycast(ray, 1.01f)){ //If the player is on the ground

				if (Input.GetKey(KeyCode.Space)){ //If space is pressed down					
					
					if (rigidbody.velocity.magnitude > .5){
						moving = true;
					}
					
					moveVectorVert = transform.forward;	//Move Forward		
				} else if (Input.GetKeyUp (KeyCode.Space)){ //Else when space is released
					moving = false;
					moveVectorVert *= 0;	//Forward movement = 0
				}
			} else {
				moving = false;	
			}
			
		}
	
	}
	
		void FixedUpdate(){
		
		rigidbody.AddForce(moveVectorVert, ForceMode.VelocityChange);
		rigidbody.AddForce(moveVectorHoriz, ForceMode.VelocityChange);
		
	}
	
	public bool getMode(){
		return movementMode;	
	}
	
	IEnumerator WalkingSound(){
		while (true){
			while (moving){
				Debug.Log ("Walking");
				transform.audio.Play();
				yield return new WaitForSeconds(.5f);
			}
			yield return 0;
		}
	}
	
}
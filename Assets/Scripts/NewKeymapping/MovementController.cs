using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	
//	bool movementMode = true; //Movement mode is initially enabled by default
//	bool moving = false;
//	float jumpDamping = .5f;
	float mouseXSpeed = 100f;
	float mouseYSpeed = 200f;
	
	Vector3 moveVectorVert;

	
	// Use this for initialization
	void Start () {
//		StartCoroutine(WalkingSound());
	}
	
	// Update is called once per frame
	void Update () {

		
		if (Input.GetMouseButton(0)){
		  Screen.lockCursor = true;
		  }
		
		
		//Turning is determined by mouse movement
		transform.Rotate (0f,Input.GetAxis("Mouse X")*Time.deltaTime * mouseXSpeed,0f);
		
		//TODO figure out how to keep the camera from rotating too far
		Camera.mainCamera.transform.Rotate (-Input.GetAxis ("Mouse Y")*Time.deltaTime  * mouseYSpeed,0f,0f);
		
		if (Input.GetKey(KeyCode.Space)){ //If space is pressed down					
					
//			if (rigidbody.velocity.magnitude > .5){
//				moving = true;
//			}
					
			moveVectorVert = transform.forward;	//Move Forward		
			} else if (Input.GetKeyUp (KeyCode.Space)){ //Else when space is released
//				moving = false;
				moveVectorVert *= 0;	//Forward movement = 0
			}
		}

//	}
	
		void FixedUpdate(){
		
		rigidbody.AddForce(moveVectorVert, ForceMode.VelocityChange);
		
	}
	
	
//	IEnumerator WalkingSound(){
//		while (true){
//			while (moving){
//				Debug.Log ("Walking");
//				transform.audio.Play();
//				yield return new WaitForSeconds(.5f);
//			}
//			yield return 0;
//		}
//	}
	
}
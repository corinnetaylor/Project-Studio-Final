using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {
	
	//This script needs work
	
//	public Rigidbody earthMagic;
//	public Rigidbody fireMagic;
//	public Rigidbody waterMagic;
//	
//	Rigidbody theMagic;
//	
//	float speed = 100;
//	
//	public Transform theArm;
	Vector3 destination;
	float damping = 5f;
	
	Magic(Vector3 theDestination){
		destination = theDestination;
	}
	

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (destination == Vector3.zero){
			transform.localPosition += Vector3.forward;
		} else {
			transform.localPosition = Vector3.Lerp (transform.localPosition, destination, Time.deltaTime * damping);
		}
	}
	 
}

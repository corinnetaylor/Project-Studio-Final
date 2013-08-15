using UnityEngine;
using System.Collections;

public class CastingHand : MonoBehaviour {
	
	public Transform start, goal;
	float damping = 5f;
	bool extended = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
				//Right mouse button toggles aiming
		if (Input.GetMouseButtonDown (1)){
			if (!extended){
				extended = true;
				Debug.Log("Hand is up");

			} else if(extended) {
				extended = false;
				Debug.Log ("Hand is down");
			}
		}
		
		if (extended){
			transform.position = Vector3.Lerp(transform.position, goal.position, Time.deltaTime * damping);
			transform.rotation = Quaternion.Slerp(transform.rotation, goal.rotation, Time.deltaTime * damping);
			
			
		} else {
			transform.position = Vector3.Lerp (transform.position, start.position, Time.deltaTime * damping);	
			transform.rotation = Quaternion.Slerp(transform.rotation, start.rotation, Time.deltaTime * damping);
		}
		
	}
	
	
}

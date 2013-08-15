using UnityEngine;
using System.Collections;

public class SpellPickingArm : MonoBehaviour {
	
	public Transform start, goal;
	float damping = 10f;
	bool casting = false;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)){
			casting = true;
		} else if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.D)){
			casting = false;	
		}
		
		if (casting){
			transform.position = Vector3.Lerp(transform.position, goal.position, Time.deltaTime * damping);
			transform.rotation = Quaternion.Slerp(transform.rotation, goal.rotation, Time.deltaTime * damping);
		} else {
			transform.position = Vector3.Lerp (transform.position, start.position, Time.deltaTime * damping);	
			transform.rotation = Quaternion.Slerp(transform.rotation, start.rotation, Time.deltaTime * damping);
			
		}
	
	}
}

using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {
	
	Vector3 destination;
	float damping = 5f;

	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, .5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
//		Debug.Log (renderer.material.color.ToString());
	
		if (destination == Vector3.zero){
//			rigidbody.AddForce(Vector3.forward, ForceMode.VelocityChange);
			transform.Translate(Vector3.forward, Space.Self);
		} else {
			transform.localPosition = Vector3.Lerp (transform.localPosition, destination, Time.deltaTime * damping);
		}
	}
	 
	public void SetDestination(Vector3 theDestination){
	
		destination = theDestination;
	
	}
	
}


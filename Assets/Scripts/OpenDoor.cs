using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	bool startDoorOpen = false;
	float limit;
	float rate = 1;
	bool startDoorClose = false;
	float startingX;
	
	// Use this for initialization
	void Start () {
		startingX = transform.position.x;
		limit = startingX - 6;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space)){
			doorOpen();
		}
		
		if (startDoorOpen){
			
			transform.position += new Vector3(-rate*Time.deltaTime, 0f,0f);
			
			if (transform.position.x <= limit){
				startDoorOpen = false;
				startDoorClose = true;
			}
		}
		
		if (startDoorClose){
			
			transform.position += new Vector3(rate*Time.deltaTime,0f,0f);
			
			if (transform.position.x > startingX){
				startDoorClose = false;
			}
			
		}
	
	}
	
	public void doorOpen(){
	
		if (!startDoorClose){
			
			startDoorOpen = true;
		}
	}
	
}

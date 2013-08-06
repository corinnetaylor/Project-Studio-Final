using UnityEngine;
using System.Collections;

public class LightMaker : MonoBehaviour {
	
	public Light theLight;
	public Transform theHand;
	//int colorPicker = 0;
	bool poseMade = false;
	Vector3 startPosition;
	float damping = 5;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {		


		switch(theHand.GetComponent<PoseCalculator>().getPoseNumber()){
		case 0: poseMade = false;
			theLight.enabled = false;//Have to have this in here or else the light will remain on throughout different poses
			break;
		case 1: theLight.color = Color.red;
			poseMade = true;
			break;
		case 2: theLight.color = Color.blue;
			poseMade = true;
			break;
		case 3: theLight.color = Color.green;
			poseMade = true;
			break;
		case 4: theLight.color = Color.yellow;
			poseMade = true;
			break;
		
		}
		
		
		
		if (Input.GetMouseButton(0)){
			//While clicking, the 'arm' moves forward slightly, to simulate being extended
			transform.position = new Vector3(transform.position.x,transform.position.y,Mathf.Lerp(transform.position.z, startPosition.z + .5f, Time.deltaTime * damping));
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//RaycastHit rayHit = new RaycastHit();
			
			if (Physics.Raycast(ray, /*out rayHit, */1000f)){ //the 'out' command tells unity to populate the variable rayHit with data 
				
				if (poseMade){
					theLight.enabled = true;
					theLight.transform.rotation = Quaternion.LookRotation(ray.direction);
				}
				
			}
		} else {
			//If the arm is extended, on release it returns to its base position
			transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * damping);
			theLight.enabled = false;	
		}
	}
}

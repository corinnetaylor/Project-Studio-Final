using UnityEngine;
using System.Collections;

public class PersonMover : MonoBehaviour {
	
	public float moveRate = 5;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += transform.forward *Input.GetAxis("Vertical")*Time.deltaTime*moveRate;

		transform.Rotate (0f,Input.GetAxis("Horizontal") * (moveRate/2),0f);
		
		if (Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit = new RaycastHit();
			
			if (Physics.Raycast(ray, out rayHit, 100f)){ //the 'out' command tells unity to populate the variable rayHit with data 
				
				if (rayHit.collider.tag == "Door"){
				
					rayHit.collider.GetComponent<OpenDoor>().doorOpen();
				}
			}
		}
		
	}
	
}

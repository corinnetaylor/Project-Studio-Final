using UnityEngine;
using System.Collections;

public class CastingArm : MonoBehaviour {
	
	/*
	 * This script will control the casting arm, and interpret mouse clicks. It will instantiate Magic objects. It will allow the user to queue
	 * up kinds of magic. It talks to the HandController script to get what poses the player is making.
	 * 
	 * TODO: Work out how to instantiate spell objects at a slower rate, and to move in the direction that the mouse is pointing
	 * */
	
	public Transform theHand;
	public GameObject theSpell;
	public Transform thePlayer;
	
	//int colorPicker = 0;
	bool poseMade = false;
	Vector3 startPosition;
	float damping = 5;
	int magicType;
	
	//casting coroutine
//	public Rigidbody earthMagic;
//	public Rigidbody fireMagic;
//	public Rigidbody waterMagic;
//	
//	Rigidbody theMagic;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		
		//Updates the base position of the arm each frame
		startPosition = new Vector3(thePlayer.position.x + .9f, thePlayer.position.y + .3f, thePlayer.position.z + .5f);

		switch(theHand.GetComponent<HandController>().getPosition()){
		case 0: poseMade = false;
//			theLight.enabled = false;//Have to have this in here or else the light will remain on throughout different poses
			break;
		case 1: magicType = 1;
			poseMade = true;
			break;
		case 2: magicType = 1;
			poseMade = true;
			break;
		case 3: magicType = 1;
			poseMade = true;
			break;
		case 4: magicType = 2;
			poseMade = true;
			break;
		case 5: magicType = 2;
			poseMade = true;
			break;
		case 6: magicType = 3;
			poseMade = true;
			break;
		case 7: magicType = 3;
			poseMade = true;
			break;
		case 8: magicType = 3;
			poseMade = true;
			break;
		}
		
		

		if (Input.GetMouseButton(0)){
			//While clicking, the 'arm' moves forward slightly, to simulate being extended
			transform.position = new Vector3(transform.position.x,transform.position.y,Mathf.Lerp(transform.position.z, startPosition.z + .5f, Time.deltaTime * damping));
			
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			//RaycastHit rayHit = new RaycastHit();
//			
//			if (Physics.Raycast(ray, /*out rayHit, */1000f)){ //the 'out' command tells unity to populate the variable rayHit with data 
//				
//							
//			}
			
			if (poseMade){
					
					//Instantiate objects here
//					StartCoroutine("Cast");
//					theSpell.GetComponent<Magic>().cast (magicType, startPosition);
				Debug.Log ("Casting magic type " + magicType);
				if (!transform.audio.isPlaying){
					transform.audio.Play();	
				}
				}
			
		} else {
			//If the arm is extended, on release it returns to its base position
//			StopCoroutine("Cast");
			transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * damping);
		}
	}
	
	
	
//	IEnumerator Cast(){
//		//Catches type exceptions, so that the Instantiate command doesn't execute
//		//THESE ARE CURRENTLY HARDCODED AND NEED TO BE CHANGED WITH DIFFERENT KINDS OF MAGIC
//		if (magicType > 3 || magicType < 1){
//			
//		}
//		while (true){
//			switch (magicType){
//			case 1: theMagic = earthMagic;
//				break;
//			case 2: theMagic = fireMagic;
//				break;
//			case 3: theMagic = waterMagic;
//				break;
//			}
//			
//			Instantiate(earthMagic, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5), Quaternion.identity);
//			theMagic.AddForce(Input.mousePosition);
//			
//			yield return new WaitForSeconds(5f); //Time to wait between each instantiated spell
//		}	
//		
//	}
}

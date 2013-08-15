using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	bool startDoorOpen = false;
	bool startDoorClose = false;
	bool moving = false;
	
	float limit;
	float rate = 5;
	float startingY;
	
	int colorNumber;
//	int openDoorCounter = 0;
	
	Color currentColor;
	
	//Randomly sets the number of 'hits' the door needs to be opened
	public int doorHits;
	
	
	public Transform sphere1;
	public Transform sphere2;
	public GUIText doorsOpened;
	public TextMesh display1;
	public TextMesh display2;
	
	// Use this for initialization
	void Start () {
		startingY = transform.position.y;
		limit = startingY + 5.9f;
		
		PickColor();
		SetDoorHits();
	}
	
	// Update is called once per frame
	void Update () {
		
//		doorsOpened.text = ("Doors Opened: " + openDoorCounter.ToString());
		
		sphere1.renderer.material.color = currentColor;
		sphere2.renderer.material.color = currentColor;
		
		display1.text = doorHits.ToString();
		display2.text = doorHits.ToString();
		
		if (doorHits == 0){
			DoorOpen();	
			
		}
		
		if (Input.GetKeyDown(KeyCode.E)){
			DoorOpen();
		}
		
		if (moving){
			if (!transform.audio.isPlaying){
			transform.audio.Play ();
			}
		} else {
			transform.audio.Stop();	
		}
		
		if (startDoorOpen){
			moving = true;
			
			
			
			transform.position += new Vector3(0f, rate*Time.deltaTime,0f);
			
			
			
			if (transform.position.y >= limit){
				startDoorOpen = false;
				startDoorClose = true;
				MainController.instance.IncrementDoorUp();
			}
		}
		
		if (startDoorClose){
			
			transform.position += new Vector3(0f, -rate*Time.deltaTime,0f);
			
			
			if (transform.position.y < startingY){
				moving = false;
				startDoorClose = false;
				SetDoorHits();//Resets doorHits at the very end of its animation 
			}
			
		}
	
	}
	
	public void DoorOpen(){
	
		if (!startDoorClose){
			Debug.Log ("Door Up");
			startDoorOpen = true;
//			openDoorCounter++;
			
		}
	}
	
	void PickColor(){
		
		//Only 3 colors, but set the range to be one higher
		colorNumber = Random.Range(1, 4);
		
		switch (colorNumber){
		case 1: currentColor = Color.green;
			break;
		case 2: currentColor = Color.red;
			break;
		case 3: currentColor = Color.blue;
			break;
		}
		
	}
	
	//Sets the number of spells necessary to open the door
	void SetDoorHits(){
		doorHits = Random.Range(1,4);	
	}
	
	void OnCollisionEnter(Collision spell){
		
		//If one of the magic types hits a door
		if (spell.gameObject.tag == "Earth" || spell.gameObject.tag == "Fire" || spell.gameObject.tag == "Water"){
			//If the type of magic
			if (spell.gameObject.tag == "Earth"){
					Debug.Log("Earth");	
				transform.parent.audio.Play();
				//Matches the color of the door
				if (colorNumber == 1){
						doorHits--; //Decrease the number of hits until the door opens by one
						PickColor(); //Select a new spell
					//play the earth sound
					
					
					} else { //Else reset the counter on the door, this punishes miscasts
					SetDoorHits();
				}
			} else if(spell.gameObject.tag == "Fire"){
				
					Debug.Log("Fire");	
					if (colorNumber == 2){
						doorHits--;
						PickColor();
					} else { //Else reset the counter on the door, this punishes miscasts
					SetDoorHits();
				}
				
			} else if(spell.gameObject.tag == "Water") {
					Debug.Log("Water");	
					if (colorNumber == 3){
						doorHits--;
						PickColor();
					} else { //Else reset the counter on the door, this punishes miscasts
					SetDoorHits();
				}
			}
			//The spell is ultimately destroyed on impact
			Destroy (spell.gameObject);
		}
			
		}
		
	}
	

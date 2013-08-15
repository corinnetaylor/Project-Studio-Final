using UnityEngine;
using System.Collections;

public class instructions : MonoBehaviour {

	
	public GUIText directions;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		directions.text = ("Your goal is to get to the Green Room on the other side of the maze.");
		directions.text += ("\n There are many twists and turns, plus there are doors blocking your way.");
		directions.text += ("\n Each door can be opened with the right combination of spells.");
		directions.text += ("\n You command the forces of Earth, Fire, and Water.");		
		directions.text += ("\n Pick which spell you want to cast with your left arm, ");
		
		directions.text += ("\n and cast with your right.");
		directions.text += ("\n (Press Space to Continue)");
		
		if (Input.GetKeyDown (KeyCode.Space)){
			directions.text = ("Use the WASD keys to control your gestures. \n Different gestures result in different magic.");
			directions.text += ("\n Right click with the mouse to aim your casting arm.");
			directions.text += ("\n While you are making a gesture, left click to cast a spell.");
			directions.text += ("\n Hold down space to move forwards.");
			directions.text += ("\n Click anywhere to begin.");
			
		}
		
	}
}

using UnityEngine;
using System.Collections;

public class instructions : MonoBehaviour {

	
	public GUIText directions;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		directions.text  = ("You are a genie separated from your lamp."); 
		directions.text += ("\n You must search the maze for your home.");
		directions.text += ("\n There are many doors blocking your path, and they will only open if you use");
		directions.text += ("\n the correct combination of magic. As a mighty genie, you command the");
		directions.text += ("\n phenomenol cosmic powers of Earth, Fire, and Water.");
		directions.text += ("\n");
		directions.text += ("\n");
		directions.text += ("\n");
		directions.text += ("\n");
		directions.text += ("\n");
		directions.text += ("\n");
		directions.text += ("\n You can choose which spell to cast with the W, A, S, and D keys.");
		directions.text += ("\n Use the mouse to cast your magic. Right click to aim, left click to cast.");
		directions.text += ("\n Hold down Space to move forward.");
		directions.text += ("\n Be warned! You cannot survive for long away from your lamp.");
		directions.text += ("\n If you don't find your lamp in time, you will lose!");
		directions.text += ("\n");
		directions.text += ("\n");
		directions.text += ("\n Press Enter when you are ready to begin.");

		
		if (Input.GetKeyDown (KeyCode.Return)){
			
			Application.LoadLevel("MainGame");
			
		}
		
	}
}

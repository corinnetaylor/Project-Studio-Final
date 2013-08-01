using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.LeftShift)){
			
			if (Application.loadedLevelName == "Prototype1"){
				Application.LoadLevel ("Prototype2");
			} else {
				Application.LoadLevel ("Prototype1");
			}
			
		}
	
	}
}

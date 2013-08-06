using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {
	
	//This script needs work
	
//	public Rigidbody earthMagic;
//	public Rigidbody fireMagic;
//	public Rigidbody waterMagic;
//	
//	Rigidbody theMagic;
//	
//	float speed = 100;
//	
//	public Transform theArm;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
//	public void cast(int type, Vector3 startPosition){		
//		
//		//Catches type exceptions, so that the Instantiate command doesn't execute
//		//THESE ARE CURRENTLY HARDCODED AND NEED TO BE CHANGED WITH DIFFERENT KINDS OF MAGIC
//		if (type > 3 || type < 1){
//			return;
//		}
//		
//		switch (type){
//		case 1: theMagic = earthMagic;
//			break;
//		case 2: theMagic = fireMagic;
//			break;
//		case 3: theMagic = waterMagic;
//			break;
//		}
//		
//		Rigidbody castMagic = Instantiate(theMagic, startPosition, Quaternion.identity);
//		theMagic.velocity = transform.forward * speed;
//	}
}

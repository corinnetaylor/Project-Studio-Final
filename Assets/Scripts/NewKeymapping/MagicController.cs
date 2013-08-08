using UnityEngine;
using System.Collections;

public class MagicController : MonoBehaviour {
	
	public GameObject earthMagic;
	public GameObject fireMagic;
	public GameObject waterMagic;
	
	GameObject theMagic;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.U)){
			
			cast (Random.Range(1,4), transform.position, Vector3.zero);
			
		}
		
	}
	
		public void cast(int type, Vector3 startPosition, Vector3 destination){		
		
		//Catches type exceptions, so that the Instantiate command doesn't execute
		//THESE ARE CURRENTLY HARDCODED AND NEED TO BE CHANGED WITH DIFFERENT KINDS OF MAGIC
		if (type > 3 || type < 1){
			return;
		}
		
		switch (type){
		case 1: theMagic = earthMagic;
			break;
		case 2: theMagic = fireMagic;
			break;
		case 3: theMagic = waterMagic;
			break;
		}
		
		theMagic = Instantiate(theMagic, startPosition, Quaternion.identity) as GameObject;
	}
}

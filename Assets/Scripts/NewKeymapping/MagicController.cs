using UnityEngine;
using System.Collections;

public class MagicController : MonoBehaviour {
	
	public Rigidbody earthMagic;
	public Rigidbody fireMagic;
	public Rigidbody waterMagic;
	
	Rigidbody theMagic;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
//		transform.(Camera.mainCamera.transform.rotation.eulerAngles.x, player.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		
		if (Input.GetKeyDown(KeyCode.U)){
			
			Cast (Random.Range(1,4), Vector3.zero);
			
		}
		
	}
	
		public void Cast(int type, Vector3 destination){		
		
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
		
		
		//Issue with using the casting arm is that the cylinder is set at 90 degrees, so it's throwing the rotation off
		theMagic = Instantiate(theMagic, transform.position, transform.rotation) as Rigidbody;
		theMagic.GetComponent<Magic>().SetDestination(destination);
	}
}

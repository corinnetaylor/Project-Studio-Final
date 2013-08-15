using UnityEngine;
using System.Collections;

public class WallHit : MonoBehaviour {
	
	public GameObject EarthHit;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
void OnCollisionEnter(Collision spell){
		
		//If one of the magic types hits a door
		if (spell.gameObject.tag == "Earth" || spell.gameObject.tag == "Fire" || spell.gameObject.tag == "Water"){
			//If the type of magic
			if (spell.gameObject.tag == "Earth"){
					Debug.Log("Earth");	
				EarthHit.transform.audio.Play();

			}
			//The spell is ultimately destroyed on impact
			Destroy (spell.gameObject);
		}
			
		}
}

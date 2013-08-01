using UnityEngine;
using System.Collections;

public class PoseCalculator : MonoBehaviour {
	
	//Assign each finger in inspector
	public Transform thumb; //1
	public Transform index; //2
	public Transform middle; //3
	public Transform ring; //4
	public Transform pinkie; //5

	//Initialize all the booleans to determine which fingers are down and which are up
	bool is1Down;
	bool is2Down;
	bool is3Down;
	bool is4Down;
	bool is5Down;
	
	int poseNumber = 0; //Pose number is 0 if no pose is being made, pose 1-4 correspond to poses
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			//Updates for the positions of the fingers
			is1Down = thumb.GetComponent<FingerControl>().isKeyDown();
			is2Down = index.GetComponent<FingerControl>().isKeyDown();
			is3Down = middle.GetComponent<FingerControl>().isKeyDown();
			is4Down = ring.GetComponent<FingerControl>().isKeyDown();
			is5Down = pinkie.GetComponent<FingerControl>().isKeyDown();
		
						
		if (is1Down && is2Down && is3Down && is4Down && is5Down){ //fist with a thumb out (all fingers down)
				
				poseNumber = 1;
			Debug.Log (poseNumber);
				
			} else if (is1Down && !is2Down && is3Down && is4Down && is5Down){ //L shape (all but index down)
				
				poseNumber = 2;
			Debug.Log (poseNumber);
				
			} else if (is1Down && !is2Down && is3Down && is4Down && !is5Down){ //Rock out (thumb, middle, and ring finger down)
				
				poseNumber = 3;
			Debug.Log (poseNumber);
				
			} else if (!is1Down && !is2Down && !is3Down && is4Down && is5Down){ //Peace (ring and pinkie down)
				
				poseNumber = 4;
			Debug.Log (poseNumber);
				
			} else {
		
				poseNumber = 0;
			
		}	
		
		
		
	}
	
	public int getPoseNumber(){
		
		return poseNumber;	
		
	}
	
}

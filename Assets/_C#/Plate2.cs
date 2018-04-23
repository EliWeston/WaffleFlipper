using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate2 : MonoBehaviour {
	
	[Header ("Set in Inspector")]
	//public GameObject panTrig;

	public float speed = 1f;
	public float rightEdge = 30f;
    public float leftEdge = 30f;
	public float chanceToChangeDirections = 0.05f;
	//public float collMover = 1f;

    private GameObject plate;

    //Collider pancakeColl;
    //Collider myCollider;
    //private GameObject	cylinder;
    //private GameObject pancake;
    //private Pancake pancakeScript;
    //private Rigidbody pancakeBod;
    //public GameObject lastPancake;

    //private float plateHeight;
    //private float pancakeHeight;
    //private bool firstTime = true;
    //Collider capColl;
    //FixedJoint joint;

    void Start ()
    {
	plate = this.gameObject;    
    }

	void Update ()
	{
		//Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//changing direction
		if (pos.x < -leftEdge) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > rightEdge) {
			speed = -Mathf.Abs (speed);
		}
		/*if ((cylinder != null) && (lastPancake != null)) {
			if (cylinder.transform.position.y >= lastPancake.transform.position.y) { 
				panTrig.transform.position = new Vector3 (cylinder.transform.position.x, cylinder.transform.position.y + collMover, cylinder.transform.position.z);
			}
		} else {
				panTrig.transform.position = new Vector3 (plate.transform.position.x, plate.transform.position.y + collMover, plate.transform.position.z);
		}*/
 
    }

	/*void OnTriggerEnter (Collider other)
	{ 
		if ((other.gameObject.tag == "Cylinder") && (other.gameObject.transform.parent != this.gameObject)) {

			cylinder = other.gameObject;
			pancake = cylinder.transform.parent.gameObject;
			pancakeScript = pancake.GetComponent<Pancake> ();
			plateHeight = this.gameObject.transform.position.y;
			pancakeHeight = cylinder.gameObject.transform.position.y;
			print(plateHeight);
			print(pancakeHeight);
			pancakeScript.isFlying = false;
			cylinder.transform.rotation = Quaternion.Euler (0, 0, 0);
			//pancakeBod.isKinematic = true;
			pancake.transform.parent = this.transform;
			Invoke ("endPancake", 1);
			//pancake = null;
			//lastPancake = cylinder;

		}
	}*/
	/*void endPancake ()
	{
		if (pancake != null) {
			pancakeBod = pancake.GetComponentInChildren<Rigidbody> ();
		if (pancakeHeight >= plateHeight) {
			print("whoa dicks");
			pancakeBod.isKinematic = true;
			pancakeScript.isStable = true;
			lowScore += 1;
            scoreGT.text = lowScore.ToString();
            if (lowScore > HighScore.score)
            {
                HighScore.score = lowScore;
            }
		}
		}
		pancake = null;
		lastPancake = cylinder;
		}
	void FixedUpdate () {
		if (Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
		
    }*/
}

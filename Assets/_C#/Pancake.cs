using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pancake : MonoBehaviour {

	public float rotationsPerMinute = 10.0f;
	public bool isFlying = false;
	public bool isStable = false;

	Collider pancakeColl;
	Collider myCollider;
	private GameObject cylinder;
	private GameObject	pancake;
	private Pancake pancakeScript;
	public float panHeight;

	[Header("Set in Inspector")]
	public GameObject plate;
	public GameObject cylChild;
	public Rigidbody  cylBod;
 
	void Start () {
	cylBod = cylChild.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{  
		if (isFlying == true) {
			
			cylChild.transform.Rotate (0, 0, -24 * rotationsPerMinute * Time.deltaTime, 0);
		}
		if (isStable == true) {
			if (cylChild.transform.position.y < 8) {
				cylBod.isKinematic = false;
			}
		}	
}
	void OnCollision (){
		isFlying = false;
	
}
}

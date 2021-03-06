﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
	static private Slingshot S;
	[Header("Set in Inspector")]
	public GameObject 	prefabPancake;
	public float		velocityMult = 8f;

	[Header("Set Dynamically")]
	public GameObject	launchPoint;
	public Vector3		launchPos;
	public GameObject	pancake;
	public bool aimingMode;

	private Rigidbody	pancakeRigidbody;
	private Pancake 	pancakeScript;
	private GameObject  Spatula; 

	//public float    torque;
	//int X;
	//int Y;

	//public float  rotationsPerMinute = 10.00f;

	static public Vector3 LAUNCH_POS {
		get {
			if (S == null) return Vector3.zero;
			return S.launchPos;
		}
	}
	void Awake() {
		S = this;
		Transform launchPointTrans = transform.Find ("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive (false);
		launchPos = launchPointTrans.position;
	}

	void OnMouseEnter() {
		//print ("Slingshot:OnMouseEnter()");
		launchPoint.SetActive( true );
	}

	void OnMouseExit(){
		//print ("Slingshot:OnMouseExit()");
		launchPoint.SetActive( false );
	}

	void OnMouseDown(){
		aimingMode = true;
		Spatula = this.gameObject.transform.Find("Spatula").gameObject;
		//Spatula = this.transform.Find("Spatula").gameObject;
		pancake = Instantiate (prefabPancake) as GameObject;
		pancake.transform.position = launchPos;
		//projectile.GetComponent<Rigidbody> ().isKinematic = true;

		pancakeRigidbody = pancake.GetComponentInChildren<Rigidbody> ();
		pancakeRigidbody.isKinematic = true;

		pancakeScript = pancake.GetComponent<Pancake> ();
	}

	void Update(){

		if (!aimingMode)
			return;

		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		Vector3 mouseDelta = mousePos3D - launchPos;
		float maxMagnitude = this.GetComponent<SphereCollider> ().radius;
		if (mouseDelta.magnitude > maxMagnitude) {
			mouseDelta.Normalize ();
			mouseDelta *= maxMagnitude;  
		}
        if (mouseDelta.x >= 0)
        {
            mouseDelta.Normalize();
        }
        //print(mouseDelta);

        Vector3 projPos = launchPos + mouseDelta;
		pancake.transform.position = projPos;
		Spatula.transform.position = projPos;

        if (projPos.x > -14.7f)
        {
            projPos.x = -14.7f;
        }

		if (Input.GetMouseButtonUp (0)) {
			aimingMode = false;
			pancakeRigidbody.isKinematic = false;
			pancakeRigidbody.velocity = -mouseDelta * velocityMult;

			pancakeScript.isFlying = true;
			pancake = null;
			Spatula.transform.Rotate(0, 0, -60);
			Invoke ("spatDown", 1);
		}
	}

	void spatDown ()
	{
		Spatula.transform.Rotate (0, 0, 60);
		Spatula.transform.localPosition = Vector3.zero;
}
}
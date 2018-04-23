using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBounds : MonoBehaviour {
    private GameObject pancakeTransform;
    private GameObject pancake;

	// Use this for initialization
	void Start () {
        pancakeTransform = this.gameObject;
        pancake = pancakeTransform.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(pancakeTransform.transform.position.y < -30)
        {
            Destroy(pancake);
        }
	}
}

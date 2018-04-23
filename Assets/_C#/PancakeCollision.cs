using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PancakeCollision : MonoBehaviour {
    [Header("Set Automatically")]
    private GameObject pancake;
    private Pancake pancakeScript;
    private Plate2 plateScript;
    private float plateHeight;
    private float pancakeHeight;
    private Rigidbody pancakeBod;
    //ublic Text scoreGT;
    static public int lowScore = 0;

    [Header("Set in Inspector")]
    public GameObject plate;
    public GameObject spatula;


    // Use this for initialization
    void Awake()
    {
        pancake = this.gameObject;
        plateHeight = plate.transform.position.y;
        /*scoreGT.text = "0";
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();*/
    }
    void Start() {
        pancakeScript = pancake.transform.parent.gameObject.GetComponent<Pancake>();
        plateScript = plate.gameObject.GetComponent<Plate2>();


    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag != "Spatula") && (pancakeScript.isFlying !=false)) 
        {
            
            pancakeHeight = this.transform.position.y;


            pancake.transform.rotation = Quaternion.Euler(0, 0, 0);
            pancake.transform.parent = other.transform;
            print(other);
            pancakeScript.isFlying = false;
            endPancake();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if((other.gameObject.tag !="Spatula") && (pancakeScript.isFlying !=true))
        {
            pancakeScript.isFlying = true;
            pancakeBod.isKinematic = false;
            pancakeScript.isStable = false;
            lowScore -= 1;
        }
            
    }
    void endPancake()
    {
        pancakeBod = pancake.GetComponentInChildren<Rigidbody>();

        if (pancakeHeight >= plateHeight)
        {
            print("Thats a pancake");
            pancakeBod.isKinematic = true;
            pancakeScript.isStable = true;
            lowScore += 1;
            //scoreGT.text = lowScore.ToString();
            if (lowScore > HighScore.score)
            {
                HighScore.score = lowScore;
            }
        }
    }
}

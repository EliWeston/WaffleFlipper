using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour {
    public Text scoreGT;

    // Use this for initialization
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    void Update()
    {
        scoreGT.text = PancakeCollision.lowScore.ToString();
    }
}

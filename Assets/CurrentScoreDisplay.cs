using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreDisplay : MonoBehaviour {

    public int score = 0;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "current score: " + score;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            score += 1000;
        }
    }
}

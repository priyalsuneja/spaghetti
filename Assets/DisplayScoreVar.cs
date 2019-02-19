using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayScoreVar : MonoBehaviour {

    public Font enteredFont;

    public void displayScoreVariable()
    {
        gameObject.GetComponent<Text>().font = enteredFont;
        gameObject.GetComponent < Text >().text = "CURRENT SCORE: " + TableCreator.score.ToString();
    }
	// Use this for initialization
	void Start () {
        displayScoreVariable();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

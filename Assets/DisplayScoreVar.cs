using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayScoreVar : MonoBehaviour {

    public void displayScoreVariable()
    {
        gameObject.GetComponent < Text >().text = "Current Score: " + TableCreator.score.ToString();
    }
	// Use this for initialization
	void Start () {
        displayScoreVariable();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableDisplay : MonoBehaviour {

    public int health = 0;
    public Text healthText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = health.ToString();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            health += 1000;
        }
	}
}

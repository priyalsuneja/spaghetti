using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstRow : MonoBehaviour {
    public int x;
    public int y;
    public int n;
    public int a;
    public int b;

    public Text rowText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rowText.text = x + "      " + y + "      " + n + "      " + a + "      " + b;
    }
}

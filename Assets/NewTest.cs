using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string stringtest = "1 == 1";
        CallServer.ExpToJS(stringtest);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

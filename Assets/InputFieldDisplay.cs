using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        gameObject.GetComponent<InputField>().text = GetInputExpression.exp;
        //Debug.Log("GetInputExpression.exp is " + GetInputExpression.exp);
        //Debug.Log("etComponent<Text>().text is " + gameObject.GetComponent<Text>().text);
    }
}

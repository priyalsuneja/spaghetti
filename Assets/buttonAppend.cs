using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonAppend : MonoBehaviour {
    public static void ButtonTrigger()
    {
        GetInputExpression.exp += EventSystem.current.currentSelectedGameObject.name;
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Backspace()
    {
        if (GetInputExpression.exp.Length > 0)
        {
            GetInputExpression.exp = GetInputExpression.exp.Substring(0, GetInputExpression.exp.Length - 1);
        }
    }

    public void Clear()
    {
        GetInputExpression.exp = "";
    }

    public void Enter()
    {
        
    }
}

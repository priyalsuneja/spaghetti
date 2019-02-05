using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterScript : MonoBehaviour {
    public void enter()
    {
        Debug.Log("Entered");
        for(int i = 0; i < TableCreator.rows; i++)
        {
            if(TableCreator.textArray[i, TableCreator.cols - 1].GetComponent<Text>().text != "True")
            {
                Debug.Log("returning");
                return;
            }
        }
        TableCreator.counter++;
        TableCreator.score++;
        Debug.Log(TableCreator.counter);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

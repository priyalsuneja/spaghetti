using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableCreator : MonoBehaviour {

    int[,,] data;
    string[] variables;
    int cols;
    int rows;
    float startY = -628.4;
    float startX = -1029;
    float yDiff = 175;
    float xDiff = 216;
    float varY = -426;

    public Text[,] textArray;

	// Use this for initialization
	void Start () {
        JSONParser json = new JSONParser();
        data = json.result.data;
        variables = json.result.variables;
        cols = variables.Length; // num of vars
        rows = data.Length; // num of data points
        textArray = new Text[rows, cols];
    }
	
	// Update is called once per frame
	void Update () {
		for( int i = 0; i < rows; i++)
        {
            for( int j = 0; j < cols; j++)
            {
                textArray[i, j].alignment = TextAnchor.MiddleCenter;
                textArray[i, j](new Rect(startX + (xDiff * j), startY + (yDiff * i), xDiff, yDiff));
            }
        }
	}
}

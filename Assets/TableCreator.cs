using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableCreator : MonoBehaviour {

    int[,] data;
    string[] variables;
    public int cols;
    public int rows;
    double startY = -628.4;
    double startX = -1029;
    double yDiff = 175;
    double xDiff = 216;
    double varY = -426;

    //public Text textLol;
    public Text[,] textArray;

    // Use this for initialization
    void Start () {
        JSONParser json = new JSONParser();
        data = json.result.data;
        variables = json.result.variables;
        cols = variables.Length; // num of vars
        rows = data.Length; // num of data points

        textArray[0, 0] = gameObject.AddComponent<Text>();



    }
	
	// Update is called once per frame
	void Update () {
		/*for( int i = 0; i < rows; i++)
        {
            for( int j = 0; j < cols; j++)
            {
                //[i, j].alignment = TextAnchor.MiddleCenter;
                textArray[i, j].text = data[i, j] + "";
            }
        }*/

	}
}

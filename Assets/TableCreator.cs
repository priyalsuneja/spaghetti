using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableCreator : MonoBehaviour {

    int[,] data;
    string[] variables;
    int cols;
    int rows;
    public GameObject canvas;
    public Font font;
    float startX = -405;//-628;
    float startY = 621;//-1029;
    float canvasX = 720;
    float canvasY = 1280;
    float yDiff = 175;
    float xDiff = 300;
    float varY = -426;

     public GameObject[,] textArray;

    // Use this for initialization
    void Start () {
        JSONParser json = new JSONParser();
        data = json.result.data;
        variables = json.result.variables;
        cols = variables.Length; // num of vars
        //Console.WriteLine("cols: " + cols);
        rows = data.Length / variables.Length; // num of data points
        //Console.WriteLine("rows: " + rows);
        textArray = new GameObject[rows, cols];

        
        for( int i = 0; i < rows; i ++)
        {
            for( int j = 0; j < cols; j++)
            {
                GameObject newObj = new GameObject();
                newObj.transform.SetParent(canvas.transform);
                newObj.name = "(" + i + ", " + j + ")";
                newObj.AddComponent<RectTransform>();
                newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 225);
                //newObj.GetComponent<RectTransform>().position = 
                textArray[i, j] = newObj;
                Text myText = newObj.AddComponent<Text>();
                myText.text = i + ", " + j;
                myText.fontSize = 91;
                myText.font = font;
                myText.alignment = TextAnchor.MiddleCenter;
                textArray[i, j].transform.position = new Vector3(startX + 800 + (xDiff * j), startY + 1300 - (yDiff * i), 0);
            }
        }
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

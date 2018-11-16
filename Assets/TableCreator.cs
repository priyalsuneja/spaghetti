using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableCreator : MonoBehaviour {

    int[][][] data;
    string[] variables;
    int cols;
    int rows;
    public GameObject canvas;
    public Font font;
    float startX = 300;
    float startY = 1921;
    float canvasX = 720;
    float canvasY = 1280;
    float yDiff = 175;
    float xDiff = 300;
    float varY = -426;

    Color variableColor;
    public GameObject[,] textArray;
    GameObject variableText;

    // Use this for initialization
    void Start () {
        JSONParser json = new JSONParser();
        data = json.result.data;
        variables = json.result.variables;
        cols = variables.Length; // num of vars, also data[0][0].Length
        //Console.WriteLine("cols: " + cols);
        rows = data[0].Length; // num of data points
        //Console.WriteLine("rows: " + rows);
        textArray = new GameObject[rows, cols];

        // creating variable text display
        variableText = new GameObject();
        variableText.transform.SetParent(canvas.transform);
        variableText.name = "Variable Text";
        variableText.AddComponent<RectTransform>();
        variableText.AddComponent<Text>();
        variableText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        variableColor = new Color(247, 123, 85, 255);
        variableText.GetComponent<Text>().color = variableColor;
        variableText.GetComponent<RectTransform>().sizeDelta = new Vector2(1133, 175);
        variableText.transform.position = new Vector3(-153 + 720 + 112, 426 + 370 + 1280, 0); 
        for ( int i = 0; i < variables.Length; i++ )
        {
            variableText.GetComponent<Text>().text += variables[i] + "      ";
        }
        variableText.GetComponent<Text>().text += "result";
        variableText.GetComponent<Text>().font = font;
        variableText.GetComponent<Text>().fontSize = 91;
        

        // creating table
        for( int i = 0; i < rows; i ++)
        {
            for( int j = 0; j < cols; j++)
            {
                GameObject newObj = new GameObject();
                newObj.transform.SetParent(canvas.transform);
                newObj.name = "(" + i + ", " + j + ")";
                newObj.AddComponent<RectTransform>();
                newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 225);
                textArray[i, j] = newObj;
                Text myText = newObj.AddComponent<Text>();
                myText.text = data[0][i][j].ToString();
                myText.fontSize = 91;
                myText.font = font;
                myText.alignment = TextAnchor.MiddleCenter;
                textArray[i, j].transform.position = new Vector3(startX + (xDiff * j), startY - (yDiff * i), 0);
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

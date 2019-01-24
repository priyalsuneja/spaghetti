using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Jint;


public class TableCreator : MonoBehaviour
{

    int[][][] data;
    string[] variables;
    int cols;
    int rows;
    public GameObject canvas;
    public Font font;
    float startX = 250;
    float startY = 1921;
    float canvasX = 720;
    float canvasY = 1280;
    float yDiff = 175;
    float xDiff = 300;
    float varY = -426;
    int level = 1;

    Color variableColor;
    public GameObject[,] textArray;
    GameObject variableText;

    // Use this for initialization
    void Start()
    {
        JSONParser json;
        if ( level == 1) {
            json = new JSONParser();
            level = 2;
        } else
        {
            json = new JSONParser("{ \"id\":2, \"jsonrpc\":\"2.0\", \"result\":{ \"LevelNumber\":5,\"data\":[[[1,7,0],[2,7,1],[3,7,3],[4,7,6],[5,7,10],[6,7,15],[7,7,21]],[],[]],\"goal\":\"verify\",\"hint\":null,\"id\":\"s-gauss_sum_true-unreach-call-auto\",\"lvlSet\":\"fb\",\"startingInvs\":[],\"typeEnv\":{\"i\":\"int\",\"n\":\"int\",\"sum\":\"int\"},\"variables\":[\"i\",\"n\",\"sum\"]}}");
            level = 1;
        }
        
        data = json.result.data;
        variables = json.result.variables;
        cols = variables.Length + 1; // num of vars, also data[0][0].Length
        //Console.WriteLine("cols: " + cols);
        rows = data[0].Length; // num of data points
        //Console.WriteLine("rows: " + rows);
        textArray = new GameObject[rows, cols];

        // creating variable text display
        /*variableText = new GameObject();
        variableText.transform.SetParent(canvas.transform);
        variableText.name = "Variable Text";
        variableText.AddComponent<RectTransform>();
        variableText.AddComponent<Text>();
        variableText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        variableColor = new Color(247, 123, 85, 255);
        variableText.GetComponent<Text>().color = variableColor;
        variableText.GetComponent<RectTransform>().sizeDelta = new Vector2(1133, 175);
        variableText.transform.position = new Vector3(-153 + 720 + 112, 426 + 370 + 1280, 0);
        for (int i = 0; i < variables.Length; i++)
        {
            variableText.GetComponent<Text>().text += variables[i] + "     ";
        }
        variableText.GetComponent<Text>().text += "result";
        variableText.GetComponent<Text>().font = font;
        variableText.GetComponent<Text>().fontSize = 91;
        */
        variableColor = new Color(247, 123, 85, 255);

        for (int i = 0; i < variables.Length; i++)
        {
            GameObject newObj = new GameObject();
            newObj.transform.SetParent(canvas.transform);
            newObj.name = variables[i];
            newObj.AddComponent<RectTransform>();
            newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 225);
            textArray[0, i] = newObj;
            Text myText = newObj.AddComponent<Text>();
            myText.text = variables[i];
            myText.fontSize = 91;
            myText.font = font;
            myText.alignment = TextAnchor.MiddleCenter;
            myText.color = Color.gray;//variableColor;
            textArray[0, i].transform.position = new Vector3(startX + (xDiff * i), startY + yDiff, 0);
        }

        // results
        GameObject obj = new GameObject();
        obj.transform.SetParent(canvas.transform);
        obj.name = "result";
        obj.AddComponent<RectTransform>();
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 225);
        textArray[0, variables.Length] = obj;
        Text text = obj.AddComponent<Text>();
        text.text = "result";
        text.fontSize = 91;
        text.font = font;
        text.color = Color.gray;// variableColor;
        text.alignment = TextAnchor.MiddleCenter;
        textArray[0, variables.Length].transform.position = new Vector3(startX + (xDiff * variables.Length), startY + yDiff, 0);

        // creating table
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject newObj = new GameObject();
                newObj.transform.SetParent(canvas.transform);
                newObj.name = "(" + i + ", " + j + ")";
                newObj.AddComponent<RectTransform>();
                newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 225);
                textArray[i, j] = newObj;
                Text myText = newObj.AddComponent<Text>();
                if (j == cols - 1)
                {
                    var engine = new Engine();

                    for (int k = 0; k < cols - 1; k++)

                    {

                        engine.SetValue(variables[k], data[0][i][k]);

                    }
                    try
                    {
                        Debug.Log(GetInputExpression.exp);
                        engine.Execute(GetInputExpression.exp);

                        myText.text = engine.GetCompletionValue().ToObject().ToString();
                    }
                    catch (Exception err)
                    {
                        Debug.Log(err.Message);
                        myText.text = "";
                    }
                }
                else
                {
                    myText.text = data[0][i][j].ToString();
                }
                myText.fontSize = 91;
                myText.font = font;
                myText.alignment = TextAnchor.MiddleCenter;
                textArray[i, j].transform.position = new Vector3(startX + (xDiff * j), startY - (yDiff * i), 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*for( int i = 0; i < rows; i++)
        {
            for( int j = 0; j < cols; j++)
            {
                //[i, j].alignment = TextAnchor.MiddleCenter;
                textArray[i, j].text = data[i, j] + "";
            }
        }*/
        for (int i = 0; i < rows; i++)
        {
            var engine = new Engine();

            for (int k = 0; k < cols - 1; k++)

            {

                engine.SetValue(variables[k], data[0][i][k]);

            }
            try
            {
                Debug.Log(GetInputExpression.exp);
                engine.Execute(GetInputExpression.exp);
                Debug.Log(engine.GetCompletionValue().ToObject());
                textArray[i, cols - 1].GetComponent<Text>().text = engine.GetCompletionValue().ToObject().ToString();
            }
            catch (Exception err)
            {
                Debug.Log(err.Message);
            }
        }
    }
}
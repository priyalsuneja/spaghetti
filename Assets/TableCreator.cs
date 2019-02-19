using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Jint;
using UnityEngine.SceneManagement;


public class TableCreator : MonoBehaviour
{
    JSONParser json;
    public static int counter = 0;
    public static int score = 0;

    int[][][] data;
    string[] variables;
    public static int cols;
    public static int rows;
    public GameObject canvas;
    public Font font;
    float startX = 250;
    float startY = 1921;
    float canvasX = 720;
    float canvasY = 1280;
    float yDiff = 175;
    float xDiff = 300;
    float varY = -426;
    public GameObject parentCanvas;
    public GameObject panel;

    Color variableColor;
    public static GameObject[,] textArray;
    public static GameObject[,] varArray;
    GameObject variableText;
    public static string currentJson; //= "{\"id\":68,\"jsonrpc\":\"2.0\",\"result\":{\"LevelNumber\":6,\"ShowQuestionaire\":true,\"data\":[[[1,0,7,0],[2,1,7,1],[3,2,7,3],[4,3,7,6],[5,4,7,10],[6,5,7,15],[7,6,7,21]],[],[]],\"goal\":\"verify\",\"hint\":null,\"id\":\"m - sorin03 - auto\",\"lvlSet\":\"fb\",\"startingInvs\":[],\"typeEnv\":{\"i\":\"int\",\"j\":\"int\",\"n\":\"int\",\"s\":\"int\"},\"variables\":[\"i\",\"j\",\"n\",\"s\"]}}";
    // Use this for initialization
    void Start()
    {
        currentJson = CallServer.ExecuteServerCall();
        json = new JSONParser(currentJson);
        LoadTable(json);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Counter from Table: " +counter);
        if (counter == 3) {
            
            
            //ClearTable();
            displayScore();

        }

        for (int i = 0; i < rows; i++)
        {
            var engine = new Engine();

            for (int k = 0; k < cols - 1; k++)

            {
                engine.SetValue(variables[k], data[0][i][k]);
            }
            try
            {
                if (GetInputExpression.exp.Length == 0)
                {
                    textArray[i, cols - 1].GetComponent<Text>().text = "";
                    //numbers.Clear();
                }
                else
                {
                    //Debug.Log(GetInputExpression.exp);
                    engine.Execute(GetInputExpression.exp);
                    //Debug.Log(engine.GetCompletionValue().ToObject());
                    textArray[i, cols - 1].GetComponent<Text>().text = engine.GetCompletionValue().ToObject().ToString();
                }
            }
            catch (Exception err)
            {
             //  Debug.Log(err.Message);
            }
        }
    }

    void displayScore()
    {
        SceneManager.LoadScene("DisplayScore");
    }

    void ClearTable()
    {
        for (int i = 0; i < variables.Length + 1; i++)
        {
            Destroy(varArray[0, i]);
        }
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Destroy(textArray[i, j]);
            }
        }
    }

    void LoadTable(JSONParser json)
    {
        canvas = new GameObject();
        canvas.AddComponent<RectTransform>();
        canvas.name = "Table Canvas";
        data = json.result.data;
        variables = json.result.variables;
        cols = variables.Length + 1; // num of vars, also data[0][0].Length
        rows = data[0].Length; // num of data points
        textArray = new GameObject[rows, cols];
        varArray = new GameObject[1, cols];
        variableColor = new Color(247, 123, 85, 255);
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(startX * 2 + xDiff * (cols + 1), yDiff * rows);
        canvas.AddComponent<Canvas>();
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        panel = new GameObject();
        panel.transform.SetParent(canvas.transform);
        panel.AddComponent<RectTransform>();
        float xDelta = startX + (xDiff * (cols)) / 2;
        //Debug.Log("X" + xDelta);
        float yDelta = (yDiff * (rows + 1)) / 2;
       //Debug.Log("Y" + yDelta);
        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(xDelta*2, yDelta*2);
        startY = panel.GetComponent<RectTransform>().rect.height;
        panel.name = "Table Panel";
        panel.transform.position = canvas.GetComponent<RectTransform>().position;
        float scale = parentCanvas.GetComponent<RectTransform>().rect.width / panel.GetComponent<RectTransform>().rect.width;
        panel.GetComponent<RectTransform>().localScale = new Vector3(scale, scale, 1);
        // making variables and variable buttons
        for (int i = 0; i < variables.Length; i++)
        {
            GameObject newObj = new GameObject();
            newObj.transform.SetParent(panel.transform);
            newObj.name = variables[i];
            newObj.AddComponent<RectTransform>();
            newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 225);
            Button varButton = newObj.AddComponent<Button>();
            varButton.onClick.AddListener(buttonAppend.ButtonTrigger);
            textArray[0, i] = newObj;
            varArray[0, i] = newObj;
            Text myText = newObj.AddComponent<Text>();
            myText.text = variables[i];
            myText.fontSize = 91;
            myText.font = font;
            myText.alignment = TextAnchor.MiddleCenter;
            myText.color = Color.gray;//variableColor;
            textArray[0, i].transform.localPosition = new Vector3(startX + (xDiff * i)-xDelta, startY + yDiff-yDelta, 0);
        }

        // results
        GameObject obj = new GameObject();
        obj.transform.SetParent(panel.transform);
        obj.name = "result";
        obj.AddComponent<RectTransform>();
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 225);
        textArray[0, variables.Length] = obj;
        varArray[0, variables.Length] = obj;
        Text text = obj.AddComponent<Text>();
        text.text = "result";
        text.fontSize = 85;
        text.font = font;
        text.color = Color.gray;// variableColor;
        text.alignment = TextAnchor.MiddleCenter;
        textArray[0, variables.Length].transform.localPosition = new Vector3(startX + (xDiff * variables.Length)-xDelta, startY + yDiff-yDelta, 0);

        // creating table
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject newObj = new GameObject();
                newObj.transform.SetParent(panel.transform);
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
                        //Debug.Log(GetInputExpression.exp);
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
                textArray[i, j].transform.localPosition = new Vector3(startX + (xDiff * j)-xDelta, startY - (yDiff * i)-yDelta, 0);
            }
        }
        canvas.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1440, 2560);
    }
}

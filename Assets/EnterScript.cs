using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Jint;

public class EnterScript : MonoBehaviour {
    public GameObject panel;
    public GameObject text;
    public void Enter()
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
        text = panel.transform.Find("Text (1)").gameObject;
        text.GetComponent<Text>().text += GetInputExpression.exp + '\n';
        var parser = new Jint.Parser.JavaScriptParser();
        var program = parser.Parse("j<5", new Jint.Parser.ParserOptions { Tokens = true });
        var s = program.Body.ToString();
        Debug.Log(s);
        Debug.Log(program.ToString());
            //new Engine()..Json.Parse(GetInputExpression.exp, null).ToString();
        //Debug.Log(TableCreator.counter);
    }
}


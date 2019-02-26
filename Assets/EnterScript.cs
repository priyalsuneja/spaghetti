using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Jint;

public class EnterScript : MonoBehaviour {
    public GameObject panel;
    public GameObject text;
    public GameObject tableCreator;
    public void Enter()
    {
        var tableCreatorInstance = tableCreator.GetComponent<TableCreator>();
        Debug.Log("Entered");
        for(int i = 0; i < tableCreatorInstance.rows; i++)
        {
            if(tableCreatorInstance.textArray[i, tableCreatorInstance.cols - 1].GetComponent<Text>().text != "True")
            {
                Debug.Log("returning");
                return;
            }
        }
        /*
         * looks like this:
         * {
                "id": 1, 
                "jsonrpc": "2.0", 
                "result": true
            }

         */
        // new code to call server whenever an invariant is entered
        JSONParser resultParser = new JSONParser();
        string responseJSON = CallServer.ExpToJS(GetInputExpression.exp);
        responseJSON = CallServer.CallServerOnTautology(responseJSON, tableCreatorInstance.variableJSON);
        resultParser = new JSONParser(responseJSON);

        //TODO FIX THIS
        //if(resultParser.result.result == true) {
            //TODO input things here: ex. "entered tautology! not accepted"
            //return;
        //}

        TableCreator.counter++;
        TableCreator.score++;
        text = panel.transform.Find("Text (1)").gameObject;
        text.GetComponent<Text>().text += GetInputExpression.exp + '\n';
        Debug.Log(TableCreator.counter);
    }
}


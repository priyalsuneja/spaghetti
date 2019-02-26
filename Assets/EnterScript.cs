using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Jint;

public class EnterScript : MonoBehaviour {
    public GameObject panel;
    public GameObject text;
    public GameObject tableCreator;

    //Chun's tester



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

            "{\n  \"id\": 1, \n  \"jsonrpc\": \"2.0\", \n  \"result\": true\n}\n"

         */
        // new code to call server whenever an invariant is entered
        string responseJSON = CallServer.ExpToJS(GetInputExpression.exp);
        responseJSON = CallServer.CallServerOnTautology(responseJSON, tableCreatorInstance.variableJSON);


        //TODO FIX THIS
        /*
         * This search returns the substring between two strings, so 
            the first index is moved to the character just after the first string.
            int first = factMessage.IndexOf("methods") + "methods".Length;
            int last = factMessage.LastIndexOf("methods");
            string str2 = factMessage.Substring(first, last - first);
            Console.WriteLine($"Substring between \"methods\" and \"methods\": '{str2}'");
         */
        int before = responseJSON.IndexOf("\"result\": ") + "result\": ".Length + 1;
        int after = responseJSON.IndexOf("\n}");
        string sampleString = responseJSON.Substring(before, after - before);
        if (sampleString == "true") {
            Debug.Log("Tautology, not accepted");
            return;
        }
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


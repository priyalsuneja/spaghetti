using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Jint;

public class MultiplayerEnterScript : NetworkBehaviour
{
    public GameObject panel;
    public GameObject text;
    public GameObject tableCreator;
    public GameObject feedbackBox;

    public void Enter()
    {
        var tableCreatorInstance = tableCreator.GetComponent<MultiplayerTableCreator>();
        Debug.Log("Entered");
        for (int i = 0; i < tableCreatorInstance.rows; i++)
        {
            if (tableCreatorInstance.textArray[i, tableCreatorInstance.cols - 1].GetComponent<Text>().text != "True")
            {
                Debug.Log("returning");
                return;
            }
        }
        /*
         * looks like this:
         *   "{\n  \"id\": 1, \n  \"jsonrpc\": \"2.0\", \n  \"result\": true\n}\n"
         */
        // new code to call server whenever an invariant is entered
        //string responseJSON = CallServer.ExpToJS(GetInputExpression.exp);
        string responseJSONS = CallServer.Sim(GetInputExpression.exp, tableCreatorInstance.variableJSON);
        responseJSONS = CallServer.ToSimplify(responseJSONS);
        string responseJSON = CallServer.CallServerOnTautology(responseJSONS, tableCreatorInstance.variableJSON);

        int before = responseJSON.IndexOf("\"result\": ") + "result\": ".Length + 1;
        int after = responseJSON.IndexOf("\n}");
        string sampleString = responseJSON.Substring(before, after - before);
        if (sampleString == "true")
        {
            Debug.Log("Tautology, not accepted");
            if (this.isLocalPlayer)
            {
                feedbackBox.GetComponent<Text>().text = "Tautology not accepted. Try again!";
            }
            return;
        }
        if (tableCreatorInstance.acceptedInv.Count > 0)
        {
            if (CallServer.Implied(responseJSONS, tableCreatorInstance.acceptedInv, tableCreatorInstance.variableJSON) == true)
            {
                Debug.Log("Implied statement, not accepted");
                if (this.isLocalPlayer)
                {
                    feedbackBox.GetComponent<Text>().text = "Implied statement not accepted. Try again!";
                }
                return;
            }
        }
        tableCreatorInstance.acceptedInv.AddLast(responseJSONS);

        if(this.isLocalPlayer)
        {
            feedbackBox.GetComponent<Text>().text = "Invariant accepted. Nice work!";
        }
        TableCreator.counter++;
        TableCreator.score++;
        TableCreator.startTime = Time.time;
        text = panel.transform.Find("Text (1)").gameObject;
        text.GetComponent<Text>().text += GetInputExpression.exp + '\n';
        Debug.Log(TableCreator.counter);
    }
}


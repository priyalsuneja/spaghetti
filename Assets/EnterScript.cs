using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Debug.Log(TableCreator.counter);
    }
}


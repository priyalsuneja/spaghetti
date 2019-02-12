using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputExpression : MonoBehaviour
{
    public static string exp;
    public static bool isExpression = false;
    public static bool isBool = false;
    public static List<string> parsed;
    public static LinkedList<string> numbers = new LinkedList<string>();
    //Note, currently it may run into bug if there is a space separating the numbers.
    public void GetExpression(string expression)
    {
        parsed = new List<string>();
        isBool = false;
        exp = expression;
        isExpression = false;
        if (exp.Length == 0)
        {
            return;
        }
    }
}
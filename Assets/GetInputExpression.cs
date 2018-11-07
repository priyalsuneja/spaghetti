﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputExpression : MonoBehaviour
{
    public string exp;
    public static bool isExpression = false;
    public static bool isBool = false;
    public static List<string> parsed;
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

        Debug.Log(exp);
        for (int x = 0; x < exp.Length; x++)//determine if it is a valid expression
        {
            if (exp[x] == ' ')//skip white space
            {
                continue;
            }
            if ((decimal)exp[x] == 61) //check for equality 
            {
                isBool = true;
            }
            if ((decimal)exp[x] == 43 || (decimal)exp[x] == 45 || (decimal)exp[x] == 61) //if there is an operator
            {
                int offsetI = 1;
                int offsetF = 1;
                while (x - offsetI > 0 && exp[x - offsetI] == ' ')//offset to the closest not white space character
                {
                    offsetI++;
                }
                while (x + offsetF < exp.Length && exp[x + offsetF] == ' ')
                {
                    offsetF++;
                }
                Debug.Log("x - off is " + (x - offsetI));
                Debug.Log("x + off is " + (x + offsetF));
                if (x - offsetI < 0 || x + offsetF == exp.Length)//check edge case
                {
                    isExpression = false;
                    return;
                }
                if (!(char.IsLetterOrDigit(exp[x - offsetI])) || !(char.IsLetterOrDigit(exp[x + offsetF]))) //make sure the closest one is a number or variable
                {
                    isExpression = false;
                    return;
                }
            }
        }
        isExpression = true;
        Debug.Log(isExpression);
        Debug.Log(isBool);
        for (int x = 0; x < exp.Length; x++)//parsing the string into a list
        {
            if (exp[x] == ' ')
            {
                continue;
            }
            string temp = "";
            if (char.IsDigit(exp[x]))
            {
                while (x < exp.Length && char.IsDigit(exp[x]))
                {
                    temp += exp[x];
                    x++;
                }
                x--;
            }
            else
            {
                temp += exp[x];
            }
            parsed.Add(temp);
        }
    }
}
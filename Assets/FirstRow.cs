using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstRow : MonoBehaviour {
    public int x;
    public int y;
    public int n;
    public int a;
    public int b;
    public string result = "";

    public Text rowText;

	// Use this for initialization
	void Start () {
		
	}

    void Calculation()
    {
        if (GetInputExpression.isExpression)
        {
            if (GetInputExpression.isBool)//boolean case, have left and right sum
            {
                int leftSum = 0;
                if (char.IsDigit(GetInputExpression.parsed[0][0]))
                {
                    leftSum = int.Parse(GetInputExpression.parsed[0]);
                }
                //else
                //{
                //    switch (GetInputExpression.parsed[0][0])
                //    {
                //        case 'x':
                //            leftSum = x;
                //            break;
                //        case 'y':
                //            leftSum = y;
                //            break;
                //        case 'n':
                //            leftSum = n;
                //            break;
                //        case 'a':
                //            leftSum = a;
                //            break;
                //        case 'b':
                //            leftSum = b;
                //            break;
                //        default:
                //            return;
                //    }
                //}
                int x = 1;
                while (GetInputExpression.parsed[x][0] != '=')
                {
                    int rightOp = 0;
                    if (char.IsDigit(GetInputExpression.parsed[x + 1][0]))
                    {
                        rightOp = int.Parse(GetInputExpression.parsed[x + 1]);
                    }
                    //else
                    //{
                    //    switch (GetInputExpression.parsed[x+1][0])
                    //    {
                    //        case 'x':
                    //            rightOp = x;
                    //            break;
                    //        case 'y':
                    //            rightOp = y;
                    //            break;
                    //        case 'n':
                    //            rightOp = n;
                    //            break;
                    //        case 'a':
                    //            rightOp = a;
                    //            break;
                    //        case 'b':
                    //            rightOp = b;
                    //            break;
                    //        default:
                    //            return;
                    //    }
                    //}
                    switch (GetInputExpression.parsed[x][0])
                    {
                        case '+':
                            leftSum += rightOp;
                            break;
                        case '-':
                            leftSum -= rightOp;
                            break;
                        default:
                            return;
                    }
                    x += 2;
                }
                int rightSum = 0;
                x++;
                if (char.IsDigit(GetInputExpression.parsed[x][0]))
                {
                    rightSum = int.Parse(GetInputExpression.parsed[x]);
                }
                //else
                //{
                //    switch (GetInputExpression.parsed[x][0])
                //    {
                //        case 'x':
                //            rightSum = x;
                //            break;
                //        case 'y':
                //            rightSum = y;
                //            break;
                //        case 'n':
                //            rightSum = n;
                //            break;
                //        case 'a':
                //            rightSum = a;
                //            break;
                //        case 'b':
                //            rightSum = b;
                //            break;
                //        default:
                //            return;
                //    }
                //}
                x++;
                for (; x < GetInputExpression.parsed.Count; x += 2)
                {
                    int rightOp = 0;
                    if (char.IsDigit(GetInputExpression.parsed[x + 1][0]))
                    {
                        rightOp = int.Parse(GetInputExpression.parsed[x + 1]);
                    }
                    //else
                    //{
                    //    switch (GetInputExpression.parsed[x+1][0])
                    //    {
                    //        case 'x':
                    //            rightOp = x;
                    //            break;
                    //        case 'y':
                    //            rightOp = y;
                    //            break;
                    //        case 'n':
                    //            rightOp = n;
                    //            break;
                    //        case 'a':
                    //            rightOp = a;
                    //            break;
                    //        case 'b':
                    //            rightOp = b;
                    //            break;
                    //        default:
                    //            return;
                    //    }
                    //}
                    switch (GetInputExpression.parsed[x][0])
                    {
                        case '+':
                            rightSum += rightOp;
                            break;
                        case '-':
                            rightSum -= rightOp;
                            break;
                        default:
                            return;
                    }
                }
                if (leftSum == rightSum)
                {
                    result = "True";
                }
                else
                    result = "False";
            }
            else
            {
                int Sum = 0;
                if (char.IsDigit(GetInputExpression.parsed[0][0]))
                {
                    Sum = int.Parse(GetInputExpression.parsed[0]);
                }
                //else
                //{
                //    switch (GetInputExpression.parsed[0][0])
                //    {
                //        case 'x':
                //            leftSum = x;
                //            break;
                //        case 'y':
                //            leftSum = y;
                //            break;
                //        case 'n':
                //            leftSum = n;
                //            break;
                //        case 'a':
                //            leftSum = a;
                //            break;
                //        case 'b':
                //            leftSum = b;
                //            break;
                //        default:
                //            return;
                //    }
                //}
                for (int x = 1; x < GetInputExpression.parsed.Count; x += 2)
                {
                    int rightOp = 0;
                    if (char.IsDigit(GetInputExpression.parsed[x + 1][0]))
                    {
                        rightOp = int.Parse(GetInputExpression.parsed[x + 1]);
                    }
                    //else
                    //{
                    //    switch (GetInputExpression.parsed[x+1][0])
                    //    {
                    //        case 'x':
                    //            rightOp = x;
                    //            break;
                    //        case 'y':
                    //            rightOp = y;
                    //            break;
                    //        case 'n':
                    //            rightOp = n;
                    //            break;
                    //        case 'a':
                    //            rightOp = a;
                    //            break;
                    //        case 'b':
                    //            rightOp = b;
                    //            break;
                    //        default:
                    //            return;
                    //    }
                    //}
                    switch (GetInputExpression.parsed[x][0])
                    {
                        case '+':
                            Sum += rightOp;
                            break;
                        case '-':
                            Sum -= rightOp;
                            break;
                        default:
                            return;
                    }
                }
                result = Sum.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Calculation();
        rowText.text = x + "      " + y + "      " + n + "      " + a + "      " + b + " " + result;
    }
}

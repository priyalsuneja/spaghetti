using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceScript : MonoBehaviour {

    public void Backspace()
    {
        if (GetInputExpression.numbers.Count >0)
        {
            GetInputExpression.numbers.RemoveLast();
            GetInputExpression.exp = "";
            foreach( string s in GetInputExpression.numbers)
            {
                GetInputExpression.exp += s;
            }
            
        }
    }

    public void Clear()
    {
        GetInputExpression.numbers.Clear();
        GetInputExpression.exp = "";
    }
    
}

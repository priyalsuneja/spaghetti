using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonAppend : MonoBehaviour {
    public static void ButtonTrigger()
    {
        GetInputExpression.numbers.AddLast(EventSystem.current.currentSelectedGameObject.name);
        GetInputExpression.exp += EventSystem.current.currentSelectedGameObject.name;

    }
    public void buttonTrigger()
    {
        GetInputExpression.numbers.AddLast(EventSystem.current.currentSelectedGameObject.name);
        GetInputExpression.exp += EventSystem.current.currentSelectedGameObject.name;
    }
}


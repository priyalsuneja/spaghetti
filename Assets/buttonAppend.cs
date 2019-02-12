using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonAppend : MonoBehaviour {
    public static void ButtonTrigger()
    {
        GetInputExpression.exp += EventSystem.current.currentSelectedGameObject.name;
    }
    public void buttonTrigger()
    {
        GetInputExpression.exp += EventSystem.current.currentSelectedGameObject.name;
    }
}


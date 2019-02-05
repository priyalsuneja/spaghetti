using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvariantDisplay : MonoBehaviour {

    public GameObject panel; // this is the panel to be displayed

    public void DisplayInvariants()
    {
        if(!panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}

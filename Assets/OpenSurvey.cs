using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSurvey : MonoBehaviour {

    void Start() { }

    public void Open()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSeEiYYozx2NSosAP-LwwPBws7-Ll6iFpU3EvHn0qYvcqirE9A/viewform?usp=sf_link");
    }
}

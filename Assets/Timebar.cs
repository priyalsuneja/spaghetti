using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timebar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(101.39f * (1 - (Time.time - TableCreator.startTime) / 15.0f), 63.7f);
    }
}

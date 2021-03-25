﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float timeStart = 0;
    public bool isReady = false;
    private bool finnished = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timeStart.ToString("F2") + " sec.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isReady = true;
        }
        if (!finnished && isReady)
        {
            timeStart += Time.deltaTime;
            timerText.text = timeStart.ToString("F2") + " sec.";
        }
    }

    public void raceFinnished()
    {
        finnished = true;
        timerText.color = Color.red;
        
        //Debug.Log("Timer Stopped");
    }
}
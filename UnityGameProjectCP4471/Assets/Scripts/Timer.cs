using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float timeStart = 0;
    private bool finnished = false;
    
    //private GameObject winbox;


    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timeStart.ToString("F2");

    }

    // Update is called once per frame
    void Update()
    {
        if (!finnished)
        {
            timeStart += Time.deltaTime;
            timerText.text = timeStart.ToString("F2");

        }
    }

    public void raceFinnished()
    {
        finnished = true;
        timerText.color = Color.red;
        
        //Debug.Log("Timer Stopped");
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text bestRecord;
    public float bestTime = 59.59f;
    private float timeStart = 0;
    public bool isReady = false;
    private bool finnished = false;


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("highestScore", bestTime);
        bestTime = PlayerPrefs.GetFloat("highestScore");
        //bestTime = 59.59f;
        timerText.text = timeStart.ToString("F2") + " sec.";
    }

    // Update is called once per frame
    void Update()
    {
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
        //bestTime = PlayerPrefs.GetFloat("highscore");

        if (timeStart < bestTime)
        {
            //bestTime = timeStart;

            bestRecord.text = "New Record!\n" + timeStart.ToString("F2");
            PlayerPrefs.SetFloat("highestScore", timeStart);
            PlayerPrefs.Save();
        }
        else
        {
            bestRecord.text = "Try again! Your personal best is" +bestTime.ToString("F2");
        }
        Debug.Log(bestTime);
    }
}

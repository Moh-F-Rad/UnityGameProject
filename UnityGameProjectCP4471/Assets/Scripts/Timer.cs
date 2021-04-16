using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text bestRecord;
    public Text bestSpeedRecordText;
    public PlayerController player;
    public float bestTime;//= 59.59f
    public float bestSpeedRecord;
    private float timeStart = 0;
    private float finalSpeed;
    public bool isReady = false;
    private bool finnished = false;


    // Start is called before the first frame update
    void Start()
    {
/*        PlayerPrefs.SetFloat("highestScore", 59.99f);
        PlayerPrefs.SetFloat("highestSpeed", 9.99f);*/
        bestTime = PlayerPrefs.GetFloat("highestScore", 59.59f);
        bestSpeedRecord = PlayerPrefs.GetFloat("highestSpeed", 9.99f);
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

        finalSpeed = player.speed;

        //bestTime = PlayerPrefs.GetFloat("highscore");

        if (timeStart < bestTime)
        {
            //bestTime = timeStart;

            bestRecord.text = "New Time Record!\n" + timeStart.ToString("F2");
            PlayerPrefs.SetFloat("highestScore", timeStart);
            PlayerPrefs.Save();
        }
        else
        {
            bestRecord.text = "Try again! Your personal best is " +bestTime.ToString("F2");
        }
        Debug.Log(bestTime);

        if (finalSpeed > bestSpeedRecord)
        {
            PlayerPrefs.SetFloat("highestSpeed", finalSpeed);
            bestSpeedRecordText.gameObject.SetActive(true);
            bestSpeedRecordText.text = "New Record! " + finalSpeed.ToString("F1") + " km/h";
        }

        else {
            bestSpeedRecordText.gameObject.SetActive(true);
            bestSpeedRecordText.text = "Drive faster next time!";
        }

        //PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}

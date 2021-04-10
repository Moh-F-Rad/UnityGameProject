using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Tachometer tachometer;
    public Timer timer;
    public Speedometer speedometer;
    public PauseResume pauseResume;
    public SFXManager sfxPlayer;

    public GameObject restartButton;
    public GameObject exitButton;
    public GameObject bestTimeText;
    public GameObject pauseButton;

    public int countdownTime = 3;
    public Text countdownDisplay;

    public int minRPM = 0;
    public float maxRPM = 9.99f;
    public float currentRPM;
    
    public float speed = 10.0f;
    public float maxSpeed = 250f;
    public bool enginStarted;
    public float bestGearshift = 1.1f;
    public float best2ndGearshift = 0.5f;
    public float best3rdGearshift = 0.25f;
    public float best4thGearshift = 0.15f;
    public float best5thGearshift = 0.07f;
    public float initialAcceleration = 1.1f;
    public float currentTachometerValue;
    public int gearShiftCounter;
    public float rateOfTachometer;
    private bool isCoroutineExecuting = false;

    private bool gearShiftEnabled;


    public float forwardInput;
    public bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart());
        //SFXManager.PlaySound("CountDown");
        enginStarted = false;
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        bestTimeText.gameObject.SetActive(false);

        isReady = false;
        gearShiftEnabled = false;
        gearShiftCounter = 0;
        rateOfTachometer = 0.06f;
        currentRPM = minRPM;
        tachometer.SetMinRPM(minRPM);
         
    }

    // Update is called once per frame
    void Update()
    {
        if ((isReady) && (speed < maxSpeed) && (!pauseResume.GamePaused))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                enginStarted = true;
            }

            if (enginStarted)
            {
                speed += best4thGearshift;
                transform.Translate(Vector3.forward * Time.deltaTime * speed);

                gearShiftEnabled = true;

                currentRPM += rateOfTachometer;

                if (currentRPM < maxRPM)
                {
                    tachometer.rpmText.text = (currentRPM * 1000).ToString("0") + " RPM";
                }
                else
                {
                    //tachometer.SetRPM(maxRPM);
                    tachometer.rpmText.text = (maxRPM * 1000).ToString("0") + " RPM";
                }

                tachometer.SetRPM(currentRPM);
            }
        }

        if ((gearShiftEnabled && gearShiftCounter < 5) && (!pauseResume.GamePaused))
        {
            //Debug.Log("Able to shift the gear!!");
            currentTachometerValue = tachometer.slider.value;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                gearShiftCounter++;
                tachometer.gearNumber.text = gearShiftCounter.ToString();

                if ((currentTachometerValue > 6.50f) && (currentTachometerValue < 7.50f))
                {
                    perfectTiming();
                    tachometer.rpmText.color = Color.green;
                }
                else if (((currentTachometerValue > 3.50f) && (currentTachometerValue < 6.50f))
                     || ((currentTachometerValue > 7.50f) && currentTachometerValue < 9.0f))
                {
                    goodTiming();
                    tachometer.rpmText.color = Color.yellow;
                }

                else if (currentTachometerValue > 9.0f)
                {
                    moderateTiming();
                    tachometer.rpmText.color = Color.red;
                }

                else if (currentTachometerValue < 3.50f)
                {
                    badTiming();
                    tachometer.rpmText.color = Color.blue;
                }

                if (gearShiftCounter == 2)
                {
                    rateOfTachometer = 0.05f;
                }

                if (gearShiftCounter == 3)
                {
                    rateOfTachometer = 0.035f;
                }

                if (gearShiftCounter == 4)
                {
                    rateOfTachometer = 0.025f;
                }

                if (gearShiftCounter == 5)
                {
                    rateOfTachometer = 0.0166f;
                    if (getCurrentRPM() >= 8.20)
                    {
                        rateOfTachometer = 0;
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndPointWinBox")
        {
            //isReady = false;
            timer.raceFinnished();

/*            try
            {
                sfxPlayer.PlayBrake();
            }
            catch (System.NullReferenceException ex)
            {
                Debug.Log("Something went wrong!");
            }
*/
        }

        if (other.tag == "EndPointGameOver")
        {
            isReady = false;
            StartCoroutine(ExecuteAfterTime(1f));
            pauseButton.SetActive(false);
        }
    }

    // To get the current RPM value, use this: tachometer.slider.value

    public float getCurrentRPM()
    {
        return tachometer.slider.value;
    }

    public void perfectTiming()
    {
        speed += 15; 
        Debug.Log("Perfect!");
        currentRPM = 4.0f;
    }

    public void goodTiming()
    {
        speed += 10;
        Debug.Log("Good");
        currentRPM = 3.0f;
    }

    public void moderateTiming()
    {
        speed += 5;
        Debug.Log("Not bad!");
        currentRPM = 2.0f;
    }

    public void badTiming()
    {
        speed += 2;
        Debug.Log("Oh NO!!");
        currentRPM = 1.0f;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        bestTimeText.gameObject.SetActive(true);

        isCoroutineExecuting = false;
    }

    public IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);
        isReady = true;
        timer.isReady = true;
        speedometer.isReady = true;
        countdownDisplay.gameObject.SetActive(false);
        
    }


}

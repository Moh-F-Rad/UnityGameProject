using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Tachometer tachometer;
    
    public int minRPM = 0;
    public float currentRPM;
    
    public float speed = 10.0f;
    public float maxSpeed = 250f;
    public float bestGearshift = 1.1f;
    public float best2ndGearshift = 0.5f;
    public float best3rdGearshift = 0.25f;
    public float best4thGearshift = 0.15f;
    public float best5thGearshift = 0.07f;
    public float initialAcceleration = 1.1f;
    public float currentTachometerValue;
    public int gearShiftCounter;
    public float rateOfTachometer;


    private float boostTimer;
    private float boostPeriod = 3;
    private bool boosting;

    private bool gearShiftEnabled;


    public float forwardInput;
    public bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        gearShiftEnabled = false;
        gearShiftCounter = 0;
        rateOfTachometer = 0.06f;
        

        currentRPM = minRPM;
        tachometer.SetMinRPM(minRPM);
        
        boostTimer = 0;
        boosting = false;       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isReady = true;
            
            //boosting = true;
        }

        if ((isReady) && (speed < maxSpeed)) 
        {
            //forwardInput = Input.GetAxis("Vertical");
            speed += best4thGearshift;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            gearShiftEnabled = true;

            currentRPM += rateOfTachometer;
            tachometer.SetRPM(currentRPM);

            //getCurrentRPM();
           
        }

        if (gearShiftEnabled && gearShiftCounter < 5) 
        {
            //Debug.Log("Able to shift the gear!!");
            currentTachometerValue = tachometer.slider.value;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                gearShiftCounter++;

                if ((currentTachometerValue > 6.50f) && (currentTachometerValue < 7.50f))
                {
                    perfectTiming();
                }
                else if (((currentTachometerValue > 3.50f) && (currentTachometerValue < 6.50f))
                     || ((currentTachometerValue > 7.50f) && currentTachometerValue < 9.0f))
                {
                    goodTiming();
                }

                else if (currentTachometerValue > 9.0f)
                {
                    moderateTiming();
                }

                else if (currentTachometerValue < 3.50f)
                {
                    badTiming();
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
                }



            }
            

        
        }
/*        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer > boostPeriod)
            {
                boostTimer = 0;
                boosting = false;
                //speed = something as regular speed 
            }
        }*/
        
        
    }

    // To get the current RPM value, use this: tachometer.slider.value

    public float getCurrentRPM()
    {
        return tachometer.slider.value;
        //Debug.Log(tachometer.slider.value.ToString());
    }

    public void perfectTiming()
    {
        speed += bestGearshift; 
        Debug.Log("Perfect!");
        currentRPM = 4.0f;
        //tachometer.SetRPM(minRPM);
    }

    public void goodTiming()
    {
        speed += best2ndGearshift;
        Debug.Log("Good");
        currentRPM = 3.0f;
        //tachometer.SetRPM(minRPM);
    }

    public void moderateTiming()
    {
        speed += best3rdGearshift;
        Debug.Log("Not bad!");
        currentRPM = 2.0f;
        //tachometer.SetRPM(minRPM);

    }

    public void badTiming()
    {
        speed += best4thGearshift;
        Debug.Log("Oh NO!!");
        currentRPM = 1.0f;
        //tachometer.SetRPM(minRPM);

    }

    //TODO: Create a function that triggers an event listener to make the boosting true and 
    // accelerates the car speed rapidly
    // More comments here

}

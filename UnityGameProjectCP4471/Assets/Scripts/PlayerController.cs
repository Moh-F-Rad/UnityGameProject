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
    public float bestGearshift = 0.5f;
    public float best2ndGearshift = 0.25f;
    public float best3rdGearshift = 0.15f;
    public float best4thGearshift = 0.05f;
    public float best5thGearshift = 0.02f;
    public float initialAcceleration = 1.1f;
    
    private float boostTimer;
    private float boostPeriod = 3;
    private bool boosting;


    public float forwardInput;
    public bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
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
        }

        if ((isReady) && (speed < maxSpeed)) 
        {
            //forwardInput = Input.GetAxis("Vertical");
            speed += best4thGearshift;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            currentRPM += 0.025f;
            tachometer.SetRPM(currentRPM);
            getCurrentRPM();

            
        }

        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer > boostPeriod)
            {
                boostTimer = 0;
                boosting = false;
                //speed = something as regular speed 
            }
        }
        
        
    }

    // To get the current RPM value, use this: tachometer.slider.value

    public void getCurrentRPM()
    {

        //Debug.Log(tachometer.slider.value.ToString());
    }

    //TODO: Create a function that triggers an event listener to make the boosting true and 
    // accelerates the car speed rapidly
    // More comments here

}

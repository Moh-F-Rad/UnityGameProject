using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    public bool isReady = false;

    // Start is called before the first frame update
    void Start()
    {
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
            speed += best2ndGearshift;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            
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

    //TODO: Create a function that triggers an event listener to make the boosting true and 
    // accelerates the car speed rapidly

}

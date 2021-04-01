using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Speedometer : MonoBehaviour
{
    public Text speedometerText;
    public PlayerController player;
    public float initialSpeed = 0.0f;
    public bool isReady = false;

    // Start is called before the first frame update
    void Start()
    {
        speedometerText.text = initialSpeed.ToString("F1") + " km/h";
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            speedometerText.text = player.speed.ToString("F1") + " km/h";
        }
    }
}

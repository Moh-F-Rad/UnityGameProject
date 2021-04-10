using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static AudioClip brakeSound, countdownSound, highSpeedSound, lowSpeedSound, idleSound, startToGoSound;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        brakeSound = Resources.Load<AudioClip>("Brake2");
        countdownSound = Resources.Load<AudioClip>("CountDown");
        highSpeedSound = Resources.Load<AudioClip>("High");
        lowSpeedSound = Resources.Load<AudioClip>("Low");
        idleSound = Resources.Load<AudioClip>("Idle");
        startToGoSound = Resources.Load<AudioClip>("Start");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "Brake2":
                audioSource.PlayOneShot(brakeSound);
                break;

            case "CountDown":
                audioSource.PlayOneShot(countdownSound);
                break;

            case "High":
                audioSource.PlayOneShot(highSpeedSound);
                break;

            case "Low":
                audioSource.PlayOneShot(lowSpeedSound);
                break;

            case "Idle":
                audioSource.PlayOneShot(idleSound);
                break;

            case "Start":
                audioSource.PlayOneShot(startToGoSound);
                break;
        }
    }
}

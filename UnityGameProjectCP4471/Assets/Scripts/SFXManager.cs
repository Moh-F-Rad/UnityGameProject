using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource brake;
    public AudioSource countDown;
    public AudioSource startGo;
    public AudioSource highSpeed;
    public AudioSource lowSpeed;
    public AudioSource idle;

    public void PlayBrake()
    {
        Debug.Log("Brake sound plays! ");
        brake.Play();
    }

    public void PlayCountDown() { countDown.Play(); }

    public void PlayStartToGo() { startGo.Play(); }

    public void PlayHighSpeed() { highSpeed.Play(); }

    public void PlayLowSpeed() { lowSpeed.Play(); }

    public void PlayIdle() { idle.Play(); }
}

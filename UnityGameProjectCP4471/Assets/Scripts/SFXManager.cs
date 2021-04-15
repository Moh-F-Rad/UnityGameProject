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
        brake.Play();
    }

    public void PlayCountDown() { countDown.Play(); }

    public void PlayStartToGo() { startGo.Play(); }

    public void PlaySpeedGear1()
    {
        highSpeed.pitch = 0.75f;
        highSpeed.Play();
    }

    public void PlaySpeedGear2()
    {
        highSpeed.pitch = 0.80f;
        highSpeed.Play();
    }

    public void PlaySpeedGear3()
    {
        highSpeed.pitch = 0.85f;
        highSpeed.Play();
    }
    public void PlaySpeedGear4()
    {
        highSpeed.pitch = 0.90f;
        highSpeed.Play();
    }

    public void PlaySpeedGear5()
    {
        highSpeed.pitch = 1;
        highSpeed.Play();
    }

    public void StopHighSpeedSFX()
    {
        highSpeed.Stop();
    }

    public void StopLoWSpeedSFX()
    {
        lowSpeed.Stop();
    }

    public void PlayLowSpeed() { lowSpeed.Play(); }

    public void PlayIdle() { idle.Play(); }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseResume : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject PauseButton;
    public SFXManager sfx;
    public PlayerController player;
    private int currentGear;
    public bool speedSFX_Required = true;

    public bool GamePaused;


    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        currentGear = player.gearShiftCounter;
    }

    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);

        try
        {
            sfx.PlayBrake();
            sfx.StopHighSpeedSFX();
            sfx.StopLoWSpeedSFX();
        }
        catch (System.NullReferenceException ex)
        {
            Debug.Log("Something went wrong!");
        }

    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
        Debug.Log(currentGear.ToString());

        if (speedSFX_Required)
        {
            switch (currentGear)
            {
                case 1:
                    sfx.PlaySpeedGear1();
                    break;
                case 2:
                    sfx.PlaySpeedGear2();
                    break;
                case 3:
                    sfx.PlaySpeedGear3();
                    break;
                case 4:
                    sfx.PlaySpeedGear4();
                    break;
                case 5:
                    sfx.PlaySpeedGear5();
                    break;
            }
        }
        else {
            sfx.StopHighSpeedSFX();
            sfx.StopLoWSpeedSFX();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonController : MonoBehaviour
{
    public void exit()
    {
        Application.Quit();
        Debug.Log("Exit is cliked!");
    }

}

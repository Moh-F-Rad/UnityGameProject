using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tachometer : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text rpmText;
    public Text messageText;
    public Text gearNumber;
    public bool gameIsOver = false;
    public void SetMinRPM(float rpm)
    {
        slider.minValue = rpm;
        slider.value = rpm;
        fill.color = gradient.Evaluate(0f);

    }

    public void SetRPM(float rpm)
    {
        slider.value = rpm;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
